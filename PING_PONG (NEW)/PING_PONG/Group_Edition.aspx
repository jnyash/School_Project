<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Group_Edition.aspx.cs" Inherits="PING_PONG.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="StyleSheet/BookingStyleSheet.css" rel="stylesheet" type="text/css" />


    <style type="text/css">
        .auto-style7 {
            width: 406px;
        }
        .auto-style8 {
            width: 351px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <table class="auto-style1" border="1">
            <tr>
                <td class="auto-style8">Customer Search<br />
                    <br />
                    <asp:TextBox ID="FirstNameSearch" runat="server" Width="104px"></asp:TextBox>
                    &nbsp;
                    <asp:TextBox ID="LastNameSearch" runat="server" Width="104px"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />

                    <br />
                    <br />
                    <asp:DataGrid ID="PersonGrid" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" CellPadding="3" ForeColor="Black" OnItemCreated="PersonGrid_ItemCreated" OnPageIndexChanged="PersonGrid_PageIndexChanged1" PageSize="8" Width="408px" OnItemCommand="PersonGrid_ItemCommand" OnItemDataBound="PersonGrid_ItemDataBound">
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
                            <asp:TemplateColumn HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Linkadd" runat="server"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedItemStyle BackColor="Lime" BorderColor="Black" BorderStyle="Groove" />
                    </asp:DataGrid>
                    <br />

                    <asp:Label ID="erroraddellb" runat="server"></asp:Label>
                    <asp:SqlDataSource ID="SDSearchEn" runat="server" ConnectionString="<%$ ConnectionStrings:FirstConn %>" SelectCommand="SELECT * FROM Persons inner join Adresses On Adresses.ID = Persons.ID where (vchFirstName like'%' + @Firstname + '%') and  (vchLastName like '%' + @Lastname + '%')">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="FirstNameSearch" DefaultValue="%" Name="Firstname" PropertyName="Text" />
                            <asp:ControlParameter ControlID="LastNameSearch" DefaultValue="%" Name="Lastname" PropertyName="Text" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="ShowMemGroup" runat="server" ConnectionString="<%$ ConnectionStrings:FirstConn %>" SelectCommand="Usp_Show_Person" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter Name="ID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td class="auto-style7">
                    <br />
                    <br />
                    Create Group<br />
                    <asp:TextBox ID="txtnewgroup" runat="server" Width="101px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnewgroup" ErrorMessage="*" ForeColor="Red" ValidationGroup="Create Group"></asp:RequiredFieldValidator>
                    &nbsp;<asp:DropDownList ID="DDLTypeListnewgroup" runat="server" Width="130px" DataSourceID="SDSNewGroupType" DataTextField="vchGroup" DataValueField="vchGroup">
                    </asp:DropDownList>
                    &nbsp;<asp:Button ID="btnnewgroup" runat="server" Text="New Group" OnClick="btnnewgroup_Click" />
                    <br />
                    <asp:Label ID="lberror" runat="server"></asp:Label>
                    <br />
                    <asp:SqlDataSource ID="SDSNewGroupType" runat="server" ConnectionString="<%$ ConnectionStrings:FirstConn %>" SelectCommand="SELECT [intGroup_Type], [vchGroup] FROM [Group_types]"></asp:SqlDataSource>
                    <br />
                    Group Edit<br />
                    <asp:DropDownList ID="DDLGroupList" runat="server" AutoPostBack="True" DataSourceID="SDS_Group_List" DataTextField="vchGroupNamn" DataValueField="Group_Id" OnSelectedIndexChanged="DDLGroupList_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SDS_Group_List" runat="server" ConnectionString="<%$ ConnectionStrings:FirstConn %>" SelectCommand="SELECT [Group_Id], [vchGroupNamn] FROM [Groups]"></asp:SqlDataSource>
                    <br />
                    <br />
                    <asp:DataGrid ID="GroupMember" runat="server" AutoGenerateColumns="False" BackColor="White" CellPadding="3" ForeColor="Black" PageSize="8" Width="408px" OnItemDataBound="GroupMember_ItemDataBound" OnItemCommand="GroupMember_ItemCommand">
                        <AlternatingItemStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:TemplateColumn Visible="false">
                                <ItemTemplate>
                                    <%#DataBinder.Eval(Container.DataItem, "Group_ID")%>
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
                        <asp:TemplateColumn HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="Linkdelete" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedItemStyle BackColor="Lime" BorderColor="Black" BorderStyle="Groove" />
                    </asp:DataGrid>
                    <asp:Label ID="lbgroup" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lbcount" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="erroraddellb1" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:DropDownList ID="DDLTypeList" runat="server" DataSourceID="SDSGroupTypeList" DataTextField="vchGroup" DataValueField="Group_Id" Width="188px">
                    </asp:DropDownList>
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSave0" runat="server" OnClick="btnSave_Click" Text="Save" />
                    <asp:SqlDataSource ID="SDSGroupTypeList" runat="server" ConnectionString="<%$ ConnectionStrings:FirstConn %>" SelectCommand="SELECT        Groups.Group_Id, Group_types.vchGroup, Groups.intGroup_Type
FROM            Group_types INNER JOIN
                         Groups ON Group_types.intGroup_Type = Groups.intGroup_Type

where Groups.Group_Id = @Group_Id">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DDLGroupList" Name="Group_Id" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>

        </table>

        </asp:Content>