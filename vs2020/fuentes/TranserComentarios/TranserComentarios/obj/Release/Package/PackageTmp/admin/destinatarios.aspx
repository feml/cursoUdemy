<%@ Page StylesheetTheme="tysTemas" Title="" Language="C#" MasterPageFile="~/admin/mpAdmin.master" AutoEventWireup="true" CodeBehind="destinatarios.aspx.cs" Inherits="TranserComentarios.admin.destinatarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
        <asp:GridView ID="gdvDestinatarios" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
            AutoGenerateColumns="False" DataKeyNames="id" >
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


            <Columns>
                <asp:CommandField CancelText="Cancelar"
                    DeleteText="Eliminar"
                    EditText="Editar"
                    InsertText="Insertar"
                    ShowEditButton="true"
                    UpdateText="Actualizar"
                    ShowDeleteButton="true"></asp:CommandField>

                <asp:TemplateField HeaderText="Tipo Funcionario">
                    <ItemTemplate>
                        <asp:Label ID="LblTipoFuncionario" runat="server" Text='<%# Bind("descripcion") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>

                        <asp:DropDownList ID="ddl" runat="server"
                            DataSourceID="lndDSCategorias"
                            DataTextField="descripcion"
                            DataValueField="id"
                            SelectedValue='<%# Bind("id") %>'>
                        </asp:DropDownList>

                    </EditItemTemplate>

                </asp:TemplateField>

                <asp:BoundField DataField="descripcion" HeaderText="Nombre" />
                <asp:TemplateField HeaderText="Email">

                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server"
                            Text='<%# Bind("descripcion") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txbEmail" runat="server"
                            Text='<%# Bind("id_Padre") %>'>
                        </asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="txbEmail"
                            ErrorMessage="Correo Inválido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="*">
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Se requiere el correo" Text="*">
                        </asp:RequiredFieldValidator>

                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>

            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />


        </asp:GridView>


    <asp:Label ID="lblMensaje" runat="server"></asp:Label>

</asp:Content>
