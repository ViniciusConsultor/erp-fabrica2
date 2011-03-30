<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicamentos.aspx.cs" Inherits="ERP.Logistica.Medicamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:GridView ID="gvMedicamento" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id" onrowdeleting="gvMedicamento_RowDeleting" 
        onrowediting="gvMedicamento_RowEditing">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Código" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
            <asp:BoundField DataField="Medida" HeaderText="Medida" />
            <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" />
            <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Button ID="btnAdicionar" runat="server" onclick="btnAdicionar_Click" 
    Text="Adicionar" />
    <p>
    </p>
</asp:Content>
