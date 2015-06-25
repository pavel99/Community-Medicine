<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CenterMaster.Master" AutoEventWireup="true" CodeBehind="TreatmentGiven.aspx.cs" Inherits="CommunityMedicine.UI.TreatmentGiven" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Voter Id"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="voterIdTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="showDetailsButton" runat="server" Text="Show Details" />

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="addressTextBox" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Age"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ageTextBox" runat="server"></asp:TextBox>
                </td>

            </tr>
        </table>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Service Given"></asp:Label>
        <asp:TextBox ID="serviceGivenTextBox" runat="server"></asp:TextBox><br />

        <asp:Label ID="Label6" runat="server" Text="observationTextBox"></asp:Label>
        <asp:TextBox ID="observationTextBox" TextMode="MultiLine" runat="server"></asp:TextBox>
         <asp:Label ID="Label7" runat="server" Text="Date"></asp:Label>
        <asp:DropDownList ID="dateDropDownList" runat="server"></asp:DropDownList>
        <asp:Label ID="Label9" runat="server" Text="Dose"></asp:Label>
         <asp:DropDownList ID="doseDropDownList"  runat="server"></asp:DropDownList>
        
        <asp:RadioButton ID="beformealRadioButton"  Text="Before Meal" runat="server" GroupName="mealGroup" />
        <asp:RadioButton ID="aftermelaRadioButton" Text="After Meal" runat="server" GroupName="mealGroup" />
        <asp:Label ID="Label8" runat="server" Text="quantityGiven"></asp:Label>
        <asp:TextBox ID="quantiyGivenTextBox" runat="server"></asp:TextBox>
        <asp:Label ID="Label10" runat="server" Text="Note"></asp:Label>
        <asp:TextBox ID="noteTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="addButton" runat="server" Text="Add" />
        <br/><br/>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <asp:Button ID="saveButton" runat="server" Text="Save" />


    </div>

</asp:Content>
