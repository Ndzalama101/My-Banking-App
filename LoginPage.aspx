<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="KingstonBankl.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <center>[
                <section id="loginBackground" >
                     <div class="card" style="width: 30rem;">
                <h3>User Login</h3>
                
                <center>
                <img src="img/User%20avatar%20icon,%20button,%20profile%20symbol,%20flat%20person%20icon_%20Circle%20button%20with%20avatar%20photo_.jpeg" width="80" hight="80" />
               </center>

                <div class="card-body">
                    <div class="form-group">
                        <asp:TextBox ID="TextBox1" CssClass="form-control mb-2" runat="server" placeholder="User ID"></asp:TextBox>
                        <asp:TextBox ID="TextBox2" CssClass="form-control mb-2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                    </div>
                    
                    <div class="d-grid gap-2">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Log In" OnClick="Button1_Click" />
                    </div>

                    <div class="d-grid gap-2">
                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-success" Text="Sign Up" OnClick="Button2_Click" />
                    </div>
                </div>

                <div>
                    <a href="index.aspx"><< Back to Home</a>
                </div>
            </div>
                </section>
           
            </center>

</asp:Content>
