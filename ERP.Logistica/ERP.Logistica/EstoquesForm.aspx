<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstoquesForm.aspx.cs" Inherits="ERP.Logistica.EstoqueForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
    Text="Gerenciamento de Estoque"></asp:Label>
<br />
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="Medicamento"></asp:Label>
<asp:RequiredFieldValidator ID="rfvMedicamento" runat="server" 
    ControlToValidate="ddlMedicamento" ErrorMessage="* Campo Obrigatório" 
    ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<asp:DropDownList ID="ddlMedicamento" runat="server" style="margin-bottom: 0px">
</asp:DropDownList>
<br />
<br />
<asp:Label ID="Label3" runat="server" Text="Quantidade"></asp:Label>
    <asp:RequiredFieldValidator ID="rfvQuantidade" runat="server" 
        ControlToValidate="tbQuantidade" ErrorMessage="* Campo Obrigatório" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToValidate="tbQuantidade" 
        ErrorMessage="* Deve Conter um Valor Numérico Maior ou Igual a 0" 
        ForeColor="Red" Operator="GreaterThanEqual" ValueToCompare="0"></asp:CompareValidator>
<br />
<asp:TextBox ID="tbQuantidade" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label4" runat="server" Text="Validade"></asp:Label>
    <asp:RequiredFieldValidator ID="rfvValidade" runat="server" 
        ControlToValidate="tbValidade" ErrorMessage="* Campo Obrigatório" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="tbValidade" ErrorMessage="*Formato de Data Inválido" 
        ForeColor="Red" 
        ValidationExpression="(([0-1][0-9]|2[0-9])/02/(2000|2004|2008|2012|2016|2020|2024|2028|2032|2036))|(([0-1][0-9]|2[0-8])/02/[0-9][0-9][0-9][0-9])|(([0-2][0-9]|30)/(04|06|09|11)/[0-9][0-9][0-9][0-9])|(([0-2][0-9]|3[0-1])/(01|03|05|07|08|10|12)/[0-9][0-9][0-9][0-9])"></asp:RegularExpressionValidator>
<br />
<asp:TextBox ID="tbValidade" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label7" runat="server" Text="Localização"></asp:Label>
<br />
<asp:TextBox ID="tbLocalizacao" runat="server"></asp:TextBox>
<br />
<br />
<asp:Button ID="btnOk" runat="server" onclick="btnOk_Click" Text="Salvar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
    onclick="btnCancelar_Click" CausesValidation="False" />
<br />
<br />
<asp:HiddenField ID="hfId" runat="server" Value="Novo" />
<br />
<br />
</asp:Content>
