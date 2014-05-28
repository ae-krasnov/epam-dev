<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="WebFormClient.Default" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
    
        <asp:GridView ID="entityGrid" runat="server">
        </asp:GridView>
    
        <asp:Label ID="DeleteByIdLabel" runat="server" Text="Удалить по Id:"></asp:Label>
    
    </div>
        <p>
            <asp:TextBox ID="DelByIdTexBox" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Button ID="DeleteByIdButton" runat="server" OnClick="DeleteByIdButton_Click" Text="Удалить" />
    
        <asp:Label ID="ErrorRemoveLabel" runat="server"></asp:Label>
    
        </p>
        <p id="findByIdLabel">
            Поиск по id:</p>
        <p>
            <asp:TextBox ID="FindByIdTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="FindByIdButton" runat="server" OnClick="FindByIdButton_Click" style="margin-bottom: 0px" Text=" Найти" Width="67px" />
            <asp:Label ID="ErrorFindLabel" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="FoundByIdLabel" runat="server"></asp:Label>
        </p>
</asp:Content>
<asp:Content ContentPlaceHolderID="CaptchaHolder" runat="server">
    <div>
    <asp:Panel ID="CaptchaPanel" runat="server" Visible="false" Height="113px">
        <asp:CustomValidator ID="CaptchaValidator" runat="server" ControlToValidate="UserCaptchaInputTextBox" OnServerValidate="CAPTCHAValidate" ErrorMessage="Попробуйте снова">
            </asp:CustomValidator>
        <div>
        <asp:Image ID="CaptchaImage" ImageUrl="~/CaptchaHandler.ashx" runat="server" Width="132px" Height="30px" />
        <asp:TextBox ID="UserCaptchaInputTextBox" runat="server" Width="132px" Height="18px"></asp:TextBox>
        <asp:Button ID="ApplyCaptchaButton" runat="server" Text="Применить" OnClick="ApplyCaptchaButton_Click" />
            </div>
    </asp:Panel>
        </div>
</asp:Content>

