<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GerenciaLotesQuantidades.aspx.cs" Inherits="ERP.Logistica.GerenciaLotesQuantidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label6" runat="server" Font-Size="Large" ForeColor="Black" 
        Text="Lote"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Medicamento"></asp:Label>
    <br />
    <asp:TextBox ID="tbMedicamento" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Quantidade"></asp:Label>
    <br />
    <asp:TextBox ID="tbQuantidade" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Validade"></asp:Label>
    <br />
    <asp:TextBox ID="tbValidade" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Localização"></asp:Label>
    <br />
    <asp:TextBox ID="tbLocalizacao" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Adição ou Remoção"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="tbAdicao" ErrorMessage="* Campo Obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="tbAdicao" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnOk" runat="server" onclick="btnOk_Click" Text="Salvar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
        CausesValidation="False" onclick="btnCancelar_Click" />
    <br />
    <br />
    <asp:HiddenField ID="hfIdMed" runat="server" Value="Novo" />
    <br />
    <asp:HiddenField ID="hfIdEst" runat="server" Value="Novo" />
    <br />
    <br />
</asp:Content>
