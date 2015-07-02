<%@ Page Title="" Language="C#"  EnableEventValidation="false" MasterPageFile="~/UI/CommunityMedicine.Master" AutoEventWireup="true" CodeBehind="DiseaseWiseReport.aspx.cs" Inherits="CommunityMedicine.UI.DiseaseWiseReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        

        <script src="../Scripts/jquery-2.1.4.min.js"></script>
        <script src="../Scripts/jquery-ui-1.11.4.min.js"></script>
        <br/><br/>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Disease Name"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                     <asp:DropDownList ID="diseaseDropDownList" runat="server" Width="256px"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="showDiseaseButton" runat="server" Text="Show" OnClick="showDieseaseButton_Click" Width="167px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Date Between"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="firstDateTextBox" Text="Click to select Date" runat="server"></asp:TextBox>
                </td>
                <td>
                     <asp:Label ID="Label3" runat="server" Text="And"></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="lastDateTextBox" Text="Click to select Date" runat="server"></asp:TextBox>
                </td>
                
            </tr>
        </table>
        

       

       

        
       

       
       
       
        <asp:Panel ID="reportPanel" runat="server">
            <asp:GridView ID="diseaseWiseGridView" runat="server" AllowPaging="True" OnSelectedIndexChanging="diseaseWiseGridView_SelectedIndexChanging" PageSize="5" OnPageIndexChanging="diseaseWiseGridView_PageIndexChanging">
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="5" />
            </asp:GridView>
        </asp:Panel>
        <asp:Button ID="doPDF" runat="server" Text="PDF" OnClick="doPDF_Click" Width="124px" />


        <script type="text/javascript">
            //$("#lastDateTextBox").datepicker();
            $("#<%= lastDateTextBox.ClientID %>").datepicker({
                dateFormat: "yy-mm-dd"
            });
            $("#<%= firstDateTextBox.ClientID %>").datepicker({
                dateFormat: "yy-mm-dd"
                }
                );
            
        </script>

        <style type="text/css">
            .style1 {
                color: #800000;
                background: black;
            }

            .style2 {
                font-size: x-large;
            }

            .style3 {
                font-size: x-large;
                color: #990000;
            }
        </style>

    </div>

</asp:Content>
