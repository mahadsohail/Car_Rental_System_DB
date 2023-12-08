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
    public partial class User_Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the user ID from the query string
                int userId = int.Parse(Request.QueryString["id"]);

                // Connect to the database
                string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Retrieve the user's data from the database
                    string query = "SELECT * FROM user_ WHERE user_id = @userId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                           
                            // Populate the form with the user's data
                            username.Value = reader["username"].ToString();
                            password1.Value = reader["password"].ToString();
                            email.Value = reader["email"].ToString();
                            phone.Value = reader["phone_number"].ToString();
                            password1.Attributes.Add("type", "password");
                        }
                        reader.Close();
                    }
                }
               
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Get the user ID from the query string
            int userId = int.Parse(Request.QueryString["id"]);

            // Connect to the database
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Retrieve the user's data from the database
                string query = "SELECT password FROM user_ WHERE user_id = @userId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    string dbPassword = (string)command.ExecuteScalar();

                    // Check if the current password matches the one in the database
                    if (current.Value == dbPassword)
                    {
                        // Enable the form controls for editing
                        username.Disabled = false;
                        password1.Disabled = false;
                        email.Disabled = false;
                        phone.Disabled = false;
                        Button2.Enabled = true;
                        password1.Value=dbPassword;
                        password1.Attributes.Add("type", "text");
                    }
                }
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(Request.QueryString["id"]);
            // Connect to the database
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the username or email already exists for another user
                string query = "SELECT COUNT(*) FROM user_ WHERE (username = @username OR email = @email) AND user_id != @userId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username.Value);
                    command.Parameters.AddWithValue("@email", email.Value);
                    command.Parameters.AddWithValue("@userId", userId);
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        // Username or email already exists for another user
                        string errorMessage = "Username or email already exists for another user.";
                        string script = "alert('" + errorMessage + "')";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", script, true);
                        return;
                    }
                }

                // Update the user's data in the database
                query = "UPDATE user_ SET username = @username, password = @password, email = @email, phone_number = @phone WHERE user_id = @userId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username.Value);
                    command.Parameters.AddWithValue("@password", password1.Value);
                    command.Parameters.AddWithValue("@email", email.Value);
                    command.Parameters.AddWithValue("@phone", phone.Value);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.ExecuteNonQuery();
                }
            }

            // Reload the page
            Response.Redirect(Request.RawUrl);


        }
    }
}