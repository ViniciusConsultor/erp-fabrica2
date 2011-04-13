<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TarefaManutencaoForm.aspx.cs" Inherits="ERP.Manutenção.TarefaManutencaoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Black" 
        Text="Tarefas de Manutenção"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lbDescricao" runat="server" Text="Descrição"></asp:Label>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="tbDescricao" ErrorMessage="* Descrição é Obrigatória" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="tbDescricao" runat="server" Font-Size="Small" Height="100px" 
        Width="300px" MaxLength="200" ViewStateMode="Enabled" Rows="10" 
        TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblLocal" runat="server" Text="Local "></asp:Label>
    <br />
    <asp:DropDownList ID="ddLocal" runat="server" Height="22px" Width="120px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lbEquipamento" runat="server" Text="Equipamento"></asp:Label>
    <br />
    <asp:DropDownList ID="ddEquipamento" runat="server" Height="22px" Width="120px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lbEstado" runat="server" Text="Estado"></asp:Label>
    &nbsp;<br />
    <asp:DropDownList ID="ddEstado" runat="server" Height="22px" Width="120px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lbPeriodoManutencao" runat="server" Text="Período de Manutenção"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lbDIni" runat="server" Text="Data Inicial: "></asp:Label>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="tbDataIni" 
        ErrorMessage="* Data deve estar na forma dd/mm/aaaa e ser uma data válida" 
        ForeColor="Red" 
        ValidationExpression="(([0-1][0-9]|2[0-9])/02/(2000|2004|2008|2012|2016|2020|2024|2028|2032|2036))|(([0-1][0-9]|2[0-8])/02/[0-9][0-9][0-9][0-9])|(([0-2][0-9]|30)/(04|06|09|11)/[0-9][0-9][0-9][0-9])|(([0-2][0-9]|3[0-1])/(01|03|05|07|08|10|12)/[0-9][0-9][0-9][0-9])"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:TextBox ID="tbDataIni" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbHIni" runat="server" Text="Hora Inicial: "></asp:Label>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ControlToValidate="tbHoraIni" 
        ErrorMessage="* Hora deve estar na forma hh:mm e ser um horário válido" 
        ForeColor="Red" ValidationExpression="(2[0-3]|[0-1][0-9]):[0-5][0-9]"></asp:RegularExpressionValidator>
    <br />
    <asp:TextBox ID="tbHoraIni" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbDFim" runat="server" Text="Data Final: "></asp:Label>
&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
        runat="server" ControlToValidate="tbDataFim" 
        ErrorMessage="* Data deve estar na forma dd/mm/aaaa e ser uma data válida" 
        ForeColor="Red" 
        ValidationExpression="(([0-1][0-9]|2[0-9])/02/(2000|2004|2008|2012|2016|2020|2024|2028|2032|2036))|(([0-1][0-9]|2[0-8])/02/[0-9][0-9][0-9][0-9])|(([0-2][0-9]|30)/(04|06|09|11)/[0-9][0-9][0-9][0-9])|(([0-2][0-9]|3[0-1])/(01|03|05|07|08|10|12)/[0-9][0-9][0-9][0-9])"></asp:RegularExpressionValidator>
    <br />
    <asp:TextBox ID="tbDataFim" runat="server"></asp:TextBox>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="tbDataIni" ControlToValidate="tbDataFim" 
        ErrorMessage="* Data Final deve ser após a Inicial" ForeColor="Red" 
        Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
    <br />
    <br />
    <asp:Label ID="lbHFim" runat="server" Text="Hora Inicial: "></asp:Label>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
        ControlToValidate="tbHoraFim" 
        ErrorMessage="* Hora deve estar na forma hh:mm e ser um horário válido" 
        ForeColor="Red" ValidationExpression="(2[0-3]|[0-1][0-9]):[0-5][0-9]"></asp:RegularExpressionValidator>
    <br />
    <asp:TextBox ID="tbHoraFim" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnOK" runat="server" onclick="btnOK_Click" Text="Salvar" 
        Width="100px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" Width="100px" 
    onclick="btnCancel_Click" CausesValidation="False" />
    <br />
    <asp:HiddenField ID="hfId" runat="server" Value="Novo" />
</asp:Content>
