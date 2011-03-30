<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="ERP.Manutenção.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Log In
    </h2>
    <p>
        Please enter your username and password.
        <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">Register</asp:HyperLink> if you don't have an account.
    </p>
    <p>
                        <asp:Label ID="UserNameLabel" runat="server" 
            AssociatedControlID="tbUserName">Login:</asp:Label>
    </p>
    <p>
                        <asp:TextBox ID="tbUserName" runat="server" 
            CssClass="textEntry"></asp:TextBox>
    </p>
    <p>
                        <asp:Label ID="PasswordLabel" runat="server" 
            AssociatedControlID="tbPassword">Senha:</asp:Label>
    </p>
    <p>
                        <asp:TextBox ID="tbPassword" runat="server" CssClass="passwordEntry" 
                            TextMode="Password"></asp:TextBox>
    </p>
    <p>
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                        ValidationGroup="LoginUserValidationGroup" 
            onclick="LoginButton_Click"/>
    </p>
</asp:Content>
