<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Historico.aspx.cs" Inherits="ERP.Logistica.Historico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvMedicamento" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id" 
        onrowediting="gvMedicamento_RowEditing">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Código" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
            <asp:BoundField DataField="Medida" HeaderText="Medida" />
            <asp:CommandField HeaderText="Historico" EditText="Historico" 
                ShowEditButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
