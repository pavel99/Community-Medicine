<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CenterMaster.Master" AutoEventWireup="true" CodeBehind="CenterHomePage.aspx.cs" Inherits="CommunityMedicine.UI.CenterHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>WelCome   <asp:Label ID="centerNameLabel" runat="server"> to Center Home </asp:Label></h1><br/>
        <p>Here you can add doctor <asp:Button ID="addDoctorButton" runat="server" Text="Add Doctor" OnClick="addDoctorButton_Click" /></p>
         
        
    </div>
</asp:Content>
