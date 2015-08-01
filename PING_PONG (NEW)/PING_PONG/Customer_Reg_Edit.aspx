<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Customer_Reg_Edit.aspx.cs" Inherits="PING_PONG.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 70%;
        }

        #tblAddDel {
            width: 570px;
        }

        .auto-style4 {
            width: 36%;
        }

        .auto-style5 {
            width: 36%;
            height: 36px;
        }

        .auto-style6 {
            width: 46%;
            height: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <table id="TbSearch" runat="server">

        <tr>
            <td>
                <asp:Label ID="lbFirstName" runat="server" Text="First Name :"></asp:Label>

                <asp:TextBox ID="FirstNameEng" runat="server"></asp:TextBox>
                <asp:Label ID="lbLastName" runat="server" Text="LastName  :"></asp:Label>
                &nbsp;<asp:TextBox ID="LastNameEng" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <asp:DataGrid ID="PersonGrid" AutoGenerateColumns="False" runat="server" Width="1050px" BackColor="White" CellPadding="3" ForeColor="Black" AllowPaging="True" PageSize="15" OnItemCreated="PersonGrid_Pager" OnItemDataBound="PersonGrid_Bind" OnItemCommand="PersonGrid_ItemCommand" OnPageIndexChanged="PersonGrid_PageIndexChanged">
        <AlternatingItemStyle BackColor="#CCCCCC" />
        <Columns>

            <asp:TemplateColumn Visible="false">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "ID")%>
                </ItemTemplate>
            </asp:TemplateColumn>

            <asp:TemplateColumn HeaderText="FirstName">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "vchFirstName")%>
                </ItemTemplate>
            </asp:TemplateColumn>

            <asp:TemplateColumn HeaderText="LastName">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "vchLastName")%>
                </ItemTemplate>
            </asp:TemplateColumn>

            <asp:TemplateColumn HeaderText="SSN" Visible="false">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "SSN")%>
                    <asp:LinkButton ID="LinkButton" runat="server">LinkButton</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateColumn>

            <asp:TemplateColumn HeaderText="Email">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "vchEmail")%>
                </ItemTemplate>
            </asp:TemplateColumn>

            <asp:TemplateColumn HeaderText="Phone">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "vchPhone")%>
                </ItemTemplate>
            </asp:TemplateColumn>

            <asp:TemplateColumn HeaderText="Adress">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "vchAdress")%>
                </ItemTemplate>
            </asp:TemplateColumn>

            <asp:TemplateColumn HeaderText="City">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "vchCity")%>
                </ItemTemplate>
            </asp:TemplateColumn>

            <asp:TemplateColumn HeaderText="Zip">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "intZIP")%>
                </ItemTemplate>
            </asp:TemplateColumn>

            <asp:TemplateColumn HeaderText="Modifier">
                <ItemTemplate>
                    <asp:LinkButton ID="Linkmodifier" runat="server"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedItemStyle BackColor="Lime" BorderColor="Black" BorderStyle="Groove" />
    </asp:DataGrid>
    <br />

    <table id="tblAddDel" border="0" class="stylerigh">

        <tr>
            <td class="auto-style1" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="CRUD a person" ForeColor="Black"></asp:Label>
                <asp:Label ID="LbID" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>

        <tr>
            <td class="auto-style4">First Name: </td>
            <td class="auto-style3">
                <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstNameTextBox" ErrorMessage="*" ForeColor="Red" ValidationGroup="CRUD"></asp:RequiredFieldValidator>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Last Name: </td>
            <td class="auto-style3">
                <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastNameTextBox" ErrorMessage="*" ForeColor="Red" ValidationGroup="CRUD"></asp:RequiredFieldValidator>
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td class="auto-style4">SSN</td>

            <td class="auto-style3">
                <asp:TextBox ID="LbSSN" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LbSSN" ErrorMessage="*" ForeColor="Red" ValidationGroup="CRUD"></asp:RequiredFieldValidator>
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td class="auto-style4">Email</td>

            <td class="auto-style3">
                <asp:TextBox ID="EmailTextBox" runat="server" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="*" ForeColor="Red" ValidationGroup="CRUD"></asp:RequiredFieldValidator>
                <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td class="auto-style5">Phone</td>

            <td class="auto-style6">
                <asp:TextBox ID="PhoneTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="PhoneTextBox" ErrorMessage="*" ForeColor="Red" ValidationGroup="CRUD"></asp:RequiredFieldValidator>
                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td class="auto-style4">Adress</td>

            <td class="auto-style3">
                <asp:TextBox ID="AdressTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="AdressTextBox" ErrorMessage="*" ForeColor="Red" ValidationGroup="CRUD"></asp:RequiredFieldValidator>
                <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td class="auto-style4">City</td>

            <td class="auto-style3">
                <asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="CityTextBox" ErrorMessage="*" ForeColor="Red" ValidationGroup="CRUD"></asp:RequiredFieldValidator>
                <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td class="auto-style4">Zip</td>

            <td class="auto-style3">
                <asp:TextBox ID="ZipTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ZipTextBox" ErrorMessage="*" ForeColor="Red" ValidationGroup="CRUD"></asp:RequiredFieldValidator>
                <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td class="auto-style4">Type</td>

            <td class="auto-style3">
                <asp:DropDownList ID="DropDownListtype" runat="server" DataSourceID="SqlDataSource1" DataTextField="vchtypename" DataValueField="xType">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DropDownListtype" ErrorMessage="*" ForeColor="Red" ValidationGroup="CRUD"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="1">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /></td>
            <td class="auto-style3" colspan="1">

                <asp:Button ID="btnreg" runat="server" OnClick="btnreg_Click" Text="Register" />
                <asp:Button ID="btnClos" runat="server" Text="Clean" OnClick="btnClos_Click" /></td>
        </tr>

        <tr>
            <td class="AddDel" colspan="2">
                <asp:Label ID="erroraddellb" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:SqlDataSource ID="SDSearchEn" runat="server" ConnectionString="<%$ ConnectionStrings:FirstConn %>" SelectCommand="SELECT * FROM Persons inner join Adresses On Adresses.ID = Persons.ID where (vchFirstName like'%' + @Firstname + '%') or (vchLastName like '%' + @Lastname + '%')">
        <SelectParameters>
            <asp:ControlParameter ControlID="FirstNameEng" DefaultValue="%" Name="Firstname" PropertyName="Text" />
            <asp:ControlParameter ControlID="LastNameEng" DefaultValue="%" Name="Lastname" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FirstConn %>" SelectCommand="SELECT xType, vchtypename FROM xTypes"></asp:SqlDataSource>
</asp:Content>