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
    public partial class Give_Review : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sub_Click(object sender, EventArgs e)
        {
            
            int carId = Convert.ToInt32(Request.QueryString["carId"]);
            int userId = Convert.ToInt32(Request.QueryString["id"]);

       
            string description = Description.Value;
            int rating = Convert.ToInt32(Rating.Value);

      
            string query = "INSERT INTO Review (car_owner_id, renter_id, rating, comment) " +
                           "VALUES (@carId, @userId, @rating, @description)";

          
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                
                connection.Open();

              
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@carId", carId);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@rating", rating);
                    command.Parameters.AddWithValue("@description", description);
                    command.ExecuteNonQuery();
                }
            }

            Response.Redirect("HIstory.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));

        }
    }
}