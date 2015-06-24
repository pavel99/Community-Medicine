<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CenterMaster.Master" AutoEventWireup="true" CodeBehind="DoctorEntryPage.aspx.cs" Inherits="CommunityMedicine.UI.DoctorEntryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Doctor Entry</h1>
        <table>
            <tr>
                <td><asp:Label ID="nameLabel" runat="server" Text="Name"></asp:Label></td>
                <td>
                    <asp:TextBox ID="doctorNameTextBox" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="degreeLabel" runat="server" Text="Degree"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="doctorDegreeTextBox" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="specializationLabel" runat="server" Text="Specialization"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="specializationTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="doctorSaveButton" runat="server" Text="Save" OnClick="doctorSaveButton_Click" />
                </td>
            </tr>

        </table>
        <asp:Label ID="msgLabel" runat="server"></asp:Label>
        
    </div>
</asp:Content>
