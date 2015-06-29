<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CommunityMedicine.Master" AutoEventWireup="true" CodeBehind="DiseaseEntryPage.aspx.cs" Inherits="CommunityMedicine.UI.DiseaseEntryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../Scripts/jquery-2.1.4.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    <link href="../Content/DiseaseEntry.css" rel="stylesheet" />
    <div class="main">
        <div class="content">
            <br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Disease Name"></asp:Label>
                    </td>


                    <td class="auto-style1">
                        <asp:TextBox ID="diseaseNameTextBox" runat="server" ClientIDMode="Static" Width="264px" Height="42px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                    </td>


                    <td class="auto-style1">
                        <asp:TextBox ID="descriptionTextBox" TextMode="MultiLine" ClientIDMode="Static" runat="server" Height="73px" Width="265px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Treatment Procedure"></asp:Label>
                    </td>


                    <td class="auto-style1">
                        <asp:TextBox ID="procedureTextBox" TextMode="MultiLine" ClientIDMode="Static" runat="server" Height="61px" Width="262px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>


                    <td class="auto-style1">
                        <asp:Button ID="diseaseSaveButton" runat="server" Text="Save" OnClick="diseaseSaveButton_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="msgLabel" runat="server"></asp:Label>
            <br />
        </div>
        <div class="output">
            <asp:GridView ID="diseaseGridView" runat="server" AllowPaging="True" PageSize="4" OnPageIndexChanging="diseaseGridView_PageIndexChanging" OnSelectedIndexChanging="diseaseGridView_SelectedIndexChanging" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="337px">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="4" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
        </div>
        <script type="text/javascript">                
            $(document).ready(function () {  
                $("#form1").validate({
                    rules: {
                        //This section we need to place our custom rule   
                        //for the control.  
                        <%=diseaseNameTextBox.UniqueID %>: {
                             required: true
                         },
                         <%=descriptionTextBox.UniqueID %>: {
                             required: true
                         },
                         <%=procedureTextBox.UniqueID %>: {
                              required: true
                          },
                         
                         messages: {
                             //This section we need to place our custom   
                             //validation message for each control.  
                             <%=diseaseNameTextBox.UniqueID %>: {
                                 required: "Name is required."
                             },
                             <%=descriptionTextBox.UniqueID %>: {
                                 required: "Description is required."
                             },
                             <%=procedureTextBox.UniqueID %>: {
                                 required: "Treatment procedure is required."
                             }
                         },
                     }
                 });  
             });         
        </script>
        <style type="text/css">
            label.error {
                color: red;
                display: inline-flex;
            }
        </style>
    </div>
</asp:Content>
