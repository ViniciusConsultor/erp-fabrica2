<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TarefaManutencao.aspx.cs" Inherits="ERP.Manutenção.TarefaManutencao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Button ID="btnAdicionar" runat="server" Text="Criar Tarefa" 
        Width="150px" onclick="btnAdicionar_Click" />
    <br />
    <br />
    <asp:GridView ID="gvTarefas" runat="server" style="margin-bottom: 2px" 
        AutoGenerateColumns="False" DataKeyNames="Id" 
        onrowdeleting="gvTarefas_RowDeleting" 
    onrowediting="gvTarefas_RowEditing">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Codigo" />
            <asp:BoundField DataField="Descricao" HeaderText="Descricao">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Local" HeaderText="Local">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Equipamento" HeaderText="Equipamento">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Estado" HeaderText="Estado">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Inicio_Manutencao" HeaderText="Data de Início">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Fim_Manutencao" HeaderText="Data Final">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:CommandField ShowDeleteButton="True" DeleteText="Remover">
            <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
            <asp:CommandField EditText="Editar" ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <br />
</asp:Content>
