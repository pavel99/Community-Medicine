﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CommunityMedicine.Master" AutoEventWireup="true" CodeBehind="SendMedicinePage.aspx.cs" Inherits="CommunityMedicine.UI.SendMedicinePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Send Medicine to a Center</h1>
        <table>
            <tr>
                <td> <asp:Label ID="Label1" runat="server" Text="District"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="districtDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="districtDropDownList_SelectedIndexChanged"></asp:DropDownList></td><br />
            </tr>
             <tr>
                <td> <asp:Label ID="Label2" runat="server" Text="Thana"></asp:Label></td>
                <td><asp:DropDownList ID="thanaDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="thanaDropDownList_SelectedIndexChanged"></asp:DropDownList></td><br />
            </tr>
             <tr>
                <td> <asp:Label ID="Label3" runat="server" Text="Center"></asp:Label></td>
                <td><asp:DropDownList ID="centerDropDownList" runat="server"></asp:DropDownList></td><br />
            </tr>
             <h2>Add Medicine</h2>
             <tr>
                <td> <asp:Label ID="Label5" runat="server" Text="Select Medicine"></asp:Label></td>
                <td><asp:DropDownList ID="medicineDropDownList" runat="server"></asp:DropDownList></td>
                <td> <asp:Label ID="Label8" runat="server" Text="Quantity"></asp:Label></td>
                <td><asp:TextBox ID="quantityTextBox" runat="server"></asp:TextBox></td>
                <td><asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" /></td>
            </tr>
            
            <tr>
                <td>
                    <asp:GridView ID="medicineQuantityGridView" runat="server"></asp:GridView>
                </td>
                
            </tr>
             <tr>
                <td><asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" /></td>
                <td> </td>
                
            </tr>

        </table>

        <asp:Label ID="msgLabel" runat="server"></asp:Label>
    
    </div>
</asp:Content>
