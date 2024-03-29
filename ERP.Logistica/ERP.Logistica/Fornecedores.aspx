﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Fornecedores.aspx.cs" Inherits="ERP.Logistica.Fornecedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
            Text="Lista de Fornecedores"></asp:Label>
    <br />
<asp:GridView ID="gvFornecedor" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="Id" onrowdeleting="gvFornecedor_RowDeleting" 
    onrowediting="gvFornecedor_RowEditing">
    <Columns>
        <asp:BoundField DataField="id" HeaderText="Código" />
        <asp:BoundField DataField="Nome" HeaderText="Nome" />
        <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="Localizacao" HeaderText="Localização" />
        <asp:BoundField DataField="Ranking" HeaderText="Ranking" />
        <asp:CommandField HeaderText="Remover" ShowDeleteButton="True" 
            DeleteText="Remover" />
        <asp:CommandField HeaderText="Editar" ShowEditButton="True" EditText="Editar" />
    </Columns>
</asp:GridView>
<br />
<asp:Button ID="btnAdicionar" runat="server" onclick="btnAdicionar_Click" 
    Text="Adicionar" style="margin-bottom: 0px" />
<br />
</asp:Content>
