<%@ Page StylesheetTheme="tysTemas" Title="" Language="C#" MasterPageFile="~/admin/mpAdmin.master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TranserComentarios.admin.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
<h2>Formulario Login</h2>
    <div id="CapaPrincipal">
        <div id="BloqueUsuario">
            <asp:Label ID="lblusuario" runat="server" Text="Usuario :"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txbUsuario" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>
        <div id="BloquePassword">
            <asp:Label ID="lblPassword" runat="server" Text="Constraseña :"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txbPassword" runat="server"></asp:TextBox>
        </div>
        <div id="bloqueBoton">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnIngreso" runat="server" Text="Ingresar" OnClick="btnIngreso_Click" />
        </div>
    </div>
</asp:Content>
