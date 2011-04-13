<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estoques.aspx.cs" Inherits="ERP.Logistica.Estoque" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
            Text="Lista de Medicamentos no Estoque"></asp:Label>
    <br />
    <asp:GridView ID="gvEstoque" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id" onrowediting="gvEstoque_RowEditing" 
        onrowdeleting="gvEstoque_RowDeleting">
        <Columns>
<asp:BoundField DataField="Id" HeaderText="Código"></asp:BoundField>
            <asp:BoundField DataField="Medicamento" HeaderText="Medicamento" />
            <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" />
            <asp:BoundField DataField="Validade" HeaderText="Validade" />
            <asp:BoundField DataField="Localizacao" HeaderText="Localização" />
            <asp:CommandField HeaderText="Edit" 
                ShowEditButton="True" />
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnNovo" runat="server" onclick="btnNovo_Click" 
        Text="Nova Entrada no Estoque" />
    <br />
    <br />
    <br />
</asp:Content>
