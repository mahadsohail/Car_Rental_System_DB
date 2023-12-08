using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace Car_Rental
{
    public partial class Review : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if car id exists in query string
                if (!string.IsNullOrEmpty(Request.QueryString["carid"]))
                {
                    int carId = Convert.ToInt32(Request.QueryString["carid"]);

                    // Retrieve reviews for the car id
                    DataTable dt = GetReviewsForCar(carId);

                    // Iterate through the reviews and display them
                    foreach (DataRow dr in dt.Rows)
                    {
                        string ratingStars = Convert.ToString(dr["rating"]);
                        string reviewText = Server.HtmlEncode(dr["comment"].ToString());
                        string reviewerName = GetReviewerName(Convert.ToInt32(dr["renter_id"]));


                        // Create the review HTML
                        string reviewHtml = $@"
                    <div class='review'>
                        <div class='review-header'>
                            <h2>Rating {ratingStars}/5</h2>
                            <p class='rating'>{ratingStars}</p>
                        </div>
                        <p class='review-text'>{reviewText}</p>
                        <p class='review-author'>- {reviewerName}</p>
                    </div>";

                        // Add the review to the page
                        reviewsContainer.InnerHtml += reviewHtml;
                    }
                }
                else
                {
                    // Display error message if car id is not provided
                    reviewsContainer.InnerHtml = "<p>Error: Car id not provided.</p>";
                }
            }
        }

        // Retrieve reviews for a car
        private DataTable GetReviewsForCar(int carId)
        {
            DataTable dt = new DataTable();
            string connString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString; ;
            string query = $"SELECT * FROM Review WHERE car_owner_id = {carId}";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        // Get the star rating HTML for a rating value
        private string GetRatingStars(int rating)
        {
            string ratingStars = "";

            for (int i = 0; i < rating; i++)
            {
                ratingStars += "<i class='fa fa-star'></i>";
            }

            for (int i = rating; i < 5; i++)
            {
                ratingStars += "<i class='fa fa-star-o'></i>";
            }

            return ratingStars;
        }

        // Get the name of a reviewer
        private string GetReviewerName(int reviewerId)
        {
            string reviewerName = "";
            string connString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString; ;
            string query = $"SELECT username FROM user_ WHERE user_id = {reviewerId}";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    reviewerName = cmd.ExecuteScalar().ToString();
                }
            }

            return reviewerName;
        }

    }
}