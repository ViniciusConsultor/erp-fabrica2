<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CatalogoEquipamentosForm.aspx.cs" Inherits="ERP.Logistica.CatalogoEquipamentosForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
    Text="Catálogos Equipamentos"></asp:Label>
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="Fornecedor"></asp:Label>
    <asp:RequiredFieldValidator ID="rfvFornecedor" runat="server" 
        ControlToValidate="ddlFornecedor" ErrorMessage="* Campo Obrigatório" 
        ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<asp:DropDownList ID="ddlFornecedor" runat="server">
</asp:DropDownList>
<br />
<br />
<asp:Label ID="Label3" runat="server" Text="Equipamento"></asp:Label>
    <asp:RequiredFieldValidator ID="Equipamento" runat="server" 
        ControlToValidate="ddlEquipamento" ErrorMessage="* Campo Obrigatório" 
        ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<asp:DropDownList ID="ddlEquipamento" runat="server">
</asp:DropDownList>
<br />
<br />
<asp:Label ID="Label4" runat="server" Text="Preço Unitário"></asp:Label>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToValidate="tbPreco" 
        ErrorMessage="* Deve Conter um Valor Numérico Maior ou Igual a 0" 
        ForeColor="Red" Operator="GreaterThanEqual" Type="Double" 
        ValueToCompare="0"></asp:CompareValidator>
<br />
<asp:TextBox ID="tbPreco" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPreco" runat="server" 
        ControlToValidate="tbPreco" ErrorMessage="* Campo Obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
<asp:Label ID="Label5" runat="server" Text="Vigencia Inicio"></asp:Label>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
    runat="server" ControlToValidate="tbVigencia" 
    ErrorMessage="*Formato de Data Inválido" ForeColor="Red" 
    ValidationExpression="(([0-1][0-9]|2[0-9])/02/(2000|2004|2008|2012|2016|2020|2024|2028|2032|2036))|(([0-1][0-9]|2[0-8])/02/[0-9][0-9][0-9][0-9])|(([0-2][0-9]|30)/(04|06|09|11)/[0-9][0-9][0-9][0-9])|(([0-2][0-9]|3[0-1])/(01|03|05|07|08|10|12)/[0-9][0-9][0-9][0-9])"></asp:RegularExpressionValidator>
<br />
<asp:TextBox ID="tbVigencia" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvVigencia" runat="server" 
        ControlToValidate="tbVigencia" ErrorMessage="* Campo Obrigatório" 
        ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
<asp:Button ID="btnOk" runat="server" onclick="btnOk_Click" Text="Salvar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
    Text="Cancelar" />
<br />
    <asp:HiddenField ID="hfId" runat="server" Value="Novo" />
    <br />
<br />
</asp:Content>
