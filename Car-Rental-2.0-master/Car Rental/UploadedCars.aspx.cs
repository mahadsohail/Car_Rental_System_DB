using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car_Rental
{
    public partial class UploadedCars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Connect to the database
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString; ;
            SqlConnection connection = new SqlConnection(connectionString);

            // Construct the SQL query to retrieve car data
            string query = "SELECT Car.car_id, Car.make, Car.model, Car.year, Car.price, first_image.image_url " +
                               "FROM Car " +
                               "LEFT JOIN (" +
                               "    SELECT car_id, MIN(image_url) as image_url " +
                               "    FROM Car_Image " +
                               "    GROUP BY car_id" +
                               ") AS first_image ON Car.car_id = first_image.car_id " +
                               "WHERE Car.owner_id = @owner_id " +
                               "AND Car.is_available = 1";


            // Create the SQL command object
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@owner_id", int.Parse(Request.QueryString["id"]));

            // Open the database connection and execute the query
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // Generate HTML code for each car and add it to the container div
            while (reader.Read())
            {
                int car_id = reader.GetInt32(0);
                string make = reader.GetString(1);
                string model = reader.GetString(2);
                int year = reader.GetInt32(3);
                decimal price = reader.GetDecimal(4);
                String image_url = null;
                if (reader["image_url"].ToString()!=null)
                image_url = Convert.ToBase64String((byte[])reader["image_url"]);

                string car_card_html = "<div class=\"car-card\" runat=\"\">" +
                                       $"<h2>{make} {model}</h2>" +
                                       $"<img src=\"data:image/jpeg;base64,{image_url}\" alt=\"{make} {model}\">" +
                                       $"<p><strong>Model:</strong> {model}</p>" +
                                       $"<p><strong>Year:</strong> {year}</p>" +
                                       $"<p><strong>Price per Hour:</strong> {price} PKR</p>" +
                                       $"<button onclick=\"window.location.href = 'edit.aspx?carid={car_id}&id={Request.QueryString["id"]}';\">Edit</button>&nbsp;" +
                                       $"<button onclick=\"window.location.href = 'deleteComfirmation.aspx?carid={car_id}&id={Request.QueryString["id"]}';\">Delete</button>&nbsp;" +
                                       $"<button onclick=\"window.location.href = 'Car Request Details.aspx?carid={car_id}&id={Request.QueryString["id"]}';\">Requests</button>&nbsp;" +
                                       $"<button onclick=\"window.location.href = 'Review.aspx?carid={car_id}&id={Request.QueryString["id"]}';\">Check Reviews</button>" +
                                       "</div>";

                container.InnerHtml += car_card_html;
            }

            // Close the database connection
            reader.Close();
            connection.Close();
        }
     
        
    }
}