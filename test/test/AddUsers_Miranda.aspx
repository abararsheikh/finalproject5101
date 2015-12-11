<%@ Page MasterPageFile="~/BRDHC.Master" Language="C#" AutoEventWireup="true" CodeBehind="AddUsers_Miranda.aspx.cs" Inherits="test.WebForm3" %>

<asp:Content ContentPlaceHolderID="content" runat="server">

    <form id="form1" runat="server">
    <div>
    
        Add User to Database:<br />
        <br />
        UserId:
        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
        <br />
        <br />
        Username: <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        <br />
        Password:<asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add User" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update User" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete User" />
        <br />
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>

</asp:Content>
