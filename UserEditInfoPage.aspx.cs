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
    public partial class UserEditInfoPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Prevent loading again on postbacks
            {
                if (Session["user_ID"] != null)
                {
                    getUserByID(Session["user_ID"].ToString()); // Retrieve user info using session
                }

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            EditInfo();
        }

        void getUserByID(string userID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
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
                            txtPassword.Text = dr["password"].ToString();


                        }

                    }
                    else
                    {
                        Response.Write("<script>alert('User not found!');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }


        void EditInfo()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Tbl_users SET name=@name, surname=@surname, ID_number=@id, cell_number=@cell, email=@Email, birth_date=@birthDate, marital_status=@maritalStatus, home_address=@address, citizenship=@citizenship, password=@password WHERE user_ID=@userID", con);

                    cmd.Parameters.AddWithValue("@userID", txtUserID.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@surname", txtSurname.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@cell", txtCellNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@birthDate", txtBirthDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@maritalStatus", txtMaritalStatus.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@citizenship", txtCitizenship.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

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