<%@ Page Language="C#" AutoEventWireup="true"CodeBehind="WebForm5.aspx.cs" Inherits="PING_PONG.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #DDLGroupList {
            width: 100%;
        }

        #DDLTypeList {
            width: 100%;
        }

        .auto-style1 {
            width: 100%;
        }

        .auto-style3 {
            width: 100%;
            height: 553px;
        }
        .auto-style4 {
            height: 553px;
        }
    </style>
</head>
<body>
        <form id="form1" runat="server">
        <table class="auto-style1" border="1">
            <tr>
                <td class="auto-style3">
                    Group Edit<br />
                    <br />
                    <asp:DropDownList ID="DDLGroupList" runat="server" DataSourceID="SDS_Group_List" DataTextField="vchGroupNamn" DataValueField="Group_Id" AutoPostBack="True" OnSelectedIndexChanged="DDLGroupList_SelectedIndexChanged">
                    </asp:DropDownList>

                    <br />
                    <asp:SqlDataSource ID="SDS_Group_List" runat="server" ConnectionString="<%$ ConnectionStrings:FirstConn %>" SelectCommand="SELECT [Group_Id], [vchGroupNamn] FROM [Groups]"></asp:SqlDataSource>
                    <br />
                    <br />
                    <asp:DataGrid ID="GroupMember" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" CellPadding="3" ForeColor="Black" OnItemCreated="PersonGrid_ItemCreated" OnPageIndexChanged="PersonGrid_PageIndexChanged1" PageSize="4" Width="408px" OnItemCommand="PersonGrid_ItemCommand" OnItemDataBound="PersonGrid_ItemDataBound">
                        <AlternatingItemStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:TemplateColumn Visible="false">
                                <ItemTemplate>
                                    <%#DataBinder.Eval(Container.DataItem, "Group_Id")%>
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

                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedItemStyle BackColor="Lime" BorderColor="Black" BorderStyle="Groove" />
                    </asp:DataGrid>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="messagelb" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="erroraddellb1" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:DropDownList ID="DDLTypeList" runat="server" DataSourceID="SDSGroupTypeList" DataTextField="vchGroup" DataValueField="Group_Id">
                    </asp:DropDownList>
                    <br />
                    <asp:SqlDataSource ID="SDSGroupTypeList" runat="server" ConnectionString="<%$ ConnectionStrings:FirstConn %>" SelectCommand="SELECT        Groups.Group_Id, Group_types.vchGroup, Groups.intGroup_Type
FROM            Group_types INNER JOIN
                         Groups ON Group_types.intGroup_Type = Groups.intGroup_Type"></asp:SqlDataSource>
                    <br />
                    <asp:Button ID="btnSave" runat="server" Text="Save" Style="float: right" OnClick="btnSave_Click" />
                    <br />
                </td>
                <td class="auto-style4">
                    <br />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>