<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CommunityMedicine.Master" AutoEventWireup="true" CodeBehind="DiseaseEntryPage.aspx.cs" Inherits="CommunityMedicine.UI.DiseaseEntryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Disease Name"></asp:Label>
                </td>
                        

               <td class="auto-style1">
                   <asp:TextBox ID="diseaseNameTextBox" runat="server" Width="233px"></asp:TextBox>

               </td>
            </tr>
               <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                </td>
                        

               <td class="auto-style1">
                   <asp:TextBox ID="descriptionTextBox" TextMode="MultiLine" runat="server" Height="73px" Width="232px"></asp:TextBox>
               </td>
            </tr>
               <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Treatment Procedure"></asp:Label>
                </td>
                        

               <td class="auto-style1">
                   <asp:TextBox ID="procedureTextBox" TextMode="MultiLine" runat="server" Height="61px" Width="234px"></asp:TextBox>
               </td>
            </tr>
               <tr>
                <td>
                    
                </td>
                        

               <td class="auto-style1">
                   <asp:Button ID="diseaseSaveButton" runat="server" Text="Save" OnClick="diseaseSaveButton_Click" />
               </td>
            </tr>
        </table>
        <br/>
        <asp:Label ID="msgLabel" runat="server"></asp:Label> <br/>
        <asp:GridView ID="diseaseGridView" runat="server" AllowPaging="True" PageSize="4" OnPageIndexChanging="diseaseGridView_PageIndexChanging" OnSelectedIndexChanging="diseaseGridView_SelectedIndexChanging">
             <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="4" />
        </asp:GridView>
    </div>
</asp:Content>
