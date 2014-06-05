<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnonymousProfile.aspx.cs" Inherits="StateManagement.AnonymousProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Anonymous Profile</title>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
    <tr>
        <td>
            <asp:Label ID="MessageLabel" runat="server" Text="Сохранить в профиль:"></asp:Label>
            <asp:TextBox ID="InfoForProfileTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="SaveProfileInfoButton" runat="server" Text="Сохранить" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="ProfileInfoLabel" runat="server"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
