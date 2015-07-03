<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CommunityMedicine.Master" AutoEventWireup="true" CodeBehind="MedicineEntryPage.aspx.cs" Inherits="CommunityMedicine.UI.MedicineEntryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-1.4.4.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="medicineLabel" runat="server" Text="Name Of Medicine With Mg/Ml"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="medicineTextBox" TextMode="MultiLine" runat="server" Width="312px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="medicineSaveButton" runat="server" Text="Save" OnClick="medicineSaveButton_Click" Height="36px" Width="139px" />
                </td>
            </tr>

        </table>
        <br />
        <asp:Label ID="msgLabel" runat="server"></asp:Label><br />
        <asp:GridView ID="medicineGridView" runat="server" AllowPaging="True" OnPageIndexChanging="medicineGridView_PageIndexChanging" PageSize="5">
            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="5" />
        </asp:GridView>
        <script type ="text/javascript" >                
            $(document).ready(function () {  
                $("#form1").validate({  
                    rules: {  
                        //This section we need to place our custom rule   
                        //for the control.  
                        <%=medicineTextBox.UniqueID %>:{  
                        required:true  
                    },   
                },  
                messages: {  
                    //This section we need to place our custom   
                    //validation message for each control.  
                    <%=medicineTextBox.UniqueID %>:{  
                          required: "Name is required."  
                      },  
                },  
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
