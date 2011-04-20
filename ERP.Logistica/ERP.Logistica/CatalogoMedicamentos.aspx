<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CatalogoMedicamentos.aspx.cs" Inherits="ERP.Logistica.Catalago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
            Text="Lista de Catálogos de Medicamentos"></asp:Label>
    <br />
    <asp:GridView ID="gvCatalogo" runat="server" AutoGenerateColumns="False" 
        onrowdeleting="gvCatalogo_RowDeleting" 
        onrowediting="gvCatalogo_RowEditing" DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Código" />
            <asp:BoundField DataField="Medicamento" HeaderText="Medicamento" />
            <asp:BoundField DataField="Fornecedor" HeaderText="Fornecedor" />
            <asp:BoundField DataField="Preco_Unitario" HeaderText="Preço" />
            <asp:BoundField DataField="Vigencia_Inicio" HeaderText="Vigencia_Inicio" 
                DataFormatString="&quot;{0:dd/MM/yyyy}&quot;" />
            <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnAdicionar" runat="server" onclick="btnAdicionar_Click" 
        Text="Adicionar" />
    <br />
</asp:Content>
