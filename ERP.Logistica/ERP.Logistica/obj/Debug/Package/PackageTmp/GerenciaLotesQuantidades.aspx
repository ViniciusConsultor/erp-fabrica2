<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GerenciaLotesQuantidades.aspx.cs" Inherits="ERP.Logistica.GerenciaLotesQuantidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label6" runat="server" Font-Size="Large" ForeColor="Black" 
        Text="Lote"></asp:Label>
<asp:CustomValidator ID="vSucesso" runat="server" 
    ErrorMessage="* Mudança no estoque realizado com sucesso" 
    ForeColor="#009900"></asp:CustomValidator>
    <br />
    <asp:CustomValidator ID="vRetirada" runat="server" 
    ErrorMessage="* Não foi possivel retirar a quantidade selecionada." 
    ForeColor="Red"></asp:CustomValidator>
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
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToValidate="tbAdicao" 
        ErrorMessage="* Deve Conter um Valor Numérico" 
        ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
    <br />
    <asp:TextBox ID="tbAdicao" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="tbAdicao" ErrorMessage="* Campo Obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
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
