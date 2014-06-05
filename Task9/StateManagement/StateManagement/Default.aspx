<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="StateManagement.Default" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="auto-style1">
    <tr>
        <td>
            <asp:HyperLink ID="ViewStateLink" runat="server" NavigateUrl="~/ViewState.aspx">View State</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="ControlStateLink" runat="server" NavigateUrl="~/ControlState.aspx">Control State</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="HiddenFieldLink" runat="server" NavigateUrl="~/HiddenField.aspx">Hidden Field</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="CoockiesLink" runat="server" NavigateUrl="~/Coockies.aspx">Coockies</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="ApplicationStateLink" runat="server" NavigateUrl="~/ApplicationState.aspx">Application State</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="SessionLink" runat="server" NavigateUrl="~/SessionState.aspx">Session state</asp:HyperLink>
        </td>
    </tr>
    </table>

</asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>
</asp:Content>



