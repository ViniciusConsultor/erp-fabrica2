<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicamentosForm.aspx.cs" Inherits="ERP.Logistica.MedicamentoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
    Text="Medicamento"></asp:Label>
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="Nome"></asp:Label>
<asp:RequiredFieldValidator ID="rfvNome" runat="server" 
    ControlToValidate="tbNome" ErrorMessage="* Campo Obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="tbNome" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label3" runat="server" Text="Descrição"></asp:Label>
<asp:RequiredFieldValidator ID="rfvDescricao" runat="server" 
    ControlToValidate="tbDescricao" ErrorMessage="* Campo Obrigatório" 
    ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="tbDescricao" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label4" runat="server" Text="Medida"></asp:Label>
<br />
<asp:TextBox ID="tbMedida" runat="server"></asp:TextBox>
<br />
<br />
Quantidade<asp:CompareValidator ID="CompareValidator1" runat="server" 
    ControlToValidate="tbQuant" 
    ErrorMessage="* Deve Conter um Valor Numérico Maior ou Igual a 0" 
    ForeColor="Red" Operator="GreaterThanEqual" Type="Integer" ValueToCompare="0"></asp:CompareValidator>
    <asp:RequiredFieldValidator ID="rfvQuant" runat="server" 
        ControlToValidate="tbQuant" ErrorMessage="* Campo Obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<asp:TextBox ID="tbQuant" runat="server"></asp:TextBox>
<br />
<br />
<br />
<br />
<asp:Button ID="btnOk" runat="server" onclick="btnOk_Click" Text="Salvar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
    Text="Cancelar" CausesValidation="False" />
<br />
<br />
<asp:HiddenField ID="hfId" runat="server" Value="Novo" />
<br />
<br />
</asp:Content>
