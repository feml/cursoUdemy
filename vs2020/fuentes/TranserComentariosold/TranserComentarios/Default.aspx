<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TranserComentarios.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoMenuContextual" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <div id="divPrincipal">
        <div id="mensajespan">
            <div id="mnsjprt1">
                <asp:Label ID="lbltitulomasterpagep1" runat="server" Text="Este espacio ha sido creado para poder canalizar efectivamente
                        y de manera confidencial sus sugerencias y comentarios en general, buscando fortalecer
                        la gestión de nuestra organización. Gracias por participar."
                    Font-Bold="False" Font-Names="Georgia" Font-Size="Large"></asp:Label>
            </div>
            <div id="mnsjprt2">
                <asp:Label ID="Label1" runat="server" Text="Si usted lo prefiere, puede hacer sus comentarios o sugerencias
                        de manera personal, con el funcionario que considere apropiado."
                    Font-Bold="False" Font-Names="Georgia" Font-Size="Larger"></asp:Label>
            </div>
            <div id="mnsjprt3">
                <asp:Label ID="Label2" runat="server" Text="Reiteramos nuestro interes en garantizar la CONFIDENCIALIDAD de
                        la información que usted quiera suministrar."
                    Font-Bold="False" Font-Names="Georgia" Font-Size="Large"></asp:Label>
            </div>
        </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <div id="limitecuerpo">
            <div id="primerBloque">
                <div id="bloqueTipoMensaje">
                    <h2>Tipo Mensaje</h2>
                </div>
                <div id="dropTipoMensaje">
                    <asp:DropDownList ID="ddTipoMensaje" runat="server" Width="100%" DataSourceID="SqlDataSource1"
                        DataTextField="descripcion" DataValueField="id"
                        AppendDataBoundItems="True" Height="26px">
                        <asp:ListItem Value="-1">Seleccione...</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="Data Source=JSOPORTE\SQLEXPRESS;Initial Catalog=TranserComentarios;User ID=sa;Password=Satranser2015"
                        SelectCommand="SELECT * FROM [Categorias] WHERE ([id_Padre] = @id_Padre)">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="2" Name="id_Padre"
                                QueryStringField="id_Padre" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:CompareValidator ID="CompareValidator1" runat="server"
                        ControlToValidate="ddTipoMensaje" Display="Dynamic"
                        ErrorMessage="Debe seleccionar un tipo de mensaje" Operator="NotEqual"
                        Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                </div>
            </div>
            <div id="SegundoBloque">
                <div id="tituloDatosRemitente">
                    <h2>Datos Remitente</h2>
                </div>
                <div id="bloqueNombre">
                    <div id="bqlblNombre">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre :" Font-Bold="True" Font-Size="X-Large" Height="25px"></asp:Label>
                    </div>
                    <div id="bqtxbNombre">
                        <asp:TextBox ID="txtNombre" runat="server" Width="85%" Height="25px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nombre Requerido"
                            Display="Dynamic" ControlToValidate="txtNombre">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div id="bqApellido">
                    <div id="bqlblApellido">
                        <asp:Label ID="lblApellido" runat="server" Text="Apellido :" Font-Bold="True" Font-Size="X-Large" Height="25px"></asp:Label>
                    </div>
                    <div id="bqtxbApellido">
                        <asp:TextBox ID="txtApellido" runat="server" Width="85%" Height="25px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Apellido Requerido"
                            Display="Dynamic" ControlToValidate="txtApellido">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div id="bqCedula">
                    <div id="bqlblCedula">
                        <asp:Label ID="lblCedula" runat="server" Text="Cédula :" Font-Bold="True" Font-Size="X-Large" Height="25px"></asp:Label>
                    </div>
                    <div id="bqtxbCedula">
                        <asp:TextBox ID="txtCedula" runat="server" Width="85%" Height="25px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Cédula Requerida"
                            Display="Dynamic" ControlToValidate="txtCedula">*</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div id="bqEmail">
                    <div id="bqlblEmail">
                        <asp:Label ID="lblEmail" runat="server" Text="Email :" Font-Bold="True" Font-Size="X-Large" Height="25px"></asp:Label>
                    </div>
                    <div id="bqtxbEmail">
                        <asp:TextBox ID="txtEmail" runat="server" Width="85%" Height="25px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email Inválido"
                            ControlToValidate="txtEmail" Display="Dynamic"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </div>
                </div>
                <div id="bqCiudad">
                    <div id="bqlblCiudad">
                        <asp:Label ID="lblCiudad" runat="server" Text="Ciudad :" Font-Bold="True" Font-Size="X-Large" Height="25px"></asp:Label>
                    </div>
                    <div id="bqtxbCiudad">
                        <asp:TextBox ID="txtCiudad" runat="server" Width="85%" Height="25"></asp:TextBox>
                    </div>
                </div>
                <div id="bqTipPer">
                    <div id="bplbltipper">
                        <asp:Label ID="lbltipper" runat="server" Text="Tipo Persona :" Font-Bold="True" Font-Size="X-Large" Height="25px"></asp:Label>
                    </div>
                    <div id="bqdropTippersona">
                        <asp:DropDownList ID="ddTipoPersona" runat="server" Width="100%" DataSourceID="SqlDataSource2"
                            DataTextField="descripcion" DataValueField="id"
                            AppendDataBoundItems="True">
                            <asp:ListItem Value="-1">Seleccione</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                            ConnectionString="Data Source=JSOPORTE\SQLEXPRESS;Initial Catalog=TranserComentarios;User ID=sa;Password=Satranser2015"
                            SelectCommand="SELECT * FROM [Categorias] WHERE ([id_Padre] = @id_Padre)">
                            <SelectParameters>
                                <asp:QueryStringParameter DefaultValue="1" Name="id_Padre"
                                    QueryStringField="id_Padre" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:CompareValidator ID="CompareValidator2" runat="server"
                            ControlToValidate="ddTipoPersona" Display="Dynamic"
                            ErrorMessage="Debe seleccionar tipo de persona" Operator="NotEqual"
                            Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                    </div>
                </div>
            </div>
            <div id="bqmensaje">
                <div id="bqlblmensaje">
                    <h2>Mensaje</h2>
                </div>
                <div id="bqtxbmensaje">
                    <asp:TextBox ID="txtMensaje" runat="server" Height="200px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Mensaje Requerido"
                        ControlToValidate="txtMensaje" Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <spam> GARANTIZAR LA CONFIDENCIALIDAD Y/O ATENCION PERSONALIZADA DE SU INFORMACION,
                                ELIJA EL CARGO AL QUE QUIERE ENVIAR EL MENSAJE</spam>
            <asp:GridView ID="gvDestinatarios" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                AutoGenerateColumns="False" DataKeyNames="id"
                DataSourceID="SqlDataSource3" Style="font-size: small">
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

            <asp:SqlDataSource ID="SqlDataSource3" runat="server"
                ConnectionString="Data Source=JSOPORTE\SQLEXPRESS;Initial Catalog=TranserComentarios;User ID=sa;Password=Satranser2015"
                SelectCommand="SELECT * FROM [Categorias] WHERE ([id_Padre] = @id_Padre)">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="3" Name="id_Padre"
                        QueryStringField="id_Padre" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <div id="bqbtnEnviar">
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClientClick="return ValidarDatos()"
                    OnClick="btnEnviar_Click" Height="30px" />
            </div>
        </div>
    </div>
</asp:Content>
