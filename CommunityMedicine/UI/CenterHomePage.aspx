<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CenterMaster.Master" AutoEventWireup="true" CodeBehind="CenterHomePage.aspx.cs" Inherits="CommunityMedicine.UI.CenterHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>WelCome  To <asp:Label ID="centerNameLabel" runat="server"> to Center Home </asp:Label></h1><br/>
        <img width="900px" src="../Contents/images/center.jpg" />
    </div>
</asp:Content>
