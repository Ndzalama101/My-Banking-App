<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="KingstonBankl.UserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
    <img src="img/pricing-img.jpeg" style="width: 100%; height: 60%;" />
</section>

    <section id="UserPage">
        <!--MIDDLE SECTION-->
     <center>
     <div class="container-fluid">

           <div>
            <center>
                 <div class="col-md-7">
             <div class="card">
                 <div class="row">
                      <h1>Accounts List</h1>
                 </div>

                 <div class="row">
                     <div class="col">
                         <hr/>
                     </div>
                 </div>
                
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Bang_BankConnectionString %>" SelectCommand="SELECT [Name], [account_number], [balance] FROM [Accounts]"></asp:SqlDataSource>

                          <div class="gridview-container">
                               <!--/first card-->
                              <asp:GridView class="table table-success  table-bordered table-striped" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="account_number" >
                                  <Columns>
                                      <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                      <asp:BoundField DataField="account_number" HeaderText="account_number" ReadOnly="True" SortExpression="account_number" />
                                      <asp:BoundField DataField="balance" HeaderText="balance" SortExpression="balance" />
                                  </Columns>
                               </asp:GridView>

                           </div>

             </div> <!--card-->

         </div> <!--col md 7-->
             </center>
           </div>

         <div class="container d-flex justify-content-center align-items-center min-vh-100">
    <div class="card shadow-lg p-4 rounded-4" style="max-width: 500px; width: 100%;">
        <div class="card-body">
            <h3 class="text-center mb-4">Account Transactions</h3>

            <!-- Account Number Input with Search Button -->
            <div class="mb-3">

                <label for="txtAccountNumber" class="form-label fw-bold">Account Number</label>
                <div class="input-group">
                    <asp:TextBox ID="txtAccountNumber" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Button CssClass="btn btn-primary" ID="Button2" runat="server" Text="Search" OnClick="Button2_Click" />
                </div>
            </div>

            <!-- Amount Input -->
            <div class="mb-3">
                <label for="txtBalance" class="form-label fw-bold">Amount (R):</label>
                <asp:TextBox ID="txtBalance" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
            </div>

            <!-- Action Buttons -->
            <div class="d-flex justify-content-between mt-4">
                <asp:Button CssClass="btn btn-success w-30" ID="btnDeposit" runat="server" Text="Deposit" OnClick="btnDeposit_Click" />
                <asp:Button CssClass="btn btn-warning w-30" ID="btnWithdraw" runat="server" Text="Withdraw" OnClick="btnWithdraw_Click" />
                <asp:Button CssClass="btn btn-danger w-30" ID="btnDelete" runat="server" Text="Delete Account" OnClick="btnDelete_Click" />
            </div>
        </div>
    </div>
</div>


    </div>
    <!--/first card-->

      <section id="PayBeneficiary" class="about section">
        <center>
         <h1>Transfer Money</h1>
          <div class="card" style="width: 18rem;">
          <div class="card-body">
          <h5 class="card-title">Pay To</h5>
          
              <div class="form-control">
                  <div class="row">
                     <label for="txtFrom" class="form-label">from</label>
                     <asp:TextBox ID="txtFrom"  runat="server"></asp:TextBox>
                  </div>

                   <div class="row">
                     <label for="txtTo" class="form-label">To</label>
                     <asp:TextBox ID="txtTo"  runat="server" TextMode="Number"></asp:TextBox>
                  </div>

                   <div class="row">
                     <label for="txtAmount" class="form-label">Amount</label>
                     <asp:TextBox ID="txtAmount" runat="server" TextMode="Number"></asp:TextBox>
                  </div>

               
              
          
          </div>
              <asp:Button ID="btnTransfer" class="btn btn-success" runat="server" Text="Transfer" OnClick="btnTransfer_Click" />
          </div>
      </center>   

    </section><!-- /Pay Section -->
          </center>
        
 <div class="d-flex justify-content-center mt-3">
    <asp:Button ID="Button1" runat="server" class="btn btn-success btn-lg mx-2" Text="View Transactions" OnClick="Button1_Click" />
    <asp:Button ID="btnEditInfo" runat="server" class="btn btn-primary btn-lg mx-2" Text="Edit Personal Information" OnClick="btnEditInfo_Click" />
</div>


</section>
</asp:Content>
