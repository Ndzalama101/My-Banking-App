<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="KingstonBankl.adminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section id="loginBackground">
         <center>
    
     <div class="card" style="width: 30rem;">
         <h3>Admin Login</h3>
               <center>
                <img src="img/User%20avatar%20icon,%20button,%20profile%20symbol,%20flat%20person%20icon_%20Circle%20button%20with%20avatar%20photo_.jpeg" width="80" hight="80" />
               </center>
  
           <div class="card-body">
                  <div class="form-control">
                      <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="User ID" runat="server" ></asp:TextBox>
                      <asp:TextBox ID="TextBox2" class="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                  </div>
                   <div class="d-grid gap-2"> 
                           <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Login" onclick="Button1_Click"  />  
                      
                   </div>
            </div>
       </div> 
      <div>
          <a href="index.aspx"> << back to home</a>
      </div>

 </center>
    </section>
    

</asp:Content>
