<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableViewState="false" CodeBehind="ControlState.aspx.cs" Inherits="StateManagement.ControlState" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Control state</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="ControlStateLabel" runat="server" Text="Текст сообщения сохраняется в Control State"></asp:Label>
    <cust:CustomField ID="CustomControl" runat="server"></cust:CustomField>
</asp:Content>
