using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car_Rental
{
    public partial class RequestsSent : System.Web.UI.Page
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
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString; 



            string query = "SELECT request_id, Car.model, User_.username,User_.phone_number,User_.email, start_datetime, end_datetime, status, totalPrice FROM RentalRequest " +
                           "JOIN Car ON RentalRequest.car_id = Car.car_id " +
                           "JOIN User_ ON Car.owner_id = User_.user_id " +
                           "WHERE RentalRequest.renter_id = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", int.Parse(Request.QueryString["id"]));
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    StringBuilder sb = new StringBuilder();

                    // Build the HTML table header
                    sb.Append("<main><table><thead><tr><th>Request ID</th><th>Car Model</th><th>Owner Name</th><th>Owner Email</th><th>Owner Phone</th>" +
                              "<th>Pickup Date</th><th>Return Date</th><th>Status</th><th>Price</th></tr></thead><tbody>");

                    // Iterate through the data and build the table rows
                    while (reader.Read())
                    {
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6:N}</td><td>{7}</td><td>{8}</td></tr>",
                                         reader["request_id"], reader["model"], reader["username"], reader["email"], reader["phone_number"],
                                         ((DateTime)reader["start_datetime"]).ToString("yyyy-MM-dd"),
                                         ((DateTime)reader["end_datetime"]).ToString("yyyy-MM-dd"),
                                         reader["status"], reader["totalPrice"]);
                    }

                    // Close the HTML table
                    sb.Append("</tbody></table></main>");

                    // Set the HTML output to a label control on the ASPX page
                    lblTableOutput.Text = sb.ToString();
                }
            }

        }
    }
}