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
    public partial class uploadYourCar : System.Web.UI.Page
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
        protected void BUT_Click(object sender, EventArgs e)
        {
            
    // Get the owner ID from the query string
    int ownerId = Convert.ToInt32(Request.QueryString["id"]);

            // Get the form data
           
            string make = carmake.Value.ToString();
            string model = carmodel.Value.ToString();
            int year = Convert.ToInt32(caryear.Value.ToString());
            string location = Request.Form["location"];
            decimal price = Convert.ToDecimal(carpriceperhour.Value.ToString());
            string desc = cardescription.Value.ToString();

            // Generate a new car ID by finding the maximum existing ID and adding 1
            int carId = 1;
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString; ;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT MAX(car_id) FROM Car", connection);
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    carId = Convert.ToInt32(result) + 1;
                }
            }

            // Save the car data to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Car (car_id, owner_id, make, model, year, location, price, start_date, end_date, is_available,description) VALUES (@car_id, @owner_id, @make, @model, @year, @location, @price, @start_date, @end_date, @is_available,@desc)", connection);
                command.Parameters.AddWithValue("@car_id", carId);
                command.Parameters.AddWithValue("@owner_id", ownerId);
                command.Parameters.AddWithValue("@make", make);
                command.Parameters.AddWithValue("@model", model);
                command.Parameters.AddWithValue("@year", year);
                command.Parameters.AddWithValue("@location", location);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@start_date", Date1.Value);
                command.Parameters.AddWithValue("@end_date", Date2.Value);
                command.Parameters.AddWithValue("@is_available", true);
                command.Parameters.AddWithValue("@desc", desc);
                command.ExecuteNonQuery();
            }

            // Save the car images to the database
            HttpFileCollection files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                if (file.ContentLength > 0)
                {
                    // Read the file contents into a byte array
                    byte[] imageData = new byte[file.ContentLength];
                    file.InputStream.Read(imageData, 0, file.ContentLength);

                    // Generate a new image ID by finding the maximum existing ID and adding 1
                    int imageId = 1;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT MAX(image_id) FROM car_image", connection);
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            imageId = Convert.ToInt32(result) + 1;
                        }
                    }

                    // Save the image data to the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("INSERT INTO car_image (image_id, car_id, image_url) VALUES (@image_id, @car_id, @image_data)", connection);
                        command.Parameters.AddWithValue("@image_id", imageId);
                        command.Parameters.AddWithValue("@car_id", carId);
                        command.Parameters.AddWithValue("@image_data", imageData);
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Redirect to the home page
            Response.Redirect("home.aspx?id=" + ownerId.ToString());
        }

        }
}