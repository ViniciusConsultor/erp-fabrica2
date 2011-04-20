<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CatalogoEquipamentos.aspx.cs" Inherits="ERP.Logistica.CatalogoEquipamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
            Text="Lista de Catálogos de Equipamentos"></asp:Label>
    <br />
<asp:GridView ID="gvCatalogo" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id" onrowdeleting="gvCatalogo_RowDeleting" 
        onrowediting="gvCatalogo_RowEditing">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Código" />
        <asp:BoundField DataField="Equipamento" HeaderText="Equipamento" />
        <asp:BoundField DataField="Fornecedor" HeaderText="Fornecedor" />
        <asp:BoundField DataField="Preco_Unitario" HeaderText="Preço" />
        <asp:BoundField DataField="Vigencia_Inicio" HeaderText="Vigencia_Inicio" 
            DataFormatString="&quot;{0:dd/MM/yyyy}&quot;" />
        <asp:CommandField HeaderText="Remover" ShowDeleteButton="True" 
            DeleteText="Remover" />
        <asp:CommandField HeaderText="Editar" ShowEditButton="True" EditText="Editar" />
    </Columns>
</asp:GridView>
<br />
<asp:Button ID="btnAdicionar" runat="server" onclick="btnAdicionar_Click" 
    Text="Adicionar" />
<br />
</asp:Content>
