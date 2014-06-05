<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HiddenField.aspx.cs" Inherits="StateManagement.HiddenField" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Hidden Field</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 219px;
        }
        .auto-style3 {
            width: 132px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="MessageLabel" runat="server" Text="Сообщение для скрытого поля"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="HideFieldTextBox" runat="server" style="margin-left: 0px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="SendToHideFieldButton" runat="server" OnClick="SendToHideFieldButton_Click" style="margin-left: 0px" Text="Отправить" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="FromHideFieldLabel" runat="server"></asp:Label>
            </td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
