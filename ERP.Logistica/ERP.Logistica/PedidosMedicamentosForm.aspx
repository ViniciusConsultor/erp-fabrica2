<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PedidosMedicamentosForm.aspx.cs" Inherits="ERP.Logistica.PedidosMedicamentosForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
        Text="Pedido de Medicamento"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lbQuant" runat="server" Text="Quantidade"></asp:Label>
    &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToValidate="tbQuant" 
        ErrorMessage="* Deve Conter um Valor Numérico Maior que 0" ForeColor="Red" 
        Operator="GreaterThan" Type="Integer" ValueToCompare="0"></asp:CompareValidator>
    <br />
    <asp:TextBox ID="tbQuant" runat="server" Font-Size="Small" Height="20px" 
        Width="98px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbMedForn" runat="server" Text="Medicamento e Fornecedor"></asp:Label>
    &nbsp;<asp:RequiredFieldValidator ID="rfvMedForn" runat="server" 
        ControlToValidate="ddlMedForn" ErrorMessage="* Campo Obrigatório" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:DropDownList ID="ddlMedForn" runat="server" Height="22px" Width="403px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lbEstado" runat="server" Text="Estado do Pedido"></asp:Label>
    <asp:RadioButtonList ID="rblEfetuado" runat="server">
        <asp:ListItem Value="0">Estornado</asp:ListItem>
        <asp:ListItem Value="1" Selected="True">Efetuado</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:Button ID="btnOK" runat="server" onclick="btnOK_Click" Text="Executar" 
        Width="100px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" Width="100px" 
    onclick="btnCancel_Click" CausesValidation="False" />
    <br />
    <asp:HiddenField ID="hfId" runat="server" Value="Novo" />
</asp:Content>
