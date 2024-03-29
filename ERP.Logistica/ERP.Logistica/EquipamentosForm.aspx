﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquipamentosForm.aspx.cs" Inherits="ERP.Logistica.EquipamentosForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
    Text="Equipamento"></asp:Label>
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="Nome"></asp:Label>
<asp:RequiredFieldValidator ID="rfvNome" runat="server" 
    ControlToValidate="tbnome" ErrorMessage="* Campo Obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="tbNome" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label3" runat="server" Text="Descrição"></asp:Label>
<br />
<asp:TextBox ID="tbDescricao" runat="server"></asp:TextBox>
<br />
<br />
<asp:Button ID="btnOk" runat="server" onclick="btnOk_Click" Text="Salvar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
    Text="Cancelar" CausesValidation="False" />
&nbsp;
<br />
<br />
<asp:HiddenField ID="hfId" runat="server" Value="Novo" />
<br />
<br />
</asp:Content>
