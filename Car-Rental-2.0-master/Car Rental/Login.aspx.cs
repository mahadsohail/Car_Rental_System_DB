using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Web.Configuration;

namespace Car_Rental
{
    public partial class _Default : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void Log_Click(object sender, EventArgs e)
        {
            String constr = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection con =new SqlConnection(constr);
            try
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from user_ where username='"+username1.Value.ToString()+"' and password="+"'"+pass1.Value.ToString()+"'",con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
               
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cmd.ExecuteNonQuery();
                if (dt.Rows[0][0].ToString()=="1")
                {
                    int myUserIdVariable;
                    //Server.Transfer("");
                    string query = "SELECT user_id FROM user_ WHERE username = @username AND password = @password";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@username", username1.Value.ToString());
                        command.Parameters.AddWithValue("@password", pass1.Value.ToString());
                        int userId = (int)command.ExecuteScalar();
                        myUserIdVariable = userId;
                    }
                    Response.Redirect("home.aspx?id="+myUserIdVariable.ToString());
                }
                else
                { 
                   Response.Write("<script>alert('Wrong Credentials')</script>");
                }
            }
            catch (Exception ex) 
            { 
                Response.Write(ex.ToString());
             }            
           
        }


    }
}