<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewState.aspx.cs" Inherits="StateManagement.View_State" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <title>View State</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="StateViewGrid" runat="server">
</asp:GridView>

</asp:Content>
