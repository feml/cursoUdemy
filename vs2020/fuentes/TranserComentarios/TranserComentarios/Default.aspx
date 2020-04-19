<%@ Page  Title="" Language="C#" MasterPageFile="~/mpPrincipal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TranserComentarios.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoMenuContextual" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <div style="text-align: center">
        <table cellpadding="4" cellspacing="5" class="style1">
            <tr>
                <td class="style2"></td>
            </tr>
            <tr>
                <td class="style6">
                    <asp:Label ID="lblCadena" runat="server"></asp:Label>
                    <br />
                    <span class="style5">Este espacio ha sido creado para poder canalizar efectivamente
                        y de manera confidencial sus sugerencias y comentarios en general, buscando fortalecer
                        la gestión de nuestra organización. Gracias por participar.</span><br class="style5" />
                    <br class="style5" />
                    <span class="style5">Si usted lo prefiere, puede hacer sus comentarios o sugerencias
                        de manera personal, con el funcionario que considere apropiado.</span><br class="style5" />
                    <br class="style5" />
                    <span class="style5">Reiteramos nuestro interes en garantizar la CONFIDENCIALIDAD de
                        la información que usted quiera suministrar.</span>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                    <br />
                    <table cellpadding="4" cellspacing="5" class="style3" width="30%">
                        <tr>
                            <td colspan="2" style="background-color: #5D7B9D; color: White; font-weight: bold">Tipo Mensaje
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">

                                <asp:DropDownList ID="ddTipoMensaje" runat="server" Width="100%"
                                    DataTextField="descripcion" DataValueField="id"
                                    AppendDataBoundItems="True">
                                    <asp:ListItem Value="-1">Seleccione....</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator1" runat="server"
                                    ControlToValidate="ddTipoMensaje" Display="Dynamic"
                                    ErrorMessage="Debe seleccionar un tipo de mensaje" Operator="NotEqual"
                                    Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="background-color: #5D7B9D; color: White; font-weight: bold">Datos Remitente
                            </td>
                        </tr>
                        <tr>
                            <td width="30%">Nombre:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombre" runat="server" Width="85%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nombre Requerido"
                                    Display="Dynamic" ControlToValidate="txtNombre">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Apellido:
                            </td>
                            <td>
                                <asp:TextBox ID="txtApellido" runat="server" Width="85%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Apellido Requerido"
                                    Display="Dynamic" ControlToValidate="txtApellido">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Cédula:
                            </td>
                            <td>
                                <asp:TextBox ID="txtCedula" runat="server" Width="85%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Cédula Requerida"
                                    Display="Dynamic" ControlToValidate="txtCedula">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Email:
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" Width="85%"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email Inválido"
                                    ControlToValidate="txtEmail" Display="Dynamic"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Ciudad:</td>
                            <td>
                                <asp:TextBox ID="txtCiudad" runat="server" Width="85%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Tipo Persona:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddTipoPersona" runat="server" Width="100%"
                                    DataTextField="descripcion" DataValueField="id"
                                    AppendDataBoundItems="True">
                                    <asp:ListItem Value="-1">Seleccione...</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator2" runat="server"
                                    ControlToValidate="ddTipoPersona" Display="Dynamic"
                                    ErrorMessage="Debe seleccionar tipo de persona" Operator="NotEqual"
                                    Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="background-color: #5D7B9D; color: White; font-weight: bold">Mensaje
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="txtMensaje" runat="server" Height="200px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Mensaje Requerido"
                                    ControlToValidate="txtMensaje" Display="Dynamic">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style4" colspan="2">PARA GARANTIZAR LA CONFIDENCIALIDAD Y/O ATENCION PERSONALIZADA DE SU INFORMACION,
                                ELIJA EL CARGO AL QUE QUIERE ENVIAR EL MENSAJE
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvDestinatarios" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" Width="100%"
                                    AutoGenerateColumns="False" DataKeyNames="id"
                                    Style="font-size: small">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Seleccionar" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30%">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEnviar" runat="server" />
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="descripcion" HeaderText="Funcionario" SortExpression="descripcion" />
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
                            </td>
                        </tr>
                        <tr>                            
                            <td colspan="2" style="text-align: center">
                                <asp:CheckBox ID="cbxValidar" runat="server" OnCheckedChanged="cbxValidar_CheckedChanged" AutoPostBack="True"/>
                                <asp:Label runat="server">No soy un robot&nbsp;&nbsp;&nbsp;</asp:Label>                           
                                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" Enabled="False" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
</asp:Content>