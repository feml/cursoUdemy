<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/mpAdmin.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TranserComentarios.Admin.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <div>
<%--        <asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4"
            BorderStyle="Solid" BorderWidth="1px" FailureText="Usuario y/o contraseña inválida, intente de nuevo."
            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" LoginButtonText="Entrar"
            OnAuthenticate="Login1_Authenticate" PasswordLabelText="Contraseña" PasswordRequiredErrorMessage="Se requiere la constraseña"
            RememberMeText="Recordarme la próxima vez." TitleText="Control de Acceso"
            UserNameLabelText="Usuario:" UserNameRequiredErrorMessage="Se requiere el usuario"
            Width="100%">
            <TextBoxStyle Font-Size="0.8em" />
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>--%>
        <asp:Login ID="Login1" runat="server" onauthenticate="Login1_Authenticate" 
            BackColor="#F7F6F3" 
            BorderColor="#E6E2D8" 
            BorderPadding="4" 
            BorderStyle="Solid" 
            BorderWidth="1px" 
            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
    </div>
</asp:Content>
