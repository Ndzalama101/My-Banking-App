<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="KingstonBankl.RegistrationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section id="RegistrationSection" class="d-flex justify-content-center align-items-center vh-100">
        <div class="card p-4 shadow-lg" style="width: 40rem;">
            <center><h1>Account Registration</h1></center>
            <div class="card-body">
                <!-- Row 1 -->
                <div class="row">
                <div class="col-md-6 d-flex">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtName" class="form-label">Name</label>
                        <asp:TextBox ID="txtName" CssClass="form-control" placeholder="Name" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 d-flex">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtSurname" class="form-label">Surname</label>
                        <asp:TextBox ID="txtSurname" CssClass="form-control" placeholder="Surname" runat="server"></asp:TextBox>
                    </div>
                </div>
                </div>

                <!-- Row 2 -->
                <div class="row">
                <div class="col-md-6 d-fle">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtBirthDate" class="form-label">Date Of Birth</label>
                        <asp:TextBox ID="txtBirthDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 d-fle">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtID" class="form-label">ID/ Passport Number</label>
                        <asp:TextBox ID="txtID" CssClass="form-control" placeholder="0408026220082" runat="server" TextMode="Number"  MaxLenght="13"></asp:TextBox>
                    </div>
                </div>
                </div>
                <!-- Row 3 -->
                <div class="row">
                <div class="col-md-6 d-fle">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtCellNumber" class="form-label">Cell Number</label>
                        <asp:TextBox ID="txtCellNumber" CssClass="form-control" placeholder="0796982034" runat="server" Textmode="Number"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 d-fle">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtEmail" class="form-label">Email</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Shawnmbhalati@gmail.com" runat="server" TextMode="Email"></asp:TextBox>
                    </div>
                </div>
                 </div>

                <!-- Row 4 -->
                <div class="row">
                <div class="col-md-6 d-fle">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="DropDownList1" class="form-label">Citizenship</label>
                        <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                            <asp:ListItem Text="**Select Citizenship**" Value="" />
                            <asp:ListItem Text="South African" Value="1" />
                            <asp:ListItem Text="Indian" Value="2" />
                            <asp:ListItem Text="USA" Value="3" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6 d-fle">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="DropDownListMaritalStatus" class="form-label">Marital Status</label>
                        <asp:DropDownList ID="DropDownListMaritalStatus" CssClass="form-control" runat="server">
                            <asp:ListItem Text="**Select Marital Status**" Value="" />
                            <asp:ListItem Text="Single" Value="1" />
                            <asp:ListItem Text="Married" Value="2" />
                            <asp:ListItem Text="Divorced" Value="3" />
                        </asp:DropDownList>
                    </div>
                </div>
               </div>


                <!-- Row 5 -->
                <div class="col-md-6 d-fle">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtAddress" class="form-label">Home Address</label>
                        <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>

                <span class="badge bg-primary mb-3">Login Details</span>

                <!-- Row 6 -->
                <div class="row">
                <div class="col-md-6 d-fle">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtUserID" class="form-label">User ID</label>
                        <asp:TextBox ID="txtUserID" CssClass="form-control" placeholder="User ID" runat="server" MinLength="6" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 d-fle">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtPassword" class="form-label">Password</label>
                        <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password" MinLength="6" ></asp:TextBox>
                    </div>
                </div>
                 </div>

                <!-- Submit Button -->
                <div class="row mt-3">
                    <div class="col-md-12">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success w-100" Text="Sign Up"  OnClick="Button1_Click" />
                    </div>
                </div>
            </div><!-- card body -->
        </div><!-- card -->
    </section>

    <center>
        <div class="mt-3">
            <a href="index.aspx">&laquo; Back to Home</a>
        </div>
    </center>



</asp:Content>
