<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserEditInfoPage.aspx.cs" Inherits="KingstonBankl.UserEditInfoPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section id="UserPage" class="d-flex justify-content-center align-items-center vh-100">
        <div class="card p-4 shadow-lg" style="width: 40rem;">
            <center><h1>Update Personal Info</h1></center>
            <div class="card-body">
                <!-- Row 1 -->
                <div class="row">
                <div class="col-md-6 d-flex">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtName" class="form-label">Name</label>
                        <asp:TextBox ID="txtName" CssClass="form-control"  runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 d-flex">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtSurname" class="form-label">Surname</label>
                        <asp:TextBox ID="txtSurname" CssClass="form-control"  runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="txtID" CssClass="form-control"  runat="server" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
                </div>
                <!-- Row 3 -->
                <div class="row">
                <div class="col-md-6 d-fle">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtCellNumber" class="form-label">Cell Number</label>
                        <asp:TextBox ID="txtCellNumber" CssClass="form-control"  runat="server" TextMode="SingleLine" MaxLength="10"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 d-fle">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtEmail" class="form-label">Email</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control"  runat="server" TextMode="Email"></asp:TextBox>
                    </div>
                </div>
                 </div>

                <!-- Row 4 -->
                <div class="row">
                <div class="col-md-6 d-fle">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtCitizenship" class="form-label">Citizenship</label>
                        <asp:TextBox ID="txtCitizenship" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 d-fle">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtMaritalStatus" class="form-label">Marital Status</label>
                        <asp:TextBox ID="txtMaritalStatus" runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="txtUserID" CssClass="form-control" placeholder="User ID" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 d-fle">
                    <div class="col-md-12 form-group d-flex flex-column">
                        <label for="txtPassword" class="form-label">Password</label>
                        <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                 </div>

                <!-- Submit Button -->
                <div class="row mt-3">
                    <div class="col-md-12">
                       <asp:Button ID="btnUpdate" runat="server" class="btn btn-success" Text="Update" OnClick="btnUpdate_Click" />
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
