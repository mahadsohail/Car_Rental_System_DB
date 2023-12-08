using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Car_Rental
{
    public partial class Car_Details : System.Web.UI.Page
    {
        protected int user_id;
        protected int car_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["userid"]))
                {
                    user_id = int.Parse(Request.QueryString["userid"]);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["carid"]))
                {
                    car_id = int.Parse(Request.QueryString["carid"]);
                }
            }
            int carId = Convert.ToInt32(Request.QueryString["carid"]);
            string make="" ;
            string model="";
            int year=0 ;
            string desc = "";
            string location="" ;
            decimal price=0 ;
            DateTime startDate=new DateTime();
            DateTime endDate= new DateTime();

            // Connect to the database
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // Retrieve the car information
            SqlCommand carCommand = new SqlCommand("SELECT make, model, year, location, price, start_date, end_date,description FROM Car WHERE car_id = @carId", connection);
            carCommand.Parameters.AddWithValue("@carId", carId);
            SqlDataReader carReader = carCommand.ExecuteReader();

            // Display the car information
            if (carReader.Read())
            {
                 make = carReader.GetString(0);
                 model = carReader.GetString(1);
                year = carReader.GetInt32(2);
                location = carReader.GetString(3);
                 price = carReader.GetDecimal(4);
                startDate = carReader.GetDateTime(5);
                endDate = carReader.GetDateTime(6);
                desc= carReader.GetString(7);

                // Display the car model in the heading
                carHeading.InnerHtml = "About " + make + " " + model;

                // Display the car information in the first section
                carInfo.InnerHtml = "<p>" + desc + "</p>";
            }
            carReader.Close();

            // Retrieve the car images
            SqlCommand imageCommand = new SqlCommand("SELECT image_url FROM Car_Image WHERE car_id = @carId", connection);
            imageCommand.Parameters.AddWithValue("@carId", carId);
            SqlDataReader imageReader = imageCommand.ExecuteReader();

            // Display the car images
            while (imageReader.Read())
            {
                byte[] bytes = (byte[])imageReader.GetValue(0);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                HtmlImage img = new HtmlImage();
                img.Src = "data:image/jpeg;base64," + base64String;
                img.Attributes.Add("class", "carImage");
                carImages.Controls.Add(img);
            }

            imageReader.Close();

            // Display the rental information in the second section
            rentalInfo.InnerHtml = "<p>" +make+" "+ model+" "+year + " is available for rent starting from " + startDate.ToShortDateString() + " to " + endDate.ToShortDateString() + ". The rental rate is Rs." + price + " per Hour.The car is available in the following area: "+location+" </p>";

            // Retrieve the owner information
            SqlCommand ownerCommand = new SqlCommand("SELECT email, phone_number FROM User_ WHERE user_id = (SELECT owner_id FROM Car WHERE car_id = @carId)", connection);
            ownerCommand.Parameters.AddWithValue("@carId", carId);
            SqlDataReader ownerReader = ownerCommand.ExecuteReader();

            // Display the owner information in the third section
            if (ownerReader.Read())
            {
                string email = ownerReader.GetString(0);
                string contact = ownerReader.GetString(1);

                contactInfo.InnerHtml = "<p>If you are interested in renting " + model + ", please contact the owner at provided below. You can also fill out the rental request form on this page to send a message to the owner.<br><strong> Email:</strong>  " + email + " <br><strong> Phone Number:</strong>   " + contact + " </p>";
            }
            ownerReader.Close();

            // Close the database connection
            connection.Close();
        }




    }
    }