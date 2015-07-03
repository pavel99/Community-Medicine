<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CenterMaster.Master" AutoEventWireup="true" CodeBehind="DoctorEntryPage.aspx.cs" Inherits="CommunityMedicine.UI.DoctorEntryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/jquery-1.4.4.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    <div>
        <h1>Doctor Entry</h1>
        <table>
            <tr>
                <td><asp:Label ID="nameLabel" runat="server" Text="Name"></asp:Label></td>
                <td>
                    <asp:TextBox ID="doctorNameTextBox" runat="server" Width="231px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="degreeLabel" runat="server" Text="Degree"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="doctorDegreeTextBox" runat="server" Width="230px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="specializationLabel" runat="server" Text="Specialization"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="specializationTextBox" runat="server" Width="230px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="doctorSaveButton" runat="server" Text="Save" OnClick="doctorSaveButton_Click" Width="165px" />
                </td>
            </tr>

        </table>
        <asp:Label ID="msgLabel" runat="server"></asp:Label>
        
        
        <script type ="text/javascript" >                
            $(document).ready(function () {  
                $("#form1").validate({  
                    rules: {  
                        //This section we need to place our custom rule   
                        //for the control.  
                        <%=doctorNameTextBox.UniqueID %>:{  
                             required:true  
                        },   
                         <%=doctorDegreeTextBox.UniqueID %>:{  
                             required:true  
                         }, 
                         <%=specializationTextBox.UniqueID %>:{  
                             required:true  
                         }, 
                     },  
                     messages: {  
                         //This section we need to place our custom   
                         //validation message for each control.  
                         <%=doctorNameTextBox %>:{  
                        required: "Name is required."  
                         },  
                         <%=doctorDegreeTextBox.UniqueID %>:{  
                             required: "Degree is required."  
                         },  
                         <%=specializationTextBox.UniqueID %>:{  
                             required: "Specialization is required."  
                         },  
                },  
                 });  
             });         
    </script> 
        
    </div>
</asp:Content>
