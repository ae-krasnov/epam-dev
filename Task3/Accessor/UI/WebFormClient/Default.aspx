<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
        <asp:GridView ID="entityGrid" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
    
        <asp:Label ID="DeleteByIdLabel" runat="server" Text="Удалить по Id:"></asp:Label>
    
    </div>
        <p>
            <asp:TextBox ID="DelByIdTexBox" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Button ID="DeleteByIdButton" runat="server" OnClick="DeleteByIdButton_Click" Text="Удалить" />
        </p>
        <p id="findByIdLabel">
            Поиск по id:</p>
        <p>
            <asp:TextBox ID="FindByIdTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="FindByIdButton" runat="server" OnClick="FindByIdButton_Click" style="margin-bottom: 0px" Text=" Найти" Width="67px" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="FoundByIdLabel" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
