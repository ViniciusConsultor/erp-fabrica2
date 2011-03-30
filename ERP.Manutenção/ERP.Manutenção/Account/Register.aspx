<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="ERP.Manutenção.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="lbRegistro" runat="server" Font-Size="XX-Large" 
        Text="Registro do Usuário"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lbLogin" runat="server" Text="Login:"></asp:Label>
    <br />
    <asp:TextBox ID="tbUserName" runat="server" CssClass="textEntry"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbEmail" runat="server" Text="E-mail:"></asp:Label>
    <br />
    <asp:TextBox ID="tbEmail" runat="server" CssClass="textEntry"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbSenha" runat="server" Text="Senha:"></asp:Label>
    <br />
    <asp:TextBox ID="tbPassword" runat="server" CssClass="passwordEntry" 
        TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbConfirma" runat="server" Text="Confirmar Senha"></asp:Label>
    <br />
    <asp:TextBox ID="tbConfirmPassword" runat="server" CssClass="passwordEntry" 
        TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:HiddenField ID="hfId" runat="server" Value="Novo" />
    <br />
    <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" 
        onclick="CreateUserButton_Click" Text="Create User" 
        ValidationGroup="RegisterUserValidationGroup" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" Width="100px" 
    onclick="btnCancel_Click" CausesValidation="False" />
    <br />
</asp:Content>
