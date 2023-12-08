using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car_Rental
{
    public partial class cars : System.Web.UI.Page
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
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT c.car_id,c.make, c.model, c.year, c.location, c.price, c.is_available, MAX(ci.image_url) AS image_url FROM Car c INNER JOIN car_image ci ON c.car_id = ci.car_id GROUP BY c.car_id, c.make, c.model, c.year, c.location, c.price, c.is_available";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    string make = reader["make"].ToString();
                    string model = reader["model"].ToString();
                    int year = Convert.ToInt32(reader["year"]);
                    string location = reader["location"].ToString();
                    decimal price = Convert.ToDecimal(reader["price"]);
                    bool isAvailable = Convert.ToBoolean(reader["is_available"]);
                    byte[] imageBytes = (byte[])reader["image_url"];
                    string base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                    string imageUrl = string.Format("data:image/jpeg;base64,{0}", base64String);

                    Panel carPanel = new Panel();
                    carPanel.CssClass = "car1";

                    Panel carHeaderPanel = new Panel();
                    carHeaderPanel.CssClass = "carHeader";

                    Label makeModelLabel = new Label();
                    makeModelLabel.Text = string.Format("{0} {1}", make, model);
                    carHeaderPanel.Controls.Add(makeModelLabel);

                    Label availabilityLabel = new Label();
                    availabilityLabel.Text = isAvailable ? "Available" : "Not Available";
                    carHeaderPanel.Controls.Add(availabilityLabel);

                    carPanel.Controls.Add(carHeaderPanel);

                    Image carImage = new Image();
                    carImage.ImageUrl = imageUrl;
                    carPanel.Controls.Add(carImage);

                    Panel carFooterPanel = new Panel();
                    carFooterPanel.CssClass = "carFooter";

                    Label priceLabel = new Label();
                    priceLabel.Text = string.Format("<strong>Price per Hour:</strong> {0:N} PKR", price);
                    carFooterPanel.Controls.Add(priceLabel);

                    carPanel.Controls.Add(carFooterPanel);

                    Button reviewButton = new Button();
                    reviewButton.Text = "Review";
                    reviewButton.ID = "ReviewButton"+counter;
                    reviewButton.CssClass = "btn-review"; // add CSS class
                    reviewButton.Click += new EventHandler(ReviewButton_Click);
                    carPanel.Controls.Add(reviewButton);

                    Button detailsButton = new Button();
                    detailsButton.Text = "See Details";
                    detailsButton.ID = "sdf"+counter;
                    detailsButton.CssClass = "btn-details"; // add CSS class
                    detailsButton.Click += new EventHandler(DetailsButton_Click);
                    carPanel.Controls.Add(detailsButton);
                    counter++;
                    carsPanel.Controls.Add(carPanel);
                }
                reader.Close();
            }
        }

        protected void ReviewButton_Click(object sender, EventArgs e)
        {
            Button reviewButton = (Button)sender;
            string buttonID = reviewButton.ID;
            int carIndex = int.Parse(buttonID.Replace("ReviewButton", ""));
            string carID = GetCarID(carIndex);
            Response.Redirect("Review.aspx?carid=" + carID+"&id="+ int.Parse(Request.QueryString["id"]));
        }

        protected void DetailsButton_Click(object sender, EventArgs e)
        {
            Button detailsButton = (Button)sender;
            string buttonID = detailsButton.ID;
            int carIndex = int.Parse(buttonID.Replace("sdf", ""));
            string carID = GetCarID(carIndex);
            Response.Redirect("Car Details.aspx?carid=" + carID + "&userid=" + int.Parse(Request.QueryString["id"]));
        }
        private string GetCarID(int index)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT c.car_id FROM Car c INNER JOIN car_image ci ON c.car_id = ci.car_id GROUP BY c.car_id, c.make, c.model, c.year, c.location, c.price, c.is_available ORDER BY c.car_id";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    if (counter == index)
                    {
                        string carID = reader["car_id"].ToString();
                        reader.Close();
                        return carID;
                    }
                    counter++;
                }
                reader.Close();
                return null;
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            carsPanel.Controls.Clear();
            string date = datefilter.Value;
            string location = locationfilter.Value;
            string priceMin = p1.Value;
            string priceMax = p2.Value;

            string carName = carfilter.Value;

            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT c.car_id,c.make, c.model, c.year, c.location, c.price, c.is_available, MAX(ci.image_url) AS image_url FROM Car c INNER JOIN car_image ci ON c.car_id = ci.car_id  WHERE 1 = 1";

                if (!string.IsNullOrEmpty(date))
                {
                    query += " AND @Date between start_date and end_date";
                }
                if (!string.IsNullOrEmpty(location))
                {
                    query += " AND c.location like '%'+@Location + '%'";
                }
                if (priceMin!="0" && !priceMin.IsNullOrWhiteSpace() )
                {
                    query += " AND c.price>=@PriceMin";
                }
                if (priceMax!="0" &&!priceMax.IsNullOrWhiteSpace())
                {
                    query += " AND c.price<=@PriceMax";
                }
                if (!string.IsNullOrEmpty(carName))
                {
                    query += " AND c.make LIKE '%'+ @CarName + '%' OR c.model LIKE '%'+ @CarName + '%' OR c.make+' '+c.model like '%'+ @CarName + '%' ";
                }
                query = query + "  GROUP BY c.car_id, c.make, c.model, c.year, c.location, c.price, c.is_available";
                SqlCommand cmd = new SqlCommand(query, con);

                if (!string.IsNullOrEmpty(date))
                {
                    cmd.Parameters.AddWithValue("@Date", date);
                }
                if (!string.IsNullOrEmpty(location))
                {
                    cmd.Parameters.AddWithValue("@Location", location);
                }
                if (!string.IsNullOrEmpty(priceMin) && !string.IsNullOrEmpty(priceMax))
                {
                    cmd.Parameters.AddWithValue("@PriceMin", priceMin);
                    cmd.Parameters.AddWithValue("@PriceMax", priceMax);
                }
                if (!string.IsNullOrEmpty(carName))
                {
                    cmd.Parameters.AddWithValue("@CarName", carName);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    string make = reader["make"].ToString();
                    string model = reader["model"].ToString();
                    int year = Convert.ToInt32(reader["year"]);
                    string location2 = reader["location"].ToString();
                    decimal price = Convert.ToDecimal(reader["price"]);
                    bool isAvailable = Convert.ToBoolean(reader["is_available"]);
                    byte[] imageBytes = (byte[])reader["image_url"];
                    string base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                    string imageUrl = string.Format("data:image/jpeg;base64,{0}", base64String);

                    // Filter the results based on search parameters
                    if ((!string.IsNullOrEmpty(Request.QueryString["date"]) && Request.QueryString["date"] != Convert.ToDateTime(reader["date"]).ToString("yyyy-MM-dd"))
                        || (!string.IsNullOrEmpty(Request.QueryString["location"]) && Request.QueryString["location"] != reader["location"].ToString())
                        || (!string.IsNullOrEmpty(Request.QueryString["price-min"]) && Convert.ToDecimal(Request.QueryString["price-min"]) > Convert.ToDecimal(reader["price"]))
                        || (!string.IsNullOrEmpty(Request.QueryString["price-max"]) && Convert.ToDecimal(Request.QueryString["price-max"]) < Convert.ToDecimal(reader["price"]))
                        || (!string.IsNullOrEmpty(Request.QueryString["car-name"]) && !make.ToLower().Contains(Request.QueryString["car-name"].ToLower()) && !model.ToLower().Contains(Request.QueryString["car-name"].ToLower())))
                    {
                        continue; // Skip this result if it doesn't match the search parameters
                    }

                    Panel carPanel = new Panel();
                    carPanel.CssClass = "car1";

                    Panel carHeaderPanel = new Panel();
                    carHeaderPanel.CssClass = "carHeader";

                    Label makeModelLabel = new Label();
                    makeModelLabel.Text = string.Format("{0} {1}", make, model);
                    carHeaderPanel.Controls.Add(makeModelLabel);

                    Label availabilityLabel = new Label();
                    availabilityLabel.Text = isAvailable ? "Available" : "Not Available";
                    carHeaderPanel.Controls.Add(availabilityLabel);

                    carPanel.Controls.Add(carHeaderPanel);

                    Image carImage = new Image();
                    carImage.ImageUrl = imageUrl;
                    carPanel.Controls.Add(carImage);

                    Panel carFooterPanel = new Panel();
                    carFooterPanel.CssClass = "carFooter";

                    Label priceLabel = new Label();
                    priceLabel.Text = string.Format("<strong>Price per Hour:</strong> {0:N} PKR", price);
                    carFooterPanel.Controls.Add(priceLabel);

                    carPanel.Controls.Add(carFooterPanel);

                    Button reviewButton = new Button();
                    reviewButton.Text = "Review";
                    reviewButton.ID = "ReviewButton" + counter;
                    reviewButton.CssClass = "btn-review"; // add CSS class
                    reviewButton.Click += new EventHandler(ReviewButton_Click);
                    carPanel.Controls.Add(reviewButton);

                    Button detailsButton = new Button();
                    detailsButton.Text = "See Details";
                    detailsButton.ID = "sdf" + counter;
                    detailsButton.CssClass = "btn-details"; // add CSS class
                    detailsButton.Click += new EventHandler(DetailsButton_Click);
                    carPanel.Controls.Add(detailsButton);

                    counter++;
                    
                    carsPanel.Controls.Add(carPanel);
                }

                if (counter == 0)
                {
                    Label noResultsLabel = new Label();
                    noResultsLabel.Text = "No results found.";
                    carsPanel.Controls.Add(noResultsLabel);
                }
            }
            }

    }
    }