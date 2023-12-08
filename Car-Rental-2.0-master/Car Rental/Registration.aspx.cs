using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Messaging;

namespace Car_Rental
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void  Reg_Click(object sender, EventArgs e)
        {
            string emailQuery = "SELECT COUNT(*) FROM user_ WHERE email = @email";
            string usernameQuery = "SELECT COUNT(*) FROM user_ WHERE username = @username";
            int emailCount=0;
            int usercount=0;
            String constr = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);           
            try
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(emailQuery, con))
                {
                    command.Parameters.AddWithValue("@email", email.Value.ToString());
                     emailCount = (int)command.ExecuteScalar();
                    
                }
                using (SqlCommand command = new SqlCommand(usernameQuery, con))
                {
                    command.Parameters.AddWithValue("@username", username.Value.ToString());
                    usercount = (int)command.ExecuteScalar();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

      

            if (password1.Value.ToString() != confirmpassword.Value.ToString())
            {
                Response.Write("<script>alert('Password does not matches')</script>");
            }
            else if (emailCount > 0)
            {
                Response.Write("<script>alert('This Email Already Exists Use Another Email')</script>");
            }
            else if (usercount > 0)
            {
                Response.Write("<script>alert('This Username Already Exists Use Another Username')</script>");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select max(user_id) from user_", con);
                    int index;
                    index = (int)cmd.ExecuteScalar();
                    index++;                   
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO USER_(user_id, username, password, email, phone_number) VALUES("+index.ToString()+",'"+username.Value.ToString()+"','"+ password1.Value.ToString()+"', '"+email.Value.ToString()+"', '"+phone.Value.ToString()+"')",con);
                    cmd2.ExecuteNonQuery();
                    Response.Write("<script>alert('Account Created')</script>");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }

            }
    }
}