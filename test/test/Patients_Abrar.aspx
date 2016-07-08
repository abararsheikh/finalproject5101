<%@ Page MasterPageFile="~/BRDHC.Master" Language="C#" AutoEventWireup="true" CodeBehind="Patients_Abrar.aspx.cs" Inherits="test.Patients_page_Abrar" %>


<asp:Content ContentPlaceHolderID="content" runat="server">

   
        <p>
            &nbsp;</p>
        <p>
            <table style="width: 95%">
                <tr>
                    <td class="auto-style1">Ontario Health Card number</td>
                    <td>
                        <asp:TextBox ID="txtPatientId" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnLoad" runat="server" OnClick="btnLoad_Click" Text="Load" />
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPatientId" ErrorMessage="Health card number is required" ForeColor="Red" ValidationGroup="valGroup1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">First Name </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Firstname is requiered" ForeColor="Red" ValidationGroup="valGroup1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Last Name</td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last name is required" ForeColor="Red" ValidationGroup="valGroup1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Phone</td>
                    <td style="margin-left: 80px">
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone number is requiered" ForeColor="Red" ValidationGroup="valGroup1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Date In </td>
                    <td style="margin-left: 120px">
                        <asp:TextBox ID="txtDateIn" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date Formate : mm/dd/yyyy
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDateIn" ErrorMessage="Date is requiered" ForeColor="Red" ValidationGroup="valGroup1"></asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td style="margin-left: 120px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Department</td>
                    <td class="auto-style2" style="margin-left: 120px">
                        <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDepartment" ErrorMessage="Please enter department" ForeColor="Red" ValidationGroup="valGroup1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td style="margin-left: 120px">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="txtInsert" runat="server" OnClick="txtInsert_Click" Text="Insert" ValidationGroup="valGroup1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="txtUpdate" runat="server" OnClick="txtUpdate_Click" Text="Update" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="txtDelete" runat="server" OnClick="txtDelete_Click" Text="Delete" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
                        <br />
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnDisplay" runat="server" OnClick="btnDisplay_Click" Text="Display Table " />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                    </td>
                </tr>
            </table>
        </p>
        <p>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblMessage2" runat="server"></asp:Label>
        </p>
        <p>
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
   
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />

            </asp:GridView>
        </p>

</asp:Content>