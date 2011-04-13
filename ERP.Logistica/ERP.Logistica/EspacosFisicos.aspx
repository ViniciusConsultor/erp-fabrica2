<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EspacosFisicos.aspx.cs" Inherits="ERP.Logistica.EspacosFisicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
            Text="Lista de Espaços Físicos"></asp:Label>
        <br />
    <asp:GridView ID="gvEspacos" runat="server" 
    AutoGenerateColumns="False" DataKeyNames="Id" 
    onrowdeleting="gvEspacos_RowDeleting" onrowediting="gvEspacos_RowEditing" 
            ShowHeaderWhenEmpty="True">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Codigo" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Andar" HeaderText="Andar" />
            <asp:BoundField DataField="Numero" HeaderText="Numero" />
            <asp:CommandField DeleteText="Remover" 
            ShowDeleteButton="True" />
            <asp:CommandField EditText="Editar" 
            ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnAdicionar" runat="server" onclick="btnAdicionar_Click" 
        Text="Cadastrar Espaço" Width="155px" />
        <br />
</asp:Content>
