<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FornecedoresForm.aspx.cs" Inherits="ERP.Logistica.FornecedorForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
    Text="Fornecedor"></asp:Label>
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="Nome"></asp:Label>
<asp:RequiredFieldValidator ID="rfvNome" runat="server" 
    ControlToValidate="tbNome" ErrorMessage="* Campo Obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="tbNome" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label3" runat="server" Text="Telefone"></asp:Label>
<asp:RequiredFieldValidator ID="rfvTelefone" runat="server" 
    ControlToValidate="tbTelefone" ErrorMessage="* Campo Obrigatório" 
    ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="refvTelefone" runat="server" 
        ControlToValidate="tbTelefone" ErrorMessage="*Formato de Telefone Inválido" 
        ForeColor="Red" ValidationExpression="^\(?\d{2}\)?[\s-]?\d{4}-?\d{4}$"></asp:RegularExpressionValidator>
<br />
<asp:TextBox ID="tbTelefone" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
<asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
    ControlToValidate="tbEmail" ErrorMessage="* Campo Obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="refvEmail" runat="server" 
        ControlToValidate="tbEmail" ErrorMessage="*Formato de Email Inválido" 
        ForeColor="Red" 
        ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"></asp:RegularExpressionValidator>
<br />
<asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label5" runat="server" Text="Localização"></asp:Label>
<asp:RequiredFieldValidator ID="rfvLocalizacao" runat="server" 
    ControlToValidate="tbLocalizacao" ErrorMessage="* Campo Obrigatório" 
    ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="tbLocalizacao" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label6" runat="server" Text="Ranking"></asp:Label>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToValidate="tbRanking" 
        ErrorMessage="* Deve Conter um Valor Numérico Maior ou Igual a 0" 
        ForeColor="Red" Operator="GreaterThanEqual" ValueToCompare="0" 
        Type="Integer"></asp:CompareValidator>
<br />
<asp:TextBox ID="tbRanking" runat="server"></asp:TextBox>
<br />
<br />
<asp:Button ID="btnOk" runat="server" onclick="btnOk_Click" Text="Salvar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
    Text="Cancelar" CausesValidation="False" />
<br />
<br />
<asp:HiddenField ID="hfId" runat="server" Value="Novo" />
<br />
<br />
</asp:Content>
