using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KingstonBankl
{
    public partial class LoginPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_ID"] != null)
            {
                // If user is already logged in, redirect to the User Page
                Response.Redirect("UserPage.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_users WHERE user_ID=@userID AND Password=@password", con);
                    cmd.Parameters.AddWithValue("@userID", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            // Store User ID in Session
                            Session["user_ID"] = dr["user_ID"].ToString();
                            Session["name"] = dr["name"].ToString();
                        }

                        Response.Redirect("UserPage.aspx");
                    }
                    else
                    {
                        // lblMessage.Text = "Invalid credentials!";
                        Response.Write("<script>alert('Invalid credentials');</script>");

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrationPage.aspx");  // Redirect to Sign Up page
        }
    }
}