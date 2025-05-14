<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="adminEditInfo.aspx.cs" Inherits="KingstonBankl.adminEditInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

               <div class="container-fluid">
       

     <div class="card"  style="width: 70rem;>
      <div class="card-header">
       Accont Management
      </div>
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
                                    <label for="TextBox1" class="form-label">User ID</label>
                                    <asp:TextBox ID="txtUserID" placeholder="user ID" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtPassword" class="form-label">Password</label>
                                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                       
                    </div><!--card body-->
    </div><!--card-->
   </div><!--container body-->


              <!--Account and card details Section -->
<section id="AccountAndCardDetails" class="AccountAndCardDetails">
    <center>
        <h1>Account and Card details</h1>
         <div class="card" style="width: 18rem;">
         <div class="card-body">
         <h5 class="card-title">Account and Card details</h5>
         
             <div class="form-control">

                  <div class="row">
                    <label for="TextBox1" class="form-label">Account Number</label>
                    <asp:TextBox ID="txtAccontNo"  runat="server" MinLength="10" MaxLength="10"  ></asp:TextBox>
                 </div>

                  <div class="row">
                    <label for="TextBox1" class="form-label">Card Number</label>
                    <asp:TextBox ID="txtCardNumber"  runat="server" MinLength="16" MaxLength="16" ></asp:TextBox>
                  </div>

                  <div class="row">
                    <label for="TextBox1" class="form-label">Security Code</label>
                    <asp:TextBox ID="txtSecurityCode"  runat="server" MinLength="3" MaxLength="3" ></asp:TextBox>
                  </div>

                 <div class="row">
                  <label for="TextBox1" class="form-label">Valid Thru</label>
                  <asp:TextBox ID="txtValidthru"  runat="server" TextMode="Date"></asp:TextBox>
                 </div>

                 <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Update" OnClick="Button1_Click" />
             </div>
         </div>
    </center>


  
</section><

</asp:Content>
