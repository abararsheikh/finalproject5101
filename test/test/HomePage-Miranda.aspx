<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage-Miranda.aspx.cs" Inherits="test.HomePage_Miranda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Welcome,
        <asp:Label ID="lblWelcome" runat="server"></asp:Label>
        !<br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btnUserAdd" runat="server" OnClick="btnUserAdd_Click" Text="Add or Remove Users" />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
