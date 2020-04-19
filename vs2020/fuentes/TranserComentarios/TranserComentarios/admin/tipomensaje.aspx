﻿<%@ Page StylesheetTheme="tysTemas" Title="" Language="C#" MasterPageFile="~/admin/mpAdmin.master" AutoEventWireup="true" CodeBehind="tipomensaje.aspx.cs" Inherits="TranserComentarios.admin.tipomensaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
     <div>
        <div id="cptitulotipomensajes">
            <h2>FORMULARIO TIPO MENSAJE</h2>
        </div>
        <div id="cpgrvtipomensajes">
            <div id="cpcentargrvtipomensajes">
                <asp:GridView ID="gvPerson" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    OnPageIndexChanging="gvPerson_PageIndexChanging"
                    OnRowCancelingEdit="gvPerson_RowCancelingEdit"
                    OnRowDataBound="gvPerson_RowDataBound" OnRowDeleting="gvPerson_RowDeleting"
                    OnRowEditing="gvPerson_RowEditing" OnRowUpdating="gvPerson_RowUpdating"
                    OnSorting="gvPerson_Sorting"
                    ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True"
                            SortExpression="descripcion" />
                        <asp:TemplateField HeaderText="Tipo Mensaje" SortExpression="descripcion">
                            <EditItemTemplate>
                                <asp:TextBox ID="txbDescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDescripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>

            </div>
        </div>
        <div id="idafan">
            <asp:Label ID="Label1" runat="server" Text=""> _</asp:Label>
        </div>
        <div id="bqlbtnaddtipomensajes">
            <asp:LinkButton ID="lbtnAdd" runat="server" OnClick="lbtnAdd_Click">Agregar</asp:LinkButton>
        </div>
        <asp:Panel ID="pnlAdd" runat="server" Visible="False">
            <div id="bqpnladdTipomensajes">
                <div id="bqpnladdTipomensajescentrar">
            Tipo Persona:
                    <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:LinkButton ID="lbtnSubmit" runat="server" OnClick="lbtnSubmit_Click">Grabar</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click">Cancelar</asp:LinkButton>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
