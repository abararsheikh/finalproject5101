<%@ Page MasterPageFile="~/BRDHC.Master" Language="C#" AutoEventWireup="true" CodeBehind="Doctors_Bin.aspx.cs" Inherits="test.Doctors_page_Bin" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <div>
    
        <table style="width: 60%; margin: auto;">
            <tr>
                <td>Doctors Id:</td>
                <td>
                    <asp:TextBox ID="DoctorId" runat="server"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnLoad" runat="server" OnClick="btnLoad_Click" Text="Load" />
                    
                </td>
            </tr>
            <tr>
                <td>First_name:</td>
                <td>
                    <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Last_name:</td>
                <td>
                    <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Speciality:</td>
                <td>
                    <asp:TextBox ID="SpecialityId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Phone:</td>
                <td>
                    <asp:TextBox ID="PhoneNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Office:</td>
                <td>
                    <asp:TextBox ID="OfficeNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Come_in_date:</td>
                <td>
                    <asp:TextBox ID="ComeInDate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Availibility:</td>
                <td>
                    <asp:TextBox ID="AvaulabilityId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Discharge Date:</td>
                <td>
                    <asp:TextBox ID="ComeOutDate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1">
                    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" style="height: 26px" />
                    &nbsp;<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                    &nbsp;<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>