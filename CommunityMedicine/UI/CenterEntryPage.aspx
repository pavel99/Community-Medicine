<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CommunityMedicine.Master" AutoEventWireup="true" CodeBehind="CenterEntryPage.aspx.cs" Inherits="CommunityMedicine.UI.CenterEntryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <h1>Create New Center</h1>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="centerNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="District"></asp:Label>

                </td>
                <td>
                    <asp:DropDownList ID="districtDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="districtDropDownList_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Thana"></asp:Label>

                </td>
                <td>
                    <asp:DropDownList ID="thanaDropDownList" runat="server"></asp:DropDownList>
                </td>
            </tr>
              <tr>
                <td>

                </td>
                <td>
                    <asp:Button ID="centerSaveButton" runat="server" Text="Save" OnClick="centerSaveButton_Click" />
                </td>
            </tr>
        </table><br/>
        <asp:Label ID="msgLabel" runat="server"></asp:Label>
    
    </div>
    
    
    
    

</asp:Content>
