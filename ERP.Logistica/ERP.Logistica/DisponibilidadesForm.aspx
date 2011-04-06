<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisponibilidadesForm.aspx.cs" Inherits="ERP.Logistica.DisponibilidadesForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
        Text="Disponibilidade"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lbNomeEquip" runat="server" Text="Nome do Equipamento (Codigo)"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlEquip" runat="server" Height="19px" Width="315px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lbEspaco" runat="server" Text="Espaço Fisico"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlEspaco" runat="server" Height="19px" Width="315px">
    </asp:DropDownList>
    <br />
    <br />
    <br />
    <asp:Button ID="btnOK" runat="server" onclick="btnOK_Click" Text="Salvar" 
        Width="100px" style="margin-bottom: 0px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" Width="100px" 
    onclick="btnCancel_Click" CausesValidation="False" />
    <br />
    <asp:HiddenField ID="hfId" runat="server" Value="Novo" />
</asp:Content>
