<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="ERP.Manutenção.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="lbRegistro" runat="server" Font-Size="XX-Large" 
        Text="Registro do Usuário"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lbLogin" runat="server" Text="Login: "></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="tbUserName" ErrorMessage="* Login é Obrigatório" 
        ForeColor="Red" ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="tbUserName" runat="server" CssClass="textEntry"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbEmail" runat="server" Text="E-mail: "></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="tbEmail" ErrorMessage="* E-mail é Obrigatório" 
        ForeColor="Red" ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="tbEmail" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="tbEmail" 
        ErrorMessage="* E-mail deve estar na forma user@mail.com" ForeColor="Red" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        ValidationGroup="RegisterUserValidationGroup"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="lbSenha" runat="server" Text="Senha: "></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="tbPassword" ErrorMessage="* Senha é Obrigatória." 
        ForeColor="Red" ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="tbPassword" runat="server" CssClass="passwordEntry" 
        TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbConfirma" runat="server" Text="Confirmar Senha: "></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="tbConfirmPassword" 
        ErrorMessage="* Confirmação de Senha é Obrigatória" ForeColor="Red" 
        ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="tbConfirmPassword" runat="server" CssClass="passwordEntry" 
        TextMode="Password"></asp:TextBox>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="tbPassword" ControlToValidate="tbConfirmPassword" 
        ErrorMessage="* Confirmação não está igual a Senha" ForeColor="Red" 
        ValidationGroup="RegisterUserValidationGroup"></asp:CompareValidator>
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
