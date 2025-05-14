using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KingstonBankl
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //sign up button clicked
        protected void Button1_Click(object sender, EventArgs e)
        {


            if (checkMemberExists())
            {
                Response.Write("<script>alert('Member already exists with this ID, try another');</script>");
            }
            else
            {

                signUpNewUser();

            }


        }

        bool checkMemberExists()
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

        void signUpNewUser()
        {

            try
            {

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand("insert into Tbl_users  (name, surname, birth_date, ID_number,cell_number, email, citizenship, marital_status, home_address, user_ID, Password) " +
                        "VALUES  (@name, @surname, @birth_date, @ID_number, @cell_number, @email, @citizenship, @marital_status, @home_address, @user_ID, @Password)", con);
                    // Add parameters

                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@surname", txtSurname.Text.Trim());
                    cmd.Parameters.AddWithValue("@birth_date", txtBirthDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@ID_number", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@cell_number", txtCellNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@citizenship", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@marital_status", DropDownListMaritalStatus.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@home_address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@user_ID", txtUserID.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login'); </script>");
                    Response.Redirect("LoginPage.aspx");


                    // Execute query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the operation was successful
                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");

                    }
                    else
                    {
                        Response.Write("<script>alert('Sign Up Failed. Please try again.');</script>");
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