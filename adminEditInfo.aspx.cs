using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace KingstonBankl
{
    public partial class adminEditInfo : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Prevent reloading on postback
            {
                if (Session["user_ID"] != null)
                {
                    string userID = Session["user_ID"].ToString();
                    getUserByID(userID); // Load user details
                }
                else
                {
                    Response.Write("<script>alert('No user selected.');</script>");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EditAccount();
            EditCard();
        }

        void getUserByID(string userID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    // Get User Details
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_users WHERE user_ID=@userID", con);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txtUserID.Text = dr["user_ID"].ToString();
                            txtName.Text = dr["name"].ToString();
                            txtSurname.Text = dr["surname"].ToString();
                            txtID.Text = dr["ID_number"].ToString();
                            txtCellNumber.Text = dr["cell_number"].ToString();
                            txtEmail.Text = dr["email"].ToString();
                            txtBirthDate.Text = dr["birth_date"].ToString();
                            txtMaritalStatus.Text = dr["marital_status"].ToString();
                            txtAddress.Text = dr["home_address"].ToString();
                            txtCitizenship.Text = dr["citizenship"].ToString();
                        }
                    }
                    dr.Close(); // Close first reader before executing next query

                    // Get Account Number using user_ID
                    cmd = new SqlCommand("SELECT account_number FROM Accounts WHERE user_ID=@userID", con);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    string accountNumber = "";
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            accountNumber = dr["account_number"].ToString();
                            txtAccontNo.Text = accountNumber; // Fill Account No field
                        }
                    }
                    dr.Close();

                    if (!string.IsNullOrEmpty(accountNumber))
                    {
                        // Get Card Details using account_number
                        cmd = new SqlCommand("SELECT * FROM Tbl_card WHERE account_number=@account_number", con);
                        cmd.Parameters.AddWithValue("@account_number", accountNumber);

                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                txtCardNumber.Text = dr["card_number"].ToString();
                                txtSecurityCode.Text = dr["security_code"].ToString();
                                txtValidthru.Text = dr["valid_thru"].ToString();
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('No card details found for this account.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('No account found for this user.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        void EditAccount()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Accounts SET account_number=@account_number WHERE user_ID=@userID", con);

                    cmd.Parameters.AddWithValue("@account_number", txtAccontNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@userID", txtUserID.Text.Trim()); // Use user_ID from textbox

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Account updated successfully!');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Update failed. Try again!');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error: " + ex.Message.Replace("'", "\\'") + "');", true);
            }
        }

        void EditCard()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Tbl_card SET account_number=@account_number, card_number=@card_number, security_code=@security_code, valid_thru=@valid_thru WHERE account_number=@account_number", con);

                    cmd.Parameters.AddWithValue("@card_number", txtCardNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@security_code", txtSecurityCode.Text.Trim());
                    cmd.Parameters.AddWithValue("@valid_thru", txtValidthru.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Profile updated successfully!');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Update failed. Try again!');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
    }
}