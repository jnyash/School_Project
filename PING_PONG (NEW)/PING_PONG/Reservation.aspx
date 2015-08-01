<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="PING_PONG.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            border-style: solid;
            border-width: 1px;
            width: 36%;
        }
        .auto-style3 {
            border-style: solid;
            border-width: 1px;
            width: 393px;
        }
        .auto-style4 {
            border-style: solid;
            border-width: 1px;
            width: 40px;
        }
        .auto-style5 {
            border-style: solid;
            border-width: 1px;
        }
        .auto-style6 {
            border-style: solid;
            border-width: 1px;
            width: 537px;
        }
        .auto-style7 {
            width: 537px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    
   <p></p>
    <table id="Reservation_table" class="auto-style1">
        <tr>
            <td colspan="2" class="auto-style5">Reservation</td>
            
        </tr>
        <tr>
            <td class="auto-style6">Group List : </td>
            <td class="auto-style5">
                <asp:DropDownList ID="DDLBokGroupList" runat="server" DataSourceID="SDSGroupList" DataTextField="vchGroupNamn" DataValueField="vchGroupNamn">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Date :</td>
            <td class="auto-style5">
                <asp:TextBox ID="Date" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Time : </td>
            <td class="auto-style5">
                <asp:DropDownList ID="DDL_Time" runat="server">
                    <asp:ListItem>Välj Period</asp:ListItem>
                    <asp:ListItem>08:00-10:00</asp:ListItem>
                    <asp:ListItem>10:00-12:00</asp:ListItem>
                    <asp:ListItem>12:00-14:00</asp:ListItem>
                    <asp:ListItem>14:00-16:00</asp:ListItem>
                    <asp:ListItem>16:00-18:00</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style6" colspan="3">
                <asp:Label ID="lbshowdate" runat="server"></asp:Label>
            </td>


        </tr>
       
        
        
        <tr>
            <td></td>
            <td><asp:Button ID="btn_reserve" runat="server" OnClick="btn_reserve_Click" Text="Reserve" /></td>

        </tr> 
  
         <tr>
            <td class="auto-style7">
                <asp:Label ID="erroraddellb2" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>

        </tr>
    </table>
    <asp:SqlDataSource ID="SDSGroupList" runat="server" ConnectionString="<%$ ConnectionStrings:FirstConn %>" SelectCommand="SELECT DISTINCT * FROM [Groups]"></asp:SqlDataSource>
    <asp:DataGrid ID="dgBoking" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" CellPadding="3" ForeColor="Black" PageSize="1000" Width="408px">
        <AlternatingItemStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:TemplateColumn Visible="false">
                <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "Group_Id")%>
                    </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Group Name">
                <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "vchGroupNamn")%>
                    </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Date">
                <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "zDAY")%>
                    </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Time">
                <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "zTime")%>
                    </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Group Type">
                <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "vchGroup")%>
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
</asp:Content>
