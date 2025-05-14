<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="adminHomePage.aspx.cs" Inherits="KingstonBankl.adminHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <!-- Member Details Section -->
            <div class="col-md-6">
                <div class="card shadow-lg p-3">
                    <div class="card-body">
                        <center>
                            <img src="img/User%20avatar%20icon,%20button,%20profile%20symbol,%20flat%20person%20icon_%20Circle%20button%20with%20avatar%20photo_.jpeg" width="80" height="80" />
                            <h1 class="mt-2">Update Personal Info</h1>
                        </center>

                        <!-- User Info Form -->
                        <div class="row">
                            <div class="col-md-6">
                                <label for="txtName" class="form-label">Name</label>
                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtSurname" class="form-label">Surname</label>
                                <asp:TextBox ID="txtSurname" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Additional Rows -->
                        <div class="row mt-3">
                            <div class="col-md-6">
                                <label for="txtBirthDate" class="form-label">Date Of Birth</label>
                                <asp:TextBox ID="txtBirthDate" CssClass="form-control" runat="server" TextMode="Date" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtID" class="form-label">ID/Passport Number</label>
                                <asp:TextBox ID="txtID" CssClass="form-control" runat="server" TextMode="Number" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mt-3">
                            <div class="col-md-6">
                                <label for="txtCellNumber" class="form-label">Cell Number</label>
                                <asp:TextBox ID="txtCellNumber" CssClass="form-control" runat="server" MaxLength="10" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtEmail" class="form-label">Email</label>
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mt-3">
                            <div class="col-md-6">
                                <label for="txtCitizenship" class="form-label">Citizenship</label>
                                <asp:TextBox ID="txtCitizenship"  runat="server"  ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                  <label for="txtMaritalStatus" class="form-label">Marital Status</label>
                                 <asp:TextBox ID="txtMaritalStatus"  runat="server"  ReadOnly="True"></asp:TextBox>   
                            </div>
                        </div> 

                        <div class="row mt-3">
                            <div class="col-md-12">
                                <label for="txtAddress" class="form-label">Home Address</label>
                                <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                        <span class="badge bg-primary mt-3">Login Details</span>

                        <div class="row mt-3">
                            <div class="col-md-6">
                               <div class="input-group">
                                    <label for="TextBox1" class="form-label">User ID</label>
                                    <asp:TextBox ID="txtUserID" placeholder="user ID" runat="server"></asp:TextBox>
                                    <asp:Button CssClass="btn btn-primary" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />  
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="txtPassword" class="form-label">Password</label>
                                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Buttons -->
                        <div class="row mt-4">
                            <div class="col-md-6">
                                <asp:Button CssClass="btn btn-danger w-100" ID="btnDelete" runat="server" Text="Delete User" OnClick="btnDelete_Click" />
                            </div>
                            <div class="col-md-6">
                                <asp:Button ID="btnEdit" CssClass="btn btn-primary w-100" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Member List Section -->
            <div class="col-md-6">
                <div class="card shadow-lg p-3">
                    <div class="card-body">
                        <h1 class="text-center">Member List</h1>
                        <hr />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" CssClass="table table-success table-bordered table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="user_ID" DataSourceID="SqlDataSource1">
                                <Columns>
                                    <asp:BoundField DataField="user_ID" HeaderText="User ID" ReadOnly="True" />
                                    <asp:BoundField DataField="name" HeaderText="Name" />
                                    <asp:BoundField DataField="surname" HeaderText="Surname" />
                                    <asp:BoundField DataField="ID_number" HeaderText="ID Number" />
                                    <asp:BoundField DataField="cell_number" HeaderText="Cell Number" />
                                    <asp:BoundField DataField="email" HeaderText="Email" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Bang_BankConnectionString %>" SelectCommand="SELECT [user_ID], [name], [surname], [ID_number], [cell_number], [email] FROM [Tbl_users]"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow-lg p-4">
                    <div class="card-body">
                        <center>
                            <h2 class="mb-4">Create Account for User</h2>
                        </center>

                        <!-- Row 1 -->
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label for="txtCardNumber" class="form-label">Card Number</label>
                                <asp:TextBox ID="txtCardNumber" CssClass="form-control" runat="server" MinLength="16" MaxLength="16" ></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtAccountNumber" class="form-label">Account Number</label>
                                <asp:TextBox ID="txtAccountNumber" CssClass="form-control" runat="server" MinLength="10" MaxLength="10" ></asp:TextBox>
                            </div>
                        </div>

                        <!-- Row 2 -->
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label for="txtActivationDate" class="form-label">Activation Date</label>
                                <asp:TextBox ID="txtActivationDate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtValidThru" class="form-label">Valid Thru</label>
                                <asp:TextBox ID="txtValidThru" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Row 3 -->
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label for="txtSecurityCode" class="form-label">Security Code</label>
                                <asp:TextBox ID="txtSecurityCode" CssClass="form-control" runat="server" MinLength="3" MaxLength="3"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtAccountName" class="form-label">Account Name</label>
                                <asp:TextBox ID="txtAccountName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Button Row -->
                        <div class="row mt-4 text-center">
                            <div class="col-12">
                                <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="Save Account Details" OnClick="Button1_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>




