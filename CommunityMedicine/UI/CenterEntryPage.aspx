<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CommunityMedicine.Master" AutoEventWireup="true" CodeBehind="CenterEntryPage.aspx.cs" Inherits="CommunityMedicine.UI.CenterEntryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-2.1.4.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
     <div>
        <h1>Create New Center</h1>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="centerNameTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="District"></asp:Label>

                </td>
                <td>
                    <asp:DropDownList ID="districtDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="districtDropDownList_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Thana"></asp:Label>

                </td>
                <td>
                    <asp:DropDownList ID="thanaDropDownList" runat="server"></asp:DropDownList>
                </td>
            </tr>
              <tr>
                <td>

                </td>
                <td>
                    <asp:Button ID="centerSaveButton" runat="server" Text="Save" OnClick="centerSaveButton_Click" />
                </td>
            </tr>
        </table><br/>
        <asp:Label ID="msgLabel" runat="server"></asp:Label>
         
         
         <script type ="text/javascript" >                
             $(document).ready(function () {  
                 $("#form1").validate({  
                     rules: {  
                         //This section we need to place our custom rule   
                         //for the control.  
                         <%=centerNameTextBox.UniqueID %>:{  
                        required:true  
                    },   
                },  
                messages: {  
                    //This section we need to place our custom   
                    //validation message for each control.  
                    <%=centerNameTextBox.UniqueID %>:{  
                          required: "Name is required."  
                      },  
                },  
            });  
        });         
    </script> 
          
         <style type ="text/css" >  
        label.error {             
            color: red;   
            display:inline-flex ;                 
        }  
</style>
    
    </div>
    
    
    
    

</asp:Content>
