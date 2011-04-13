<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Disponibilidades.aspx.cs" Inherits="ERP.Logistica.Disponibilidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
            Text="Lista de Equipamentos Disponíveis"></asp:Label>
        <br />
        <asp:GridView ID="gvDisp" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Id" onrowdeleting="gvDisp_RowDeleting" 
            onrowediting="gvDisp_RowEditing" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Codigo" />
                <asp:BoundField DataField="Equipamento" HeaderText="Equipamento" />
                <asp:BoundField DataField="Espaco" HeaderText="Nome do Espaço" />
                <asp:BoundField DataField="Andar" HeaderText="Andar" />
                <asp:BoundField DataField="Numero" HeaderText="Numero" />
                <asp:CommandField DeleteText="Remover" ShowDeleteButton="True" />
                <asp:CommandField EditText="Editar" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnAdicionar" runat="server" onclick="btnAdicionar_Click" 
            Text="Cadastrar Equipamento Disponível" Width="217px" />
        <br />
</asp:Content>
