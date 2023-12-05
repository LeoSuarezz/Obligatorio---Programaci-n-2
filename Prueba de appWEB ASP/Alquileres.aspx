<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alquileres.aspx.cs" Inherits="Prueba_de_appWEB_ASP.Alquileres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .row {
            margin-bottom: 8px;
        }

        td, th {
            border: 2px solid grey;
            padding: 10px;
        }
    </style>

    <div class="row">
        <div class="col-lg-12">
            <h3>Realizar el alquiler de un vehículo</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-8">
            Clientes:
            <asp:ListBox ID="lstClientes" runat="server" CssClass="form-control"></asp:ListBox>
            <asp:RequiredFieldValidator ID="rfvClientes" runat="server" ControlToValidate="lstClientes"
                ErrorMessage="Selecciona un cliente" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            Vehiculos:
    <asp:DropDownList Width="1000px" ID="cboVehiculos" runat="server" CssClass="form-control" OnSelectedIndexChanged="cboVehiculos_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox TextMode="Number" min="0" ID="txtCantDias" runat="server" OnTextChanged="txtCantDias_TextChanged" AutoPostBack="true" CssClass="form-control" placeholder="Cantidad de días de alquiler" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCantDias" runat="server" ControlToValidate="txtCantDias"
                ErrorMessage="Ingrese la cantidad de días" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>
    <h6>Indique la fecha de inicio del Alquiler</h6>
    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox TextMode="Date" ID="txtFechaInicio" runat="server" CssClass="form-control" placeholder="Fecha del inicio del alquiler" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server" ControlToValidate="txtFechaInicio"
                ErrorMessage="Ingrese la fecha de inicio del alquiler" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:Label ID="lblSimbolo" runat="server" Visible="false" ForeColor="Blue">Precio de alquiler por día: $</asp:Label>
            <asp:Label ID="lblPrecio" runat="server" Visible="false" ForeColor="Blue"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Alquilar" OnClick="btnGuardar_Click" ValidationGroup="Guardar" />
        </div>
    </div>
    <hr />

    <!-- PARTE NUEVA PROBANDO MOSTRAR LISTA DE VEHICULOS VENDIDOS-->

    <div class="row">
        <div class="col-lg-7">
            <h3>Lista de vehículos alquilados</h3>
            <asp:GridView ID="gvAlquiler" runat="server" Width="80%" BorderWidth="2px" CellSpacing="15"
                AutoGenerateColumns="false"
                OnRowCancelingEdit="gvAlquiler_RowCancelingEdit"
                OnRowDeleting="gvAlquiler_RowDeleting"
                OnRowEditing="gvAlquiler_RowEditing"
                OnRowUpdating="gvAlquiler_RowUpdating"
                DataKeyNames="numAlquiler"
                <%--OnRowDataBound="gvAlquiler_RowDataBound--%>>

                <Columns>
                    <asp:TemplateField HeaderText="Numero de Alquiler" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl10" runat="server" Text='<%# Bind("numAlquiler") %>'></asp:Label>
                            <!-- aca se hace referncia al atributo del objeto, va con comillas simples -->
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Matricula" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl11" runat="server" Text='<%# Bind("matriculaVehiculo") %>'></asp:Label>
                            <!-- aca se hace referncia al atributo del objeto, va con comillas simples -->
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMatriculaGrid" runat="server" Text='<%# Bind("matriculaVehiculo") %>'></asp:TextBox>
                            <!-- El EDITITEMTEMPLATE se cambia de label a textbox para que permita editar-->
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Marca" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblMarca" runat="server" Text='<%# ObtenerMarcaVehiculo(Eval("matriculaVehiculo")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Modelo" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblModelo" runat="server" Text='<%# ObtenerModeloVehiculo(Eval("matriculaVehiculo")) %>'></asp:Label>
                            <!-- aca se hace referncia al atributo del objeto, va con comillas simples -->
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Color" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblColor" runat="server" Text='<%# ObtenerColorVehiculo(Eval("matriculaVehiculo")) %>'></asp:Label>
                            <!-- aca se hace referncia al atributo del objeto, va con comillas simples -->
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Año" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblAño" runat="server" Text='<%# ObtenerAnioVehiculo(Eval("matriculaVehiculo")) %>'></asp:Label>
                            <!-- aca se hace referncia al atributo del objeto, va con comillas simples -->
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio Alquiler" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPrecioAlquiler" runat="server" Text='<%# ObtenerPrecioAlquilerVehiculo(Eval("matriculaVehiculo")) %>'></asp:Label>
                            <!-- aca se hace referncia al atributo del objeto, va con comillas simples -->
                        </ItemTemplate>
                        <ItemStyle Width="200px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Documento Cliente" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDocumentoCliente" runat="server" Text='<%# ObtenerDocumentoCliente(Eval("documentoCliente")) %>'></asp:Label>
                            <!-- aca se hace referncia al atributo del objeto, va con comillas simples -->
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nombre y Apellido Cliente" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNombreApellido" runat="server" Text='<%# ObtenerNombreApellidoCliente(Eval("documentoCLiente")) %>'></asp:Label>
                            <!-- aca se hace referncia al atributo del objeto, va con comillas simples -->
                        </ItemTemplate>
                        <ItemStyle Width="500px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Devuelto">
                        <ItemTemplate>
                            <asp:CheckBox ID="lbl9" runat="server" Checked='<%# Bind("autoDevuelto") %>'></asp:CheckBox>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkDevueltoGrid" runat="server" Checked='<%# Bind("autoDevuelto") %>'></asp:CheckBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label ID="lbl34" runat="server" Text='<%# Bind("estado") %>' ForeColor="Blue" Font-Bold="true"></asp:Label>
                        </ItemTemplate>
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

                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
