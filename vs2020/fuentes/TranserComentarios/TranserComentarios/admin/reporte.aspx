<%@ Page StylesheetTheme="tysTemas" Title="" Language="C#" MasterPageFile="~/admin/mpAdmin.master" AutoEventWireup="true" CodeBehind="reporte.aspx.cs" Inherits="TranserComentarios.admin.reporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <div id="capaPrincipal">
        <div id="tituloReporte">
            <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Reporte de los mensajes enviados</h1>
        </div>
        <div id="bqformularioReporte">
            <div id="bqcontenidoformularioReporte">
                <asp:GridView ID="gdvMensajes" runat="server"
                    AllowPaging="True"
                    PageSize="8"
                    OnPageIndexChanging="gdvMensajes_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="960px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
