<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="ERP.Logistica.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Log In
    </h2>
    <p>
        Coloque seu Login e Senha.
        <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="False">Registre-se</asp:HyperLink> 
        caso não possua uma conta.
    </p>
    <p>
                        <asp:Label ID="UserNameLabel" runat="server" 
            AssociatedControlID="tbUserName">Login:</asp:Label>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="tbUserName" ErrorMessage="* Login está em branco" 
                            ForeColor="Red" ValidationGroup="LoginUserValidationGroup"></asp:RequiredFieldValidator>
    </p>
    <p>
                        <asp:TextBox ID="tbUserName" runat="server" 
            CssClass="textEntry" MaxLength="50" ViewStateMode="Enabled"></asp:TextBox>
    </p>
    <p>
                        <asp:Label ID="PasswordLabel" runat="server" 
            AssociatedControlID="tbPassword">Senha:</asp:Label>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="tbPassword" ErrorMessage="* Senha está em branco" 
                            ForeColor="Red" ValidationGroup="LoginUserValidationGroup"></asp:RequiredFieldValidator>
    </p>
    <p>
                        <asp:TextBox ID="tbPassword" runat="server" CssClass="passwordEntry" 
                            TextMode="Password" MaxLength="50" ViewStateMode="Enabled"></asp:TextBox>
    </p>
    <p>
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                        ValidationGroup="LoginUserValidationGroup" 
            onclick="LoginButton_Click"/>
    </p>
</asp:Content>
