<%@ Page Title="" Language="C#" MasterPageFile="~/UI/CommunityMedicine.Master" AutoEventWireup="true" CodeBehind="CenterLoginPage.aspx.cs" Inherits="CommunityMedicine.UI.CenterLoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script src="../Scripts/jquery-1.4.4.min.js"></script>--%>
    <script src="../Scripts/jquery-2.1.4.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
     <div>
    <h1>Center Login</h1>
        <table>
            <tr>
                <td>
                    <asp:Label ID="codeLabel" runat="server" Text="Center Code"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="centerCodeTextBox" runat="server" Width="190px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="passwordLabel" runat="server" Text="Password"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="passwordTextBox" TextMode="Password" runat="server" Width="189px"></asp:TextBox>

                </td>

            </tr>
            <tr>
                <td>
                    <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" Width="118px" />
                </td>
            </tr>
        </table>
        <asp:Label ID="msgLabel" runat="server" ></asp:Label>
         
          <script type ="text/javascript" >                
              $(document).ready(function () {  
                  $("#form1").validate({
                      rules: {
                          //This section we need to place our custom rule   
                          //for the control.  
                          <%=centerCodeTextBox.UniqueID %>: {
                             required: true
                         },
                         <%=passwordTextBox.UniqueID %>: {
                             required: true
                         },
                         
                         
                         messages: {
                             //This section we need to place our custom   
                             //validation message for each control.  
                             <%=centerCodeTextBox.UniqueID %>: {
                                 required: "Name is required."
                             },
                             <%=passwordTextBox.UniqueID %>: {
                                 required: "Description is required."
                             },
                             
                         },
                     }
                 });  
              }); 
              
    </script>  
    </div>
</asp:Content>
