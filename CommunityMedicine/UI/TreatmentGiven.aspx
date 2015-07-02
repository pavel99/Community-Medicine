<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/UI/CenterMaster.Master" AutoEventWireup="true" CodeBehind="TreatmentGiven.aspx.cs" Inherits="CommunityMedicine.UI.TreatmentGiven" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 34px;
        }
    .auto-style2 {
        width: 110px;
    }
    .auto-style3 {
        width: 113px;
    }
    .auto-style4 {
        height: 39px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-2.1.4.min.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.min.js"></script>


    <div>
        <asp:Panel  ID="treatmentPanel" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Voter Id"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="voterIdTextBox" runat="server" Height="21px" Width="266px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="showDetailsButton" runat="server" Text="Show Details" OnClick="showDetailsButton_Click" />

                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>

                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="nameTextBox" runat="server" Width="265px" Height="19px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="addressTextBox" runat="server" TextMode="MultiLine" style="margin-top: 10px" Width="265px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Age"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ageTextBox" runat="server" Width="263px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="auto-style4">
                     <asp:Label ID="Label5" runat="server" Text="Service Given"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="serviceGivenTextBox" runat="server" Width="263px" Height="16px" style="margin-right: 0px; margin-top: 11px"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td>
                     <asp:Button ID="historyButton" runat="server" Text="Show History" />
                </td>
            </tr>
        </table>
        <br /><br/><br/>
       
        
      
        




        <table>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Observation"></asp:Label></td>
                <td>
                    <asp:TextBox ID="observationTextBox" TextMode="MultiLine" runat="server" Height="49px" Width="303px"></asp:TextBox></td>
                <td class="auto-style2">
                    <asp:Label ID="Label11" runat="server" Text="Date"></asp:Label></td>
                <td>
                    <asp:TextBox ID="dateTextBox" Text="Click to select Date" runat="server" Width="176px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Doctor"></asp:Label></td>
                <td class="auto-style3">
                    <asp:DropDownList ID="doctorDropDownList" runat="server" Height="16px" Width="104px"></asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="Disease"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="diseaseDropDownList" runat="server"></asp:DropDownList></td>
                <td class="auto-style2">
                    <asp:Label ID="Label13" runat="server" Text="Medicine"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="medicineDropDownList" runat="server"></asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label14" runat="server" Text="Dose"></asp:Label></td>
                <td class="auto-style3">
                    <asp:DropDownList ID="doseDropDownList" runat="server" Height="16px" Width="105px"></asp:DropDownList></td>

            </tr>
        </table>
        <table>
            <tr>
                <td>

                    <asp:RadioButton ID="beformealRadioButton" Text="Before Meal" runat="server" GroupName="mealGroup" /></td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="quantityGiven"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="quantiyGivenTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Note"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="noteTextBox" runat="server" Height="42px" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="addButton" runat="server" Text="Add" Width="103px" OnClick="addButton_Click" />
                </td>

            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="aftermelaRadioButton" Text="After Meal" runat="server" GroupName="mealGroup" />
                </td>
              
            </tr>
        </table>






        <br />
        <br />
        <asp:GridView ID="treatmentGridView" runat="server"></asp:GridView><br />
        </asp:Panel>
        <asp:Button ID="saveButton" runat="server" Text="Save" Width="117px" OnClick="saveButton_Click" />
         <asp:Button ID="pdfButton" runat="server" Text="PDF" Width="117px" OnClick="pdfButton_Click" />

        <asp:Label ID="saveLabel" runat="server" ></asp:Label><br/>
        <asp:Label ID="updateLabel" runat="server" ></asp:Label>



        <script type="text/javascript">
            //$("#lastDateTextBox").datepicker();
            $("#<%= dateTextBox.ClientID %>").datepicker();
           
        </script>
            


    </div>

</asp:Content>
