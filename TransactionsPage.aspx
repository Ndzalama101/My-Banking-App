<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionsPage.aspx.cs" Inherits="KingstonBankl.TransactionsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="UserPage">
         <center>
     <div class="card" style="width: 50rem;">
         <h3>Transactions</h3>
         <div class="card-body">
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Bang_BankConnectionString %>" SelectCommand="SELECT [Name], [TransactionDate], [Amount], [TransactionDescription] FROM [tbl_transactions]"></asp:SqlDataSource>
             <asp:GridView ID="GridView1" class="table table-success  table-bordered table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="Amount" >
                 <Columns>
                     <asp:BoundField DataField="TransactionDate" HeaderText="TransactionDate" SortExpression="TransactionDate" />
                     <asp:BoundField DataField="Amount" HeaderText="Amount" ReadOnly="True" SortExpression="Amount" />
                     <asp:BoundField DataField="TransactionDescription" HeaderText="TransactionDescription" SortExpression="TransactionDescription" />
                 </Columns>
             </asp:GridView>
         </div>
         <asp:Button ID="btnBack" class="btn btn-success btn-lg mx-2" runat="server" Text="Back" OnClick="btnBack_Click" />

         <div>
             <a href="index.aspx"><< Back to Home</a>
         </div>
     </div>
 </center>
    </section>
</asp:Content>
