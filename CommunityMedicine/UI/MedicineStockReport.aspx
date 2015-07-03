<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CenterMaster.Master" AutoEventWireup="true" CodeBehind="MedicineStockReport.aspx.cs" Inherits="CommunityMedicine.UI.MedicineStockReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Medicine Stock Report</h1>
    <asp:GridView ID="medicineStockGridView" runat="server" Height="162px" Width="354px"></asp:GridView>
</asp:Content>
