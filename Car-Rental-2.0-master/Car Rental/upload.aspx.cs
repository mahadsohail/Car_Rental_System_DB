using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace Car_Rental
{
    public partial class upload : System.Web.UI.Page
    {
        protected int user_id;
        protected int car_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    user_id = int.Parse(Request.QueryString["id"]);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["carid"]))
                {
                    car_id = int.Parse(Request.QueryString["carid"]);
                }
            }
        }

        protected void BUT_Click(object sender, EventArgs e)
        {
            string name = Request.Form["name"];
            string email = Request.Form["email"];
            string phone = Request.Form["phone"];
            DateTime pickupTime = DateTime.Parse(Request.Form["pickup-datetime"]);
            DateTime returnTime = DateTime.Parse(Request.Form["return-datetime"]);
            decimal hourlyPrice = 0;

            // check if rental period is within car availability period
            bool isAvailable = false;
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT start_date, end_date, is_available,price FROM Car WHERE car_id=@car_id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@car_id", int.Parse(Request.QueryString["carid"]));
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        DateTime startDate = (DateTime)reader["start_date"];
                        DateTime endDate = (DateTime)reader["end_date"];
                        isAvailable = (bool)reader["is_available"];
                        hourlyPrice = (decimal)reader["price"];
                        reader.Close();
                        if (pickupTime >= startDate && returnTime <= endDate && isAvailable)
                        {

                            // save rental request
                            TimeSpan rentalPeriod = returnTime - pickupTime;
                            decimal totalPrice = hourlyPrice * (decimal)rentalPeriod.TotalHours;

                            string insertQuery = "INSERT INTO RentalRequest (car_id, renter_id, start_datetime, end_datetime, status,totalPrice) VALUES (@car_id, @renter_id, @start_datetime, @end_datetime, @status,@total)";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@car_id", int.Parse(Request.QueryString["carid"]));
                                insertCommand.Parameters.AddWithValue("@renter_id", int.Parse(Request.QueryString["id"]));
                                insertCommand.Parameters.AddWithValue("@start_datetime", pickupTime);
                                insertCommand.Parameters.AddWithValue("@end_datetime", returnTime);
                                insertCommand.Parameters.AddWithValue("@status", "Pending");
                                insertCommand.Parameters.AddWithValue("@total", totalPrice);
                                insertCommand.ExecuteNonQuery();
                            }



                            // display success message and redirect
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirectScript", "alert('Request sent!');window.location='cars.aspx?id=" + int.Parse(Request.QueryString["id"]) + "';", true);

                        }
                        else
                        {
                            // display error message
                            Response.Write("<script>alert('Car is not available for selected period.')</script>");
                           
                        }
                    }
                    reader.Close();
                }
            }
        }
    }
}
