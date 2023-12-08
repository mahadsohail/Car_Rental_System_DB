using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car_Rental
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve car ID from query string parameter
                int carId = int.Parse(Request.QueryString["carId"]);

                // Retrieve car data from database
                string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString; ;
                string query = "SELECT * FROM Car WHERE car_id = @carId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@carId", carId);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate form fields with car data
                            DateTime startDate = reader.GetDateTime(reader.GetOrdinal("start_date"));
                            DateTime endDate = reader.GetDateTime(reader.GetOrdinal("end_date"));
                            decimal price = reader.GetDecimal(reader.GetOrdinal("price"));
                            
                            txtstartDate.Value = startDate.ToString("yyyy-MM-dd");
                            txtendDate.Value = endDate.ToString("yyyy-MM-dd");
                            txtPrice.Value = price.ToString();
                            
                          }
                        else

                        {
                            // Car not found in database
                            Response.Redirect("UploadedCars.aspx?id=" + int.Parse(Request.QueryString["id"]));
                        }
                    }
                }
            }

        }

     
        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Retrieve car ID from query string parameter
            int carId = int.Parse(Request.QueryString["carId"]);

            // Retrieve updated car data from form
            DateTime startDate = DateTime.Parse(txtstartDate.Value.ToString());
            DateTime endDate = DateTime.Parse(txtendDate.Value.ToString());
            decimal price = decimal.Parse(txtPrice.Value.ToString());

            // Update car data in database
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString; ;
            string query = "UPDATE Car SET start_date = @startDate, end_date = @endDate, price = @price WHERE car_id = @carId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@startDate", startDate);
                command.Parameters.AddWithValue("@endDate", endDate);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@carId", carId);

                connection.Open();
                command.ExecuteNonQuery();
            }

            // Redirect to car details page
            Response.Redirect("UploadedCars.aspx?id=" + int.Parse(Request.QueryString["id"]));

        }
    }
}