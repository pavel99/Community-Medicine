<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CommunityMedicine.Master" AutoEventWireup="true" CodeBehind="DisplayCenterPage.aspx.cs" Inherits="CommunityMedicine.UI.DisplayCenterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Center Name"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblcenterName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Center Code"></asp:Label>
                    
                </td>
                <td>
                    <asp:Label ID="lblcenterCode" runat="server" ></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label>
                    
                </td>
                <td>
                    <asp:Label ID="lblpassword" runat="server"></asp:Label>
                    
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>
