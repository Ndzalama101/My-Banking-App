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
    public partial class UserPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Prevent reload on postbacks
            {
                if (Session["user_ID"] != null)
                {
                    getUserByID(Session["user_ID"].ToString());
                    getAccount(Session["user_ID"].ToString());
                    BindUserAccounts(); // Ensure this is called with correct user_ID
                    GridView1.DataBind();
                }
                else
                {
                    Response.Redirect("Login.aspx"); // Prevent unauthorized access
                }
            }
        }


        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        //search button
        protected void Button2_Click(object sender, EventArgs e)
        {
            getAccount(Session["user_ID"].ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userID = Session["user_ID"].ToString(); // Get the current user ID from the session
            Response.Redirect("~/TransactionsPage.aspx?UserID=" + userID); // Pass UserID to TransactionsPage
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAccount();
        }

        protected void btnDeposit_Click(object sender, EventArgs e)
        {
            string userID = Session["user_ID"].ToString();
            if (decimal.TryParse(txtBalance.Text.Trim(), out decimal amount) && amount > 0)
            {
                DepositMoney(amount);
                BindUserAccounts();
            }
            else
            {
                Response.Write("<script>alert('Please enter a valid positive amount.');</script>");
            }


        }

        protected void btnWithdraw_Click(object sender, EventArgs e)
        {
            string userID = Session["user_ID"].ToString();
            if (decimal.TryParse(txtBalance.Text.Trim(), out decimal amount) && amount > 0)
            {
                WithdrawMoney(amount);
                BindUserAccounts();
            }
            else
            {
                Response.Write("<script>alert('Enter a valid amount');</script>");
            }
        }



        protected void btnEditInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserEditInfoPage.aspx");

        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            decimal transferAmount;
            string sourceAccount = txtFrom.Text.Trim();
            string destinationAccount = txtTo.Text.Trim();

            // Validate transfer amount input
            if (!decimal.TryParse(txtAmount.Text.Trim(), out transferAmount) || transferAmount <= 0)
            {
                Response.Write("<script>alert('Enter a valid amount greater than zero.');</script>");
                return;
            }

            // Check if source and destination accounts are valid
            if (string.IsNullOrEmpty(sourceAccount) || string.IsNullOrEmpty(destinationAccount))
            {
                Response.Write("<script>alert('Please enter both source and destination account numbers.');</script>");
                return;
            }

            // Start the transfer process
            TransferMoney(sourceAccount, destinationAccount, transferAmount);
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
                            txtAccountNumber.Text = dr["account_number"].ToString();
                            txtBalance.Text = dr["balance"].ToString();
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
            }
        }


        void BindUserAccounts()
        {
            try
            {
                if (Session["user_ID"] == null)
                {
                    Response.Redirect("Login.aspx"); // Redirect if session expires
                    return;
                }

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Accounts WHERE user_ID = @userID", con);
                    cmd.Parameters.AddWithValue("@userID", Session["user_ID"].ToString());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt; // Set DataSource before binding
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }



        void getAccount(string userID)
        {


            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Accounts WHERE user_ID=@userID", con);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txtBalance.Text = dr["balance"].ToString();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('You can only view your own account!');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }

        }




        void DeleteAccount()
        {
            if (CheckIfAccountExist())
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open(); // Ensure connection is opened

                        // Delete related records in Tbl_card table first
                        SqlCommand cmdDeleteCards = new SqlCommand("DELETE FROM Tbl_card WHERE account_number = @account_number", con);
                        cmdDeleteCards.Parameters.AddWithValue("@account_number", txtAccountNumber.Text.Trim());
                        cmdDeleteCards.ExecuteNonQuery();

                        // Step 1: Delete related transactions from tbl_transactions
                        SqlCommand cmdDeleteTransactions = new SqlCommand("DELETE FROM tbl_transactions WHERE account_number = @account_number", con);
                        cmdDeleteTransactions.Parameters.AddWithValue("@account_number", txtAccountNumber.Text.Trim());
                        cmdDeleteTransactions.ExecuteNonQuery();

                        // Then delete the account from Accounts table
                        SqlCommand cmdDeleteAccount = new SqlCommand("DELETE FROM Accounts WHERE account_number = @account_number", con);
                        cmdDeleteAccount.Parameters.AddWithValue("@account_number", txtAccountNumber.Text.Trim());
                        int rowsAffected = cmdDeleteAccount.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Account deleted successfully');</script>");
                            ClearForm();
                            // After deleting, rebind the remaining accounts for the logged-in user
                            BindRemainingAccounts(Session["user_ID"].ToString());
                        }
                        else
                        {
                            Response.Write("<script>alert('Error: Account not found');</script>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Account Number');</script>");
            }
        }

        void BindRemainingAccounts(string userID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    // Fetch only accounts related to the logged-in user
                    SqlCommand cmd = new SqlCommand("SELECT [Name], [account_number], [balance] FROM [Accounts] WHERE user_ID = @user_ID", con);
                    cmd.Parameters.AddWithValue("@user_ID", userID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind remaining accounts to GridView
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error fetching accounts: " + ex.Message + "');</script>");
            }
        }




        bool CheckIfAccountExist()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from Accounts where account_number='" + txtAccountNumber.Text.Trim() + "';", con);
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


        void DepositMoney(decimal amount)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE Accounts SET balance = balance + @amount WHERE account_number = @account_number", con);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@account_number", txtAccountNumber.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        SaveTransaction(txtAccountNumber.Text.Trim(), amount, "Deposit");
                  

                        Response.Write("<script>alert('Deposit successful!');</script>");
                        getAccount(Session["user_ID"].ToString()); // Refresh balance
                        ClearForm();
                        GridView1.DataBind();
                    }
                    else
                    {
                        Response.Write("<script>alert('Deposit failed. Account not found.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        void WithdrawMoney(decimal amount)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    // Check balance before withdrawal
                    SqlCommand checkCmd = new SqlCommand("SELECT balance FROM Accounts WHERE account_number = @account_number", con);
                    checkCmd.Parameters.AddWithValue("@account_number", txtAccountNumber.Text.Trim());

                    object result = checkCmd.ExecuteScalar();

                    if (result != null && decimal.TryParse(result.ToString(), out decimal currentBalance))
                    {
                        if (currentBalance >= amount)
                        {
                            // Perform withdrawal
                            SqlCommand cmd = new SqlCommand("UPDATE Accounts SET balance = balance - @amount WHERE account_number = @account_number", con);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@account_number", txtAccountNumber.Text.Trim());

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                SaveTransaction(txtAccountNumber.Text.Trim(), -amount, "Withdrawal");

                                Response.Write("<script>alert('Withdrawal successful!');</script>");
                                getAccount(Session["user_ID"].ToString()); // Refresh balance
                                ClearForm();
                                GridView1.DataBind();
                            }
                            else
                            {
                                Response.Write("<script>alert('Withdrawal failed. Account not found.');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Insufficient balance.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid account.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }


        void TransferMoney(string sourceAccount, string destinationAccount, decimal amount)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    // Check if both accounts exist
                    SqlCommand checkSourceCmd = new SqlCommand("SELECT balance, user_ID FROM Accounts WHERE account_number = @account_number", con);
                    checkSourceCmd.Parameters.AddWithValue("@account_number", sourceAccount);
                    SqlDataReader sourceReader = checkSourceCmd.ExecuteReader();

                    if (!sourceReader.Read())
                    {
                        Response.Write("<script>alert('Source account not found.');</script>");
                        return;
                    }
                    decimal sourceBalance = sourceReader.GetDecimal(sourceReader.GetOrdinal("balance"));
                    string sourceUserID = sourceReader.GetString(sourceReader.GetOrdinal("user_ID"));
                    sourceReader.Close();

                    SqlCommand checkDestinationCmd = new SqlCommand("SELECT balance, user_ID FROM Accounts WHERE account_number = @account_number", con);
                    checkDestinationCmd.Parameters.AddWithValue("@account_number", destinationAccount);
                    SqlDataReader destinationReader = checkDestinationCmd.ExecuteReader();

                    if (!destinationReader.Read())
                    {
                        Response.Write("<script>alert('Destination account not found.');</script>");
                        return;
                    }
                    decimal destinationBalance = destinationReader.GetDecimal(destinationReader.GetOrdinal("balance"));
                    string destinationUserID = destinationReader.GetString(destinationReader.GetOrdinal("user_ID"));
                    destinationReader.Close();

                    // Check if source account has enough funds
                    if (sourceBalance < amount)
                    {
                        Response.Write("<script>alert('Insufficient funds in source account.');</script>");
                        return;
                    }

                    // Begin a transaction to ensure atomicity
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            // Update the source account (subtract the amount)
                            SqlCommand updateSourceCmd = new SqlCommand("UPDATE Accounts SET balance = balance - @amount WHERE account_number = @account_number", con, transaction);
                            updateSourceCmd.Parameters.AddWithValue("@amount", amount);
                            updateSourceCmd.Parameters.AddWithValue("@account_number", sourceAccount);
                            updateSourceCmd.ExecuteNonQuery();

                            // Update the destination account (add the amount)
                            SqlCommand updateDestinationCmd = new SqlCommand("UPDATE Accounts SET balance = balance + @amount WHERE account_number = @account_number", con, transaction);
                            updateDestinationCmd.Parameters.AddWithValue("@amount", amount);
                            updateDestinationCmd.Parameters.AddWithValue("@account_number", destinationAccount);
                            updateDestinationCmd.ExecuteNonQuery();

                            // Save the transaction for sender (negative amount)
                            SaveTransactionTransfer(sourceUserID, sourceAccount, -amount, "Transfer to " + destinationAccount, con, transaction);

                            // Save the transaction for receiver (positive amount)
                            SaveTransactionTransfer(destinationUserID, destinationAccount, amount, "Transfer from " + sourceAccount, con, transaction);

                            // Commit the transaction
                            transaction.Commit();
                            Response.Write("<script>alert('Transfer successful!');</script>");
                            ClearForm();  // Optionally clear the form after successful transfer
                            GridView1.DataBind();  // Refresh the account details (if necessary)
                            BindUserAccounts();
                        }
                        catch (Exception ex)
                        {
                            // If an error occurs, roll back the transaction
                            transaction.Rollback();
                            Response.Write("<script>alert('Transfer failed: " + ex.Message + "');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }


        public void SaveTransaction(string accountNumber, decimal amount, string transactionDescription)
        {
            try
            {

                // Retrieve User_Id from the session
                string userId = Session["user_ID"].ToString();

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    // Update the SQL query to include User_Id
                    string insertQuery = "INSERT INTO tbl_transactions (account_number, TransactionDate, Amount, TransactionDescription, user_ID) " +
                                         "VALUES (@accountNumber, @TransactionDate, @Amount, @TransactionDescription, @user_ID)";

                    SqlCommand cmd = new SqlCommand(insertQuery, con);
                    cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                    cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@TransactionDescription", transactionDescription);
                    cmd.Parameters.AddWithValue("@user_ID", userId); // Add User_Id parameter


                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Handle exception (logging or user notification can be added here)
                Response.Write("<script>alert('Error: " + ex.Message.Replace("'", "") + "');</script>");
            }

        }

        void SaveTransactionTransfer(string userID, string accountNumber, decimal amount, string description, SqlConnection con, SqlTransaction transaction)
        {
            try
            {
                // SQL query to insert a transaction record
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_transactions (user_ID, account_number, Amount, TransactionDescription, TransactionDate) VALUES (@userID, @accountNumber, @Amount, @Description, @TransactionDate)", con, transaction);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now); // Current timestamp for transaction date

                // Execute the insert command
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error saving transaction: " + ex.Message + "');</script>");
            }
        }


        void ClearForm()
        {
            txtAccountNumber.Text = "";
            txtBalance.Text = "";
            txtFrom.Text = "";
            txtTo.Text = "";
            txtAmount.Text = "";
        }



    }
}