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
    public partial class adminHomePage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getUserByID();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteMemberById();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text.Trim(); // Get user ID from textbox or selected row
            if (!string.IsNullOrEmpty(userID))
            {
                Session["user_ID"] = userID; // Store user ID in Session
                Response.Redirect("adminEditInfo.aspx"); // Navigate to the edit page
            }
            else
            {
                Response.Write("<script>alert('No user selected!');</script>");
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            saveAccount();
            saveCard();
        }


        //function for checking if user exist

        void getUserByID()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from Tbl_users where user_ID='" + txtUserID.Text.Trim() + "';", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txtName.Text = dr.GetValue(1).ToString();
                            txtSurname.Text = dr.GetValue(2).ToString();
                            txtID.Text = dr.GetValue(3).ToString();
                            txtCellNumber.Text = dr.GetValue(4).ToString();
                            txtEmail.Text = dr.GetValue(5).ToString();
                            txtBirthDate.Text = dr.GetValue(6).ToString();
                            txtMaritalStatus.Text = dr.GetValue(7).ToString();
                            txtAddress.Text = dr.GetValue(8).ToString();
                            txtCitizenship.Text = dr.GetValue(9).ToString();
                            txtPassword.Text = dr.GetValue(10).ToString();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid User ID'); </script>");
                    }
                }


            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }

        }

        void DeleteMemberById()
        {
            if (CheckIfUserExist())
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();

                        // First, delete the associated card(s)
                        SqlCommand cmdDeleteCard = new SqlCommand("DELETE FROM Tbl_card WHERE account_number IN (SELECT account_number FROM Accounts WHERE user_ID = @user_ID);", con);
                        cmdDeleteCard.Parameters.AddWithValue("@user_ID", txtUserID.Text.Trim());
                        cmdDeleteCard.ExecuteNonQuery();

                        // Then, delete the associated account(s)
                        SqlCommand cmdDeleteAccount = new SqlCommand("DELETE FROM Accounts WHERE user_ID = @user_ID;", con);
                        cmdDeleteAccount.Parameters.AddWithValue("@user_ID", txtUserID.Text.Trim());
                        cmdDeleteAccount.ExecuteNonQuery();

                        // Finally, delete the user
                        SqlCommand cmdDeleteUser = new SqlCommand("DELETE FROM Tbl_users WHERE user_ID = @user_ID;", con);
                        cmdDeleteUser.Parameters.AddWithValue("@user_ID", txtUserID.Text.Trim());
                        cmdDeleteUser.ExecuteNonQuery();

                        con.Close();

                        Response.Write("<script>alert('Member and associated records deleted successfully');</script>");
                        ClearForm();
                        GridView1.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }

        bool CheckIfUserExist()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from Tbl_users where user_ID='" + txtUserID.Text.Trim() + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


            }
            catch (Exception ex)
            {

                return false;
            }
        }

        void ClearForm()
        {
            txtUserID.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtID.Text = "";
            txtCellNumber.Text = "";
            txtEmail.Text = "";
            txtBirthDate.Text = "";
            txtMaritalStatus.Text = "";
            txtAddress.Text = "";
            txtCitizenship.Text = "";
            txtPassword.Text = "";

        }

        void saveAccount()
        {
            if (!CheckIfUserExist())
            {
                Response.Write("<script>alert('User ID does not exist!');</script>");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Accounts (user_ID, account_number, activation_date,balance,Name) VALUES (@user_ID, @account_number, @activation_date,0.00,@name)", con);

                    cmd.Parameters.AddWithValue("@user_ID", txtUserID.Text.Trim());
                    cmd.Parameters.AddWithValue("@account_number", txtAccountNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@activation_date", txtActivationDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", txtAccountName.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();


                    if (rowsAffected > 0)
                    {

                        Response.Write("<script>alert('Account created successfully!');</script>");
                        ClearForm();
                    }
                    else
                    {
                        Response.Write("<script>alert('Account creation failed. Please try again.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        void saveCard()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_card (account_number, valid_thru, security_code, card_number) VALUES (@account_number, @valid_thru, @security_code, @card_number)", con);

                    cmd.Parameters.AddWithValue("@account_number", txtAccountNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@valid_thru", txtValidThru.Text.Trim());
                    cmd.Parameters.AddWithValue("@security_code", txtSecurityCode.Text.Trim());
                    cmd.Parameters.AddWithValue("@card_number", txtCardNumber.Text.Trim());


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        Response.Write("<script>alert('Card created successfully!');</script>");
                        ClearForm();
                    }
                    else
                    {
                        Response.Write("<script>alert('Card creation failed. Please try again.');</script>");
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