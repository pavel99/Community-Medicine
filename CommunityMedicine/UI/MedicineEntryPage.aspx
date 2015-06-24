<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CommunityMedicine.Master" AutoEventWireup="true" CodeBehind="MedicineEntryPage.aspx.cs" Inherits="CommunityMedicine.UI.MedicineEntryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
           <tr>
               <td>
                   <asp:Label ID="medicineLabel" runat="server" Text="Name Of Medicine With Mg/Ml"></asp:Label>
               </td>
                <td>
                    <asp:TextBox ID="medicineTextBox" TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
           </tr> 
             <tr>
               <td></td>
                <td>
                    <asp:Button ID="medicineSaveButton" runat="server" Text="Save" OnClick="medicineSaveButton_Click" />
                </td>
           </tr> 

        </table><br/>
        <asp:Label ID="msgLabel" runat="server"></asp:Label><br/>
        <asp:GridView ID="medicineGridView" runat="server" AllowPaging="True" OnPageIndexChanging="medicineGridView_PageIndexChanging" PageSize="5">
            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="5" />
        </asp:GridView>
        

    </div>
</asp:Content>
