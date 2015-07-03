<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CommunityMedicine.Master" AutoEventWireup="true" CodeBehind="BarChart.aspx.cs" Inherits="CommunityMedicine.UI.BarChart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-2.1.4.min.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.min.js"></script>
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="From"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="fromDateTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="toDateTextBox" runat="server" Width="174px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="districtDropDownList" runat="server"></asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="ShowBarChartButton" runat="server" Text="Show" OnClick="ShowBarChartButton_Click" Width="152px" />
            </td>
        </tr>
    </table>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        
    </asp:ScriptManager>
    
    <asp:Chart ID="Chart1" runat="server" Width="484px">
        <Series>
            <asp:Series Name="Series1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    
    
     <script type="text/javascript">
         //$("#lastDateTextBox").datepicker();
         $("#<%= fromDateTextBox.ClientID %>").datepicker();
         $("#<%= toDateTextBox.ClientID %>").datepicker();
        </script>








</asp:Content>
