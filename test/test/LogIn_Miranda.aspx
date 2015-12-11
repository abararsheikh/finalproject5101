<%@ Page  MasterPageFile="~/BRDHC.Master" Language="C#" AutoEventWireup="true" CodeBehind="LogIn_Miranda.aspx.cs" Inherits="test.LogIn_page_Miranda" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <form id="form1" runat="server" class="auto-style3">
     <div>
    
        <h1 class="auto-style1">Enter login information:
        </h1>
     
        <span class="auto-style1">User Name:</span>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valUserName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Please enter your user name." Font-Names="Calibri" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <span class="auto-style1">Password:</span>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Please enter your password." Font-Names="Calibri" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="LOGIN" BackColor="White" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium" ForeColor="#666666" />
        <br />
        <br />
        <asp:Label ID="lblMessage" runat="server" Font-Names="Calibri"></asp:Label>
    
    </div>
        </form>

</asp:Content>
