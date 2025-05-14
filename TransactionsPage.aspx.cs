using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KingstonBankl
{
    public partial class TransactionsPage : System.Web.UI.Page
    {
        string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_ID"] != null)
            {
                BindUserTransactions(Session["user_ID"].ToString());

            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }


        void BindUserTransactions(string userID)
        {
            try
            {
                if (string.IsNullOrEmpty(userID))
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    // Fetch only transactions related to the logged-in user
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_transactions WHERE user_ID = @userID", con);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        Response.Write("<script>alert('No transactions found for your account.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserPage.aspx");
        }
    }
}