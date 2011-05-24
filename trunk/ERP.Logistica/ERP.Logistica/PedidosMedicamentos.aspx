<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PedidosMedicamentos.aspx.cs" Inherits="ERP.Logistica.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
        Text="Lista de Pedidos de Medicamentos"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lbVerba" runat="server" Text="Verba Disponível:"></asp:Label>
&nbsp;<asp:Label ID="lbValorVerba" runat="server" Text="0"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnMes" runat="server" Text="Exibir Fluxo do Mês" 
        Width="150px" onclick="btnMes_Click" />
    <br />
    <br />
Legenda Efetuado:<br />
0 = Estornado
<asp:Label ID="lbAviso" runat="server" 
    Text="(Apenas Estornos já Reportados ao Financeiro podem ser Removidos)"></asp:Label>
<br />
1 = Aguardando<br />
2 = Efetuado (Recebido)<br />
    <br />
    <asp:GridView ID="gvPedidos" runat="server" style="margin-bottom: 2px" 
        AutoGenerateColumns="False" DataKeyNames="Id" 
        onrowdeleting="gvPedidos_RowDeleting" 
    onrowediting="gvPedidos_RowEditing" ShowHeaderWhenEmpty="True">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Codigo" />
            <asp:BoundField DataField="Produto" HeaderText="Medicamento">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Fornecedor" HeaderText="Fornecedor">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Quantidade" HeaderText="Quant.">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Preco" HeaderText="Preço Un.">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Requisicao" HeaderText="Data de Requisição">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Efetuado" HeaderText="Efetuado">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:CommandField ShowDeleteButton="True" DeleteText="Remover" 
                HeaderText="Remover">
            <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
            <asp:CommandField EditText="Editar" ShowEditButton="True" HeaderText="Editar" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnAdicionar" runat="server" onclick="btnAdicionar_Click" 
        Text="Realizar Pedido" Width="150px" />
    <br />
    <br />
</asp:Content>
