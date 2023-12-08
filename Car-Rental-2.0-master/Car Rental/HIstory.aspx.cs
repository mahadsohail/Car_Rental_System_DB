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
    public partial class Hlstory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Define the query to retrieve rental requests for the user with the specified ID
            string query = "SELECT request_id, Car.model, User_.username, User_.phone_number, User_.email, start_datetime, end_datetime,car.car_id, status, totalPrice FROM RentalRequest " +
                           "JOIN Car ON RentalRequest.car_id = Car.car_id " +
                           "JOIN User_ ON Car.owner_id = User_.user_id " +
                           "WHERE RentalRequest.renter_id = @userId and status='accepted'";

            // Create a new SqlConnection object with your database connection string
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                // Open the database connection
                connection.Open();

                // Create a new SqlCommand object with the query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the user ID parameter to the SqlCommand object
                    command.Parameters.AddWithValue("@userId", Request.QueryString["id"]);

                    // Create a new SqlDataReader object to retrieve the query results
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Create a new StringBuilder object to build the HTML table
                        StringBuilder tableHtml = new StringBuilder();

                        // Add the table header row to the StringBuilder
                        tableHtml.Append("<table><thead><tr><th>Car Name</th><th>Owner Name</th><th>Start Date</th><th>End Date</th><th>Total Price</th><th>Action</th></tr></thead><tbody>");
                      
                        // Loop through each rental request returned by the query
                        while (reader.Read())
                        {
                            // Retrieve the rental request data from the SqlDataReader object
                            int requestId = (int)reader["request_id"];
                            string carName = (string)reader["model"];
                            string ownerName = (string)reader["username"];
                            DateTime startDate = (DateTime)reader["start_datetime"];
                            DateTime endDate = (DateTime)reader["end_datetime"];
                            decimal totalPrice = Convert.ToDecimal(reader["totalPrice"]);
                            int car_id= (int)reader["car_id"];
                            // Check if the user has already given a review for this rental request
                            bool reviewed = false;
                            string reviewQuery = "SELECT COUNT(*) FROM Review WHERE car_owner_id = @car_id AND renter_id = @userId";

                            using (SqlConnection reviewConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                            {
                                reviewConnection.Open();
                                using (SqlCommand reviewCommand = new SqlCommand(reviewQuery, reviewConnection))
                                {
                                    reviewCommand.Parameters.AddWithValue("@car_id", car_id);
                                    reviewCommand.Parameters.AddWithValue("@userId", Request.QueryString["id"]);
                                    int reviewCount = (int)reviewCommand.ExecuteScalar();
                                    reviewed = reviewCount > 0;
                                }

                                // Add a new row to the StringBuilder with the rental request information
                                tableHtml.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}PKR</td>", carName, ownerName, startDate.ToShortDateString(), endDate.ToShortDateString(), totalPrice);

                                // Add a button to the row to allow the user to give a review (if they haven't already)
                                if (!reviewed)
                                {
                                    tableHtml.AppendFormat("<td><button onclick=\"window.location.href='Give Review.aspx?carId={0}&id={1}&requestId={2}'\">Provide Review</button></td></tr>", reader["car_id"], Request.QueryString["id"], requestId);
                                }
                                else
                                {
                                    tableHtml.Append("<td>Reviewed</td></tr>");
                                }
                            }
                        }

                        // Add the closing tags to the StringBuilder and display the HTML table on the page
                        tableHtml.Append("</tbody></table>");
                        his.InnerHtml = tableHtml.ToString();
                    }
                }
            }

        }
    }
}