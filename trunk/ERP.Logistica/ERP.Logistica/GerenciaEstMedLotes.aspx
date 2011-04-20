<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GerenciaEstMedLotes.aspx.cs" Inherits="ERP.Logistica.GerenciaEstMedLotes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<br />
    <asp:Label ID="Label1" runat="server" Text="Medicamento"></asp:Label>
    <br />
    <asp:TextBox ID="tbMedicamento" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Medida"></asp:Label>
    <br />
    <asp:TextBox ID="tbMedida" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Descrição"></asp:Label>
    <br />
    <asp:TextBox ID="tbDescricao" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:GridView ID="gvEstoque" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id" onrowediting="gvEstoque_RowEditing">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Código" />
            <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" />
            <asp:BoundField DataField="Validade" HeaderText="Validade" 
                DataFormatString="&quot;{0:dd/MM/yyyy}&quot;" />
            <asp:BoundField DataField="Localizacao" HeaderText="Localização" />
            <asp:CommandField EditText="Adicionar/Remover" HeaderText="Adicionar/Remover" 
                ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" 
        onclick="btnCancelar_Click" Text="Cancelar" />
    <br />
    <br />
    <br />
    <asp:HiddenField ID="hfId" runat="server" Value="Novo" />
    <br />
</asp:Content>
