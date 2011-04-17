<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PedidosMedicamentosForm.aspx.cs" Inherits="ERP.Logistica.PedidosMedicamentosForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
        Text="Pedido de Medicamento"></asp:Label>
    <br />
    <br />
        <asp:Label ID="lbVerba" runat="server" Text="Verba Disponível:"></asp:Label>
        &nbsp;<asp:Label ID="lbValorVerba" runat="server" Text="0"></asp:Label>
        &nbsp;<asp:CustomValidator ID="vVerba" runat="server" 
    ErrorMessage="* Não Há Verba Suficiente" ForeColor="Red"></asp:CustomValidator>
<br />
    <br />
    <asp:Label ID="lbQuant" runat="server" Text="Quantidade"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToValidate="tbQuant" 
        ErrorMessage="* Deve Conter um Valor Numérico Maior que 0" ForeColor="Red" 
        Operator="GreaterThan" Type="Integer" ValueToCompare="0"></asp:CompareValidator>
    <br />
    <asp:TextBox ID="tbQuant" runat="server" Font-Size="Small" Height="20px" 
        Width="98px"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="rfvMedForn" runat="server" 
        ControlToValidate="tbQuant" ErrorMessage="* Campo Obrigatório" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lbMedForn" runat="server" 
        Text="Medicamento - Fornecedor - Preço"></asp:Label>
    &nbsp;<br />
    <asp:DropDownList ID="ddlMedForn" runat="server" Height="22px" Width="403px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lbEstado" runat="server" Text="Estado do Pedido"></asp:Label>
    <asp:RadioButtonList ID="rblEfetuado" runat="server">
        <asp:ListItem Value="0">Estornado</asp:ListItem>
        <asp:ListItem Value="2" Selected="True">Efetuado</asp:ListItem>
    </asp:RadioButtonList>
    <br />
<asp:Label ID="lbValidade" runat="server" Text="Validade (dd/mm/aaaa)"></asp:Label>
    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
    ControlToValidate="tbValidade" ErrorMessage="* Formato de Data Inválido" 
    ForeColor="Red" 
    
        ValidationExpression="(([0-1][0-9]|2[0-9])/02/(2000|2004|2008|2012|2016|2020|2024|2028|2032|2036))|(([0-1][0-9]|2[0-8])/02/[0-9][0-9][0-9][0-9])|(([0-2][0-9]|30)/(04|06|09|11)/[0-9][0-9][0-9][0-9])|(([0-2][0-9]|3[0-1])/(01|03|05|07|08|10|12)/[0-9][0-9][0-9][0-9])"></asp:RegularExpressionValidator>
    <br />
<asp:TextBox ID="tbValidade" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="vValidadeObrig" runat="server" 
        ControlToValidate="tbQuant" ErrorMessage="* Campo Obrigatório" 
        ForeColor="Red" ValidationGroup="efetuado"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="btnOK" runat="server" onclick="btnOK_Click" Text="Executar" 
        Width="100px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" Width="100px" 
    onclick="btnCancel_Click" CausesValidation="False" />
    <br />
    <asp:HiddenField ID="hfId" runat="server" Value="Novo" />
</asp:Content>
