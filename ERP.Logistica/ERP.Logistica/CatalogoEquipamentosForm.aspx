<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CatalogoEquipamentosForm.aspx.cs" Inherits="ERP.Logistica.CatalogoEquipamentosForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
    Text="Catálogos Equipamentos"></asp:Label>
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="Fornecedor"></asp:Label>
<br />
<asp:DropDownList ID="ddlFornecedor" runat="server">
</asp:DropDownList>
<br />
<br />
<asp:Label ID="Label3" runat="server" Text="Equipamento"></asp:Label>
<br />
<asp:DropDownList ID="ddlEquipamento" runat="server">
</asp:DropDownList>
<br />
<br />
<asp:Label ID="Label4" runat="server" Text="Preço Unitário"></asp:Label>
<br />
<asp:TextBox ID="tbPreco" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label5" runat="server" Text="Vigencia Inicio"></asp:Label>
<br />
<asp:TextBox ID="tbVigencia" runat="server"></asp:TextBox>
<br />
<br />
<asp:Button ID="btnOk" runat="server" onclick="btnOk_Click" Text="Salvar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
    Text="Cancelar" />
<br />
    <asp:HiddenField ID="hfId" runat="server" Value="Novo" />
    <br />
<br />
</asp:Content>
