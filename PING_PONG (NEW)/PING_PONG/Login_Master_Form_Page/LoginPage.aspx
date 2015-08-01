<%@ Page Title="" Language="C#" MasterPageFile="~/Login_Master_Form_Page/LoginMasterPage.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PING_PONG.Login_Master_Form_Page.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="Logintable">
        <tr>
            <td colspan="2">
                <p style="text-align:center;">
                    Login</p>
            </td>
        </tr>
        <tr>
            <td class="lbusername">
                <asp:Label ID="lbusername" runat="server" Text="User Name : "></asp:Label>
            </td>
            <td class="txtusername">
                <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="lbpassword">
                <asp:Label ID="lbpassword" runat="server" Text="Password : "></asp:Label>
            </td>
            <td class="txtpassword">
                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="lberrormessage" colspan="2">
                <asp:Label ID="lberrormessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="btlogin">
                <asp:Button ID="btlogin" runat="server" OnClick="btlogin_Click1" Text="Log In" />
            </td>
        </tr>
    </table>
</asp:Content>
