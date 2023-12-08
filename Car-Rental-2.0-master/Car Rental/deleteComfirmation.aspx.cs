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
    public partial class deleteComfirmation : System.Web.UI.Page
    {
        protected int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    id = int.Parse(Request.QueryString["id"]);
                }
            }
        }

        protected void confirm_Click(object sender, EventArgs e)
        {
    
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString; ;
            SqlConnection connection = new SqlConnection(connectionString);

            // Construct the SQL query to delete the car from the Car table
            string delete_car_query = "DELETE FROM Car WHERE car_id = @car_id";
            string qurey = "DELETE FROM car_image WHERE car_id = @car_id";
            string qurey3 = "DELETE FROM RentalRequest WHERE car_id = @car_id";
            string query4 = "Delete from Review where car_owner_id=@car_id";

            // Create the SQL command object
            SqlCommand command = new SqlCommand(delete_car_query, connection);
            SqlCommand command2 = new SqlCommand(qurey, connection);
            SqlCommand command3 = new SqlCommand(qurey3, connection);
            SqlCommand command4 = new SqlCommand(query4, connection);

            command.Parameters.AddWithValue("@car_id", int.Parse(Request.QueryString["carid"]));
            command2.Parameters.AddWithValue("@car_id", int.Parse(Request.QueryString["carid"]));
            command3.Parameters.AddWithValue("@car_id", int.Parse(Request.QueryString["carid"]));
            command4.Parameters.AddWithValue("@car_id", int.Parse(Request.QueryString["carid"]));
            try
            {
                // Open the database connection and execute the query
                connection.Open();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
                command4.ExecuteNonQuery();
                int rowsAffected = command.ExecuteNonQuery();

                
                

                // Check if any rows were affected by the query and show a success message
                if (rowsAffected > 0)
                {
                    string successMessage = "Car successfully deleted";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", $"alert('{successMessage}');", true);
                    Response.Redirect("UploadedCars.aspx?id=" + int.Parse(Request.QueryString["id"]),false);
                }
                else
                {
                    string errorMessage = "An error occurred while deleting the car";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", $"alert('{errorMessage}');", true);
                    Response.Redirect("UploadedCars.aspx?id=" + int.Parse(Request.QueryString["id"]),false);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while deleting the car";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", $"alert('{errorMessage}');", true);
            }
            finally
            {
                // Close the database connection
                connection.Close();
            }
        }

        protected void no_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadedCars.aspx?id=" + int.Parse(Request.QueryString["id"]), false);

        }
    }
}