<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GerenciaEstMed.aspx.cs" Inherits="ERP.Logistica.GerenciaEstMed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label2" runat="server" Font-Size="Large" ForeColor="Black" 
        Text="Gerência de Estoque"></asp:Label>
    <asp:GridView ID="gvGerencia" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id" onrowediting="gvGerencia_RowEditing">
    <Columns>
        <asp:BoundField DataField="Medicamento" HeaderText="Medicamento" />
        <asp:BoundField DataField="Quantidade" HeaderText="Quantidade Total" />
        <asp:CommandField EditText="Adicionar/Remover" HeaderText="Adicionar/Remover" 
            ShowEditButton="True" />
    </Columns>
</asp:GridView>
</asp:Content>
