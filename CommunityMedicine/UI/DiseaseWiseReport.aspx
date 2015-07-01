<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CommunityMedicine.Master" AutoEventWireup="true" CodeBehind="DiseaseWiseReport.aspx.cs" Inherits="CommunityMedicine.UI.DiseaseWiseReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <script src="../Scripts/jquery-2.1.4.min.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.min.js"></script>

    <asp:Label ID="Label1" runat="server" Text="Disease Name"></asp:Label>
    <asp:DropDownList ID="diseaseDropDownList" runat="server"></asp:DropDownList>
    <asp:Button ID="showDieseaseButton" runat="server" Text="Show" />
    <asp:Label ID="Label2" runat="server" Text="Date Between"></asp:Label>
        <asp:TextBox ID="firstDateTextBox" Text="Click to select Date" runat="server"></asp:TextBox>
   
    <asp:Label ID="Label3" runat="server" Text="And"></asp:Label>
    <%-- <asp:DropDownList ID="datelastDropDownList" runat="server"></asp:DropDownList>--%>
    <asp:TextBox ID="lastDateTextBox" Text="Click to select Date" runat="server"></asp:TextBox>
    <asp:GridView ID="diseaseWiseGridView" runat="server" AllowPaging="True" OnSelectedIndexChanging="diseaseWiseGridView_SelectedIndexChanging" PageSize="5">
        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="5" />
        </asp:GridView>
    <asp:Button ID="doPDF" runat="server" Text="PDF" />


    <script type="text/javascript">
        //$("#lastDateTextBox").datepicker();
        $("#<%= lastDateTextBox.ClientID %>").datepicker();
        $("#<%= firstDateTextBox.ClientID %>").datepicker();
    </script>

    <style type="text/css">
        .style1 {
            color: #800000;
            background: black;
        }

        .style2 {
            font-size: x-large;
        }

        .style3 {
            font-size: x-large;
            color: #990000;
        }
    </style>

    </div>

</asp:Content>
