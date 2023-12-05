<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Prueba_de_appWEB_ASP.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .row {
            margin-bottom: 8px;
        }

        .checkbox-options div {
            margin-bottom: 10px;
        }

        .checkbox-options input[type="checkbox"] {
            margin-right: 8px;
        }

        td, th {
            border: 2px solid grey;
            padding: 10px;
        }
    </style>

    <div class="row">
        <div class="col-lg-12">
            <h3>Agregar un nuevo Usuario</h3>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                ErrorMessage="Ingrese un username" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red">Usuario ya regristrado.</asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" placeholder="Nombre del Usuario" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" ControlToValidate="txtNombreUsuario"
                ErrorMessage="Ingrese el nombre del Usuario" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtApellidoUsuario" runat="server" CssClass="form-control" placeholder="Apellido del Usuario" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvApellidoUsuario" runat="server" ControlToValidate="txtApellidoUsuario"
                ErrorMessage="Ingrese el apellido del Usuario" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" CssClass="form-control" placeholder="Contraseña" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                ErrorMessage="Ingrese una contraseña" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox TextMode="Password" ID="txtConfirmarPassword" runat="server" CssClass="form-control" placeholder="Confirmar Contraseña" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvConfirmarPassword" runat="server" ControlToValidate="txtConfirmarPassword"
                ErrorMessage="Confirme la contraseña" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvPasswordMatch" runat="server" ControlToValidate="txtConfirmarPassword" ControlToCompare="txtPassword"
                ErrorMessage="Las contraseñas no coinciden" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:CompareValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5 checkbox-options">
            <h4>Permisos:</h4>
            <div>
                <asp:CheckBox ID="chkVerClientes" runat="server" Text="Ver Clientes" />
            </div>
            <div>
                <asp:CheckBox ID="chkVerVentas" runat="server" Text="Ver Ventas" />
            </div>
            <div>
                <asp:CheckBox ID="chkVerVehiculos" runat="server" Text="Ver Vehículos" />
            </div>
            <div>
                <asp:CheckBox ID="chkVerAlquileres" runat="server" Text="Ver Alquileres" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="Guardar" />
        </div>
    </div>
    <hr />

    <div class="row">
        <div class="col-lg-8">
            <asp:GridView ID="gvUsuarios" runat="server" Width="80%" BorderWidth="2px" CellSpacing="5"
                OnRowCancelingEdit="gvUsuarios_RowCancelingEdit"
                OnRowDeleting="gvUsuarios_RowDeleting"
                OnRowEditing="gvUsuarios_RowEditing"
                OnRowUpdating="gvUsuarios_RowUpdating"
                AutoGenerateColumns="false"
                OnRowDataBound="gvUsuarios_RowDataBound"
                DataKeyNames="Username">
                <Columns>
                    <asp:TemplateField HeaderText="Número ID Usuario" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblidUsuario" runat="server" Text='<%# Bind("idUsuario") %>'></asp:Label>
                            <!-- aca se hace referncia al atributo del objeto, va con comillas simples -->
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Username" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl1" runat="server" Text='<%# Bind("username") %>'></asp:Label>
                            <!-- aca se hace referncia al atributo del objeto, va con comillas simples ARCHIVO NUESTRO CORRECTO-->
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lbl2" runat="server" Text='<%# Bind("username") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nombre" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl3" runat="server" Text='<%# Bind("nombreUsuario") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombreGrid" runat="server" Text='<%# Bind("nombreUsuario") %>'></asp:TextBox>
                            <!-- El EDITITEMTEMPLATE se cambia de label a textbox para que permita editar-->
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Apellido" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl4" runat="server" Text='<%# Bind("apellidoUsuario") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtApellidoGrid" runat="server" Text='<%# Bind("apellidoUsuario") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Ver Clientes" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="lbl33" runat="server" Checked='<%# Bind("verClientes") %>'></asp:CheckBox>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkVerClientes" runat="server" Checked='<%# Bind("verClientes") %>'></asp:CheckBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Ver Ventas" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="lbl35" runat="server" Checked='<%# Bind("verVentas") %>'></asp:CheckBox>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkVerVentas" runat="server" Checked='<%# Bind("verVentas") %>'></asp:CheckBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Ver Vehículos" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="lbl36" runat="server" Checked='<%# Bind("verVehiculos") %>'></asp:CheckBox>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkVerVehiculos" runat="server" Checked='<%# Bind("verVehiculos") %>'></asp:CheckBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Ver Alquileres" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="lbl37" runat="server" Checked='<%# Bind("verAlquileres") %>'></asp:CheckBox>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkVerAlquileres" runat="server" Checked='<%# Bind("verAlquileres") %>'></asp:CheckBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Editar" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                            <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Eliminar" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />--%>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
