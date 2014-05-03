<%@ Page Title="" Language="C#" MasterPageFile="~/Events.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EventRegistration.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Login ID="Login1" runat="server"></asp:Login>
    <asp:LinkButton ID="RegisterUserLinkButton" runat="server" PostBackUrl="~/Intro/RegisterUser.aspx">Register User</asp:LinkButton>
</asp:Content>
