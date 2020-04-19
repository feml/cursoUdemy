<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/mpAdmin.master" AutoEventWireup="true" CodeBehind="Destinatarios.aspx.cs" Inherits="TranserComentarios.Admin.Destinatarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <div id="capaPrincipal">
    <asp:GridView ID="gvPerson" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
        AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2"
        Width="100%">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:CommandField CancelText="Cancelar" DeleteText="Eliminar" EditText="Editar" InsertText="Insertar"
                ShowEditButton="True" UpdateText="Actualizar" ShowDeleteButton="True">
                <ItemStyle Width="15%" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="Tipo Funcionario">
                <ItemStyle Width="25%" />
                <ItemTemplate>
                    <asp:Label ID="lblTipoFuncionario" runat="server" Text='<%# Bind("Categoria.descripcion") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="descripcion" DataValueField="id" SelectedValue='<%# Bind("id_Tipo_Funcionario") %>'
                        Width="98%">
                    </asp:DropDownList>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:TranserComentariosConnectionString %>"
                        SelectCommand="SELECT * FROM [Categorias] WHERE ([id_Padre] = @id_Padre)">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="3" Name="id_Padre"
                                QueryStringField="id_Padre" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>

     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TranserComentariosConnectionString %>" DeleteCommand="DELETE FROM [Categorias] WHERE [id] = @id" InsertCommand="INSERT INTO [Categorias] ([descripcion], [id_Padre]) VALUES (@descripcion, @id_Padre)" SelectCommand="SELECT * FROM [Categorias] WHERE ([id_Padre] = @id_Padre)" UpdateCommand="UPDATE [Categorias] SET [descripcion] = @descripcion, [id_Padre] = @id_Padre WHERE [id] = @id">
         <DeleteParameters>
             <asp:Parameter Name="id" Type="Int32" />
         </DeleteParameters>
         <InsertParameters>
             <asp:Parameter Name="descripcion" Type="String" />
             <asp:Parameter Name="id_Padre" Type="Int32" />
         </InsertParameters>
         <SelectParameters>
             <asp:QueryStringParameter DefaultValue="3" Name="id_Padre" QueryStringField="@id_padre" Type="Int32" />
         </SelectParameters>
         <UpdateParameters>
             <asp:Parameter Name="descripcion" Type="String" />
             <asp:Parameter Name="id_Padre" Type="Int32" />
             <asp:Parameter Name="id" Type="Int32" />
         </UpdateParameters>
    </asp:SqlDataSource>
                   


                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:TemplateField HeaderText="Email">
                <ItemStyle Width="25%" />
                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("email") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <%--<asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("email") %>' />--%>
                    <asp:TextBox ID="tbCorreo" runat="server" Text='<%# Bind("email") %>' />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Correo Inválido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="*" />
                    <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Se requiere el correo" Text="*" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>


    <%--    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="TranserComentarios.Layers.DAO.TranserComentariosDataContext"
        EnableInsert="True" EnableUpdate="True" TableName="Categoria_Correos" 
        EnableDelete="True">--%>


    <asp:LinkButton ID="lnkAgregar" runat="server" OnClick="lnkAgregar_Click">Agregar Nuevo</asp:LinkButton>
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <br />
    <asp:DetailsView ID="dvDestinatarios" runat="server" AutoGenerateRows="False" CellPadding="4" DataSourceID="SqlDataSource1"
        DefaultMode="Insert" ForeColor="#333333" Height="50px" Visible="False"
        Width="100%" OnItemInserting="dvFuncionarios_ItemInserting" OnItemInserted="dvPersonas_ItemInserted"
        DataKeyNames="id" GridLines="None">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <asp:TemplateField HeaderText="Tipo Funcionario" SortExpression="id_Tipo_Funcionario">
                <HeaderStyle Width="30%" />
                <InsertItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="descripcion" DataValueField="id" SelectedValue='<%# Bind("id_Tipo_Funcionario") %>'
                        Width="98%">
                    </asp:DropDownList>

                    <%--                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="TranserComentarios.Layers.DAO.TranserComentariosDataContext"
                        TableName="Categorias" Where="id_Padre == @id_Padre">
                        <WhereParameters>
                            <asp:Parameter DefaultValue="3" Name="id_Padre" Type="Int32" />
                        </WhereParameters>
                    </asp:LinqDataSource>--%>



                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:TranserComentariosConnectionString %>"
                        SelectCommand="SELECT * FROM [Categorias] WHERE ([id_Padre] = @id_Padre)">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="3" Name="id_Padre"
                                QueryStringField="id_Padre" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>



                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre" SortExpression="nombre">
                <HeaderStyle Width="30%" />
                <InsertItemTemplate>
                    <asp:TextBox ID="tbNombre" runat="server" Text='<%# Bind("nombre") %>' Width="95%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfV1" runat="server" ControlToValidate="tbNombre"
                        ErrorMessage="Se requiere el nombre" Text="*" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email" SortExpression="email">
                <HeaderStyle Width="30%" />
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" CausesValidation="true" runat="server" Text='<%# Bind("email") %>'
                        Width="95%"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="Correo Inválido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfV" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="Se requiere el correo" Text="*" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowInsertButton="True" CancelText="Cancelar" InsertText="Insertar" />
        </Fields>
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
    </asp:DetailsView>
    </div>
</asp:Content>
