<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="EventRegistration.Default" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 30%;
            text-align: right;
        }
        .auto-style2 {
            width: 230px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:  100%">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="labelEvent" runat="server" Text="Event:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="dropDownListEvents" runat="server" 
                        DataSourceID="SqlDataSource1" DataTextField="Title" DataValueField="Id">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="labelFirstName" runat="server" Text="First Name:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="textFirstName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="textFirstName" ErrorMessage="First name is required."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="labelLastName" runat="server" Text="Last Name:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="textLastName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="textLastName" ErrorMessage="Last name is required."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="labelEmail" runat="server" Text="Email:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="textEmail" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="textEmail" Display="Dynamic" 
                        ErrorMessage="Email is required."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style2">
                    <asp:Button ID="buttonSubmit" runat="server" Text="Submit" PostBackUrl="~/ResultsPage.aspx" />
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="textEmail" Display="Dynamic" 
                        ErrorMessage="Enter a valid email." 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style2">
                    <asp:Label ID="labelResult" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:EventsConnectionString %>" 
        SelectCommand="SELECT [Id], [Title], [Date], [Location] FROM [Events]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
