using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Car_Rental
{
    public partial class Car_Request_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            // Retrieve all pending requests
            string query = "SELECT start_datetime,end_datetime,status,totalPrice,username,email,phone_number,request_id  FROM RentalRequest join user_ on user_id=renter_id WHERE status = 'pending' and car_id="+ int.Parse(Request.QueryString["carid"]);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               
                DateTime startDateTime = reader.GetDateTime(0);
                DateTime endDateTime = reader.GetDateTime(1);
                string status = reader.GetString(2);
                double price=reader.GetDouble(3);
                string n=reader.GetString(4);
                string em= reader.GetString(5);
                string p = reader.GetString(6);
                int requestId = reader.GetInt32(7);

                // Create a new customer details container for each request
                Panel customerDetails = new Panel();
                customerDetails.CssClass = "customer-details";

                // Add the customer details to the container
                LiteralControl name1 = new LiteralControl("<p><strong>Customer Request Details</strong></p>");
                LiteralControl name = new LiteralControl("<p><strong>Name:</strong>"+n+"</p>");
                LiteralControl email = new LiteralControl("<p><strong>Email:</strong>"+em+"</p>");
                LiteralControl phone = new LiteralControl("<p><strong>Phone:</strong>"+p+"</p>");
                LiteralControl totalPrice = new LiteralControl("<p><strong>Total Price:</strong>"+price+"</p>");
                LiteralControl pickupDate = new LiteralControl("<p><strong>Pickup Date:</strong> " + startDateTime.ToString("yyyy-MM-dd") + "</p>");
                LiteralControl returnDate = new LiteralControl("<p><strong>Return Date:</strong> " + endDateTime.ToString("yyyy-MM-dd") + "</p>");
                customerDetails.Controls.Add(name1);
                customerDetails.Controls.Add(name);
                customerDetails.Controls.Add(email);
                customerDetails.Controls.Add(phone);
                customerDetails.Controls.Add(totalPrice);
                customerDetails.Controls.Add(pickupDate);
                customerDetails.Controls.Add(returnDate);

                // Add the Confirm Request button
                Button confirmButton = new Button();
                confirmButton.Text = "Confirm Request";
                confirmButton.CssClass = "btn";
                
                confirmButton.CommandArgument = requestId.ToString();
                confirmButton.Click += new EventHandler(ConfirmRequest_Click);
                confirmButton.Attributes["runat"] = "server";
                

                // Add the Reject Request button
                Button rejectButton = new Button();
                rejectButton.Text = "Reject Request";
                rejectButton.CssClass = "btn";
                rejectButton.CommandArgument = requestId.ToString();
                rejectButton.Click += new EventHandler(RejectRequest_Click);
                rejectButton.Attributes["runat"] = "server";
                

                HtmlGenericControl form = new HtmlGenericControl("form");
                form.Attributes["runat"] = "server";

                // Add the buttons to the form control
                form.Controls.Add(confirmButton);
                form.Controls.Add(rejectButton);

                customerDetails.Controls.Add(form);

             


                // Add the customer details container to the page
                container.Controls.Add(customerDetails);
                container.Controls.Add(new LiteralControl("<br>"));
            }
            command.Dispose();
            command = null;
            reader.Close();

            string query2 = "SELECT start_datetime,end_datetime,status,totalPrice,username,email,phone_number,request_id  FROM RentalRequest join user_ on user_id=renter_id WHERE (status = 'accepted' or  status = 'rejected')  and car_id=" + int.Parse(Request.QueryString["carid"]);
            SqlCommand command2 = new SqlCommand(query2, connection);
            SqlDataReader reader2 = command2.ExecuteReader();


            while (reader2.Read())
            {

                DateTime startDateTime = reader2.GetDateTime(0);
                DateTime endDateTime = reader2.GetDateTime(1);
                string status = reader2.GetString(2);
                double price = reader2.GetDouble(3);
                string n = reader2.GetString(4);
                string em = reader2.GetString(5);
                string p = reader2.GetString(6);
                int requestId = reader2.GetInt32(7);

                // Create a new customer details container for each request
                Panel customerDetails = new Panel();
                customerDetails.CssClass = "customer-details";

                // Add the customer details to the container
                LiteralControl name1 = new LiteralControl("<p><strong>Customer Request Details</strong></p>");
                LiteralControl name = new LiteralControl("<p><strong>Name:</strong>" + n + "</p>");
                LiteralControl email = new LiteralControl("<p><strong>Email:</strong>" + em + "</p>");
                LiteralControl phone = new LiteralControl("<p><strong>Phone:</strong>" + p + "</p>");
                LiteralControl totalPrice = new LiteralControl("<p><strong>Total Price:</strong>" + price + "</p>");
                LiteralControl pickupDate = new LiteralControl("<p><strong>Pickup Date:</strong> " + startDateTime.ToString("yyyy-MM-dd") + "</p>");
                LiteralControl returnDate = new LiteralControl("<p><strong>Return Date:</strong> " + endDateTime.ToString("yyyy-MM-dd") + "</p>");
                LiteralControl st = new LiteralControl("<p><strong>Status:</strong> " + status + "</p>");
                customerDetails.Controls.Add(name1);
                customerDetails.Controls.Add(name);
                customerDetails.Controls.Add(email);
                customerDetails.Controls.Add(phone);
                customerDetails.Controls.Add(totalPrice);
                customerDetails.Controls.Add(pickupDate);
                customerDetails.Controls.Add(returnDate);
                customerDetails.Controls.Add(st);



                // Add the customer details container to the page
                container.Controls.Add(customerDetails);
                container.Controls.Add(new LiteralControl("<br>"));
            }


        }
        protected void ConfirmRequest_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int requestId = int.Parse(button.CommandArgument);

            // Update the request status to confirmed in the database
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = "UPDATE RentalRequest SET status='accepted' WHERE request_id=" + requestId;
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();

            // Reload the page to show the updated request list
            Response.Redirect(Request.RawUrl);
        }

        protected void RejectRequest_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int requestId = int.Parse(button.CommandArgument);

            // Update the request status to rejected in the database
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = "UPDATE RentalRequest SET status='rejected' WHERE request_id=" + requestId;
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();

            // Reload the page to show the updated request list
            Response.Redirect(Request.RawUrl);
        }

    }
}