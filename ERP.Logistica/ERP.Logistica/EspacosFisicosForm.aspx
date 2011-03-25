<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EspacosFisicosForm.aspx.cs" Inherits="ERP.Logistica.EspacosFisicosForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
        Text="Espaço Fisico"></asp:Label>
    <br />
<br />
    <asp:Label ID="lbNome" runat="server" Text="Nome"></asp:Label>
    <br />
    <asp:TextBox ID="tbNome" runat="server" Font-Size="Small" Height="20px" 
        Width="200px" MaxLength="50"></asp:TextBox>
    <br />
<br />
    <asp:Label ID="lbAndar" runat="server" Text="Andar"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToValidate="tbAndar" 
        ErrorMessage="* Deve Conter um Valor Numérico Maior ou Igual a 0" ForeColor="Red" 
        Operator="GreaterThanEqual" Type="Integer" ValueToCompare="0"></asp:CompareValidator>
    <br />
    <asp:TextBox ID="tbAndar" runat="server" Font-Size="Small" Height="20px" 
        Width="82px"></asp:TextBox>
    <br />
<br />
    <asp:Label ID="lbNumero" runat="server" Text="Numero"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:CompareValidator ID="CompareValidator2" runat="server" 
        ControlToValidate="tbNumero" 
        ErrorMessage="* Deve Conter um Valor Numérico Maior ou Igual a 0" ForeColor="Red" 
        Operator="GreaterThanEqual" Type="Integer" ValueToCompare="0"></asp:CompareValidator>
    <br />
    <asp:TextBox ID="tbNumero" runat="server" Font-Size="Small" Height="20px" 
        Width="82px"></asp:TextBox>
    &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
    runat="server" ControlToValidate="tbNumero" ErrorMessage="* Obrigatório" 
    ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
<br />
<br />
    <asp:Button ID="btnOK" runat="server" onclick="btnOK_Click" Text="Salvar" 
        Width="100px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" Width="100px" 
    onclick="btnCancel_Click" CausesValidation="False" />
    <br />
    <asp:HiddenField ID="hfId" runat="server" Value="Novo" />
</asp:Content>
