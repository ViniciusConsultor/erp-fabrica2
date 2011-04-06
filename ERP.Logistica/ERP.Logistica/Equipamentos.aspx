<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Equipamentos.aspx.cs" Inherits="ERP.Logistica.Equipamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
            Text="Lista de Equipamentos"></asp:Label>
        <br />
<asp:GridView ID="gvEquipamento" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="Id" onrowdeleting="gvEquipamento_RowDeleting" 
    onrowediting="gvEquipamento_RowEditing">
    <Columns>
        <asp:BoundField DataField="Nome" HeaderText="Nome" />
        <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
        <asp:CommandField DeleteText="Remover" HeaderText="Remover" 
            ShowDeleteButton="True" />
        <asp:CommandField EditText="Editar" HeaderText="Editar" ShowEditButton="True" />
    </Columns>
</asp:GridView>
<br />
<asp:Button ID="btnAdicionar" runat="server" onclick="btnAdicionar_Click" 
    Text="Adicionar" />
<br />
</asp:Content>
