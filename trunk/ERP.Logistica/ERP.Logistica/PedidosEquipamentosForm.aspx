﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PedidosEquipamentosForm.aspx.cs" Inherits="ERP.Logistica.PedidosEquipamentosForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
        Text="Pedido de Equipamento"></asp:Label>
<br />
<br />
        <asp:Label ID="lbVerba" runat="server" Text="Verba Disponível:"></asp:Label>
        &nbsp;<asp:Label ID="lbValorVerba" runat="server" Text="0"></asp:Label>
        &nbsp;<asp:CustomValidator ID="vVerba" runat="server" 
    ErrorMessage="* Não Há Verba Suficiente" ForeColor="Red"></asp:CustomValidator>
<br />
<br />
    <asp:Label ID="lbEquipForn" runat="server" 
        Text="Equipamento - Fornecedor - Preço"></asp:Label>
    &nbsp;<asp:RequiredFieldValidator ID="rfvMedForn" runat="server" 
        ControlToValidate="ddlEquipForn" ErrorMessage="* Campo Obrigatório" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:DropDownList ID="ddlEquipForn" runat="server" Height="22px" 
    Width="403px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Panel ID="pEdit" runat="server">
        <asp:Label ID="lbEstado" runat="server" Text="Estado do Pedido"></asp:Label>
        <asp:RadioButtonList ID="rblEfetuado" runat="server">
            <asp:ListItem Value="0">Estornado</asp:ListItem>
            <asp:ListItem Value="2" Selected="True">Efetuado</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="lbAloc" runat="server" Text="Alocar Em"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlAloc" runat="server" Height="22px" Width="403px">
        </asp:DropDownList>
        <br />
        <br />
    </asp:Panel>
    <asp:Button ID="btnOK" runat="server" onclick="btnOK_Click" Text="Executar" 
        Width="100px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" Width="100px" 
    onclick="btnCancel_Click" CausesValidation="False" />
    <br />
    <asp:HiddenField ID="hfId" runat="server" Value="Novo" />
</asp:Content>