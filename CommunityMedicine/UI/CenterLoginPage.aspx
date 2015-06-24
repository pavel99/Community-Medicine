<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CommunityMedicine.Master" AutoEventWireup="true" CodeBehind="CenterLoginPage.aspx.cs" Inherits="CommunityMedicine.UI.CenterLoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
    <h1>Center Login</h1>
        <table>
            <tr>
                <td>
                    <asp:Label ID="codeLabel" runat="server" Text="Center Code"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="centerCodeTextBox" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="passwordLabel" runat="server" Text="Password"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="passwordTextBox" runat="server"></asp:TextBox>

                </td>

            </tr>
            <tr>
                <td>
                    <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" />
                </td>
            </tr>
        </table>
        <asp:Label ID="msgLabel" runat="server" ></asp:Label>
    </div>
</asp:Content>
