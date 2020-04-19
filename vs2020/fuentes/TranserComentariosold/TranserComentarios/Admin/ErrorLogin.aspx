<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/mpAdmin.master" AutoEventWireup="true" CodeBehind="ErrorLogin.aspx.cs" Inherits="TranserComentarios.Admin.ErrorLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <div>
        <h1>El Usuario y contraseña ingresados no son validos.</h1>
        <h2>Por favor Intentelo Nuevamente.</h2>
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
    </div>
</asp:Content>
