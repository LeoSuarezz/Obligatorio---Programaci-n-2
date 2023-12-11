<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs" Inherits="Prueba_de_appWEB_ASP.Vehiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .row {
            margin-bottom: 8px;
        }

        td, th {
            border: 2px solid grey;
            padding: 10px;
        }

        div#tipoVehiculo .customRadioButtonList td {
            border: none !important;
            outline: none !important;
        }
    </style>

    <div class="row">
        <div class="col-lg-12">
            <h3>Agregar un nuevo Vehículo</h3>
        </div>
    </div>



    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control" placeholder="Matrícula del Vehículo" Style="width: 250px;">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvMatricula" runat="server" ControlToValidate="txtMatricula"
                ErrorMessage="Ingrese una matrícula" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red">Vehículo ya regristrado.</asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" placeholder="Marca del Vehículo" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvMarca" runat="server" ControlToValidate="txtMarca"
                ErrorMessage="Ingrese la marca del vehículo" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control" placeholder="Modelo del Vehículo" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvModelo" runat="server" ControlToValidate="txtModelo"
                ErrorMessage="Ingrese el modelo del vehículo" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox TextMode="Number" min="0" ID="txtKilometros" runat="server" CssClass="form-control" placeholder="Cantidad de Kilometros" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvKilometros" runat="server" ControlToValidate="txtKilometros"
                ErrorMessage="Ingrese los kilometros del vehículo" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <h6>Elija la fecha de fabricación del vehículo</h6>
    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox TextMode="Date" ID="txtAnio" runat="server" CssClass="form-control" placeholder="Año del Vehículo" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvAnio" runat="server" ControlToValidate="txtAnio"
                ErrorMessage="Ingrese el año del vehiculo" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtColor" runat="server" CssClass="form-control" placeholder="Color del Vehículo" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvColor" runat="server" ControlToValidate="txtColor"
                ErrorMessage="Ingrese el color del vehículo" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtimagen1" TextMode="Url" runat="server" CssClass="form-control" placeholder="Imagen 1 del Vehículo" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtimagen1" runat="server" ErrorMessage="Debe ingresar 3 imagenes" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtimagen2" TextMode="Url" runat="server" CssClass="form-control" placeholder="Imagen 2 del Vehículo" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtimagen2" runat="server" ErrorMessage="Debe ingresar 3 imagenes" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtimagen3" TextMode="Url" runat="server" CssClass="form-control" placeholder="Imagen 3 del Vehículo" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtimagen3" runat="server" ErrorMessage="Debe ingresar 3 imagenes" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox TextMode="Number" min="1" ID="txtPrecioVenta" runat="server" CssClass="form-control" placeholder="Precio de venta" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPrecioVenta" runat="server" ControlToValidate="txtPrecioVenta"
                ErrorMessage="Ingrese el precio de venta" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox TextMode="Number" min="1" ID="txtPrecioAlquiler" runat="server" CssClass="form-control" placeholder="Precio de alquiler" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPrecioAlquiler" runat="server" ControlToValidate="txtPrecioAlquiler"
                ErrorMessage="Ingrese el precio de alquiler por día" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row" id="tipoVehiculo">
        <div class="col-lg-5">
            <asp:RadioButtonList CssClass="customRadioButtonList" ID="rblTipoVehiculo" runat="server" OnSelectedIndexChanged="rblTipoVehiculo_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="Moto" Selected="True">Moto</asp:ListItem>
                <asp:ListItem Value="Auto">Auto</asp:ListItem>
                <asp:ListItem Value="Camión">Camion</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>


    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox min="1" ID="txtCantidadPasajeros" Visible="false" TextMode="Number" runat="server" CssClass="form-control" placeholder="Cantidad de pasajeros" Style="width: 250px;"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox min="1" ID="txtCilindradas" Visible="true" runat="server" TextMode="Number" CssClass="form-control" placeholder="Cilindradas del Vehículo" Style="width: 250px;"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox min="1" ID="txtToneladas" Visible="false" TextMode="Number" runat="server" CssClass="form-control" placeholder="Capacidad de carga" Style="width: 250px;"></asp:TextBox>
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
            <h3>Lista de Vehículos</h3>
            <asp:GridView ID="gvVehiculos" runat="server" Width="100%" BorderWidth="2px" CellSpacing="5" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center"
                OnRowCancelingEdit="gvVehiculos_RowCancelingEdit"
                OnRowDeleting="gvVehiculos_RowDeleting"
                OnRowEditing="gvVehiculos_RowEditing"
                OnRowUpdating="gvVehiculos_RowUpdating"
                AutoGenerateColumns="false"
                OnRowDataBound="gvVehiculos_RowDataBound"
                DataKeyNames="Matricula">
                <Columns>

                    <asp:TemplateField HeaderText="Matrícula" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl1" runat="server" Text='<%# Bind("matricula") %>'></asp:Label>    
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lbl2" runat="server" Text='<%# Bind("matricula") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Marca" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl3" runat="server" Text='<%# Bind("marca") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMarcaGrid" runat="server" Text='<%# Bind("marca") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Modelo" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl23" runat="server" Text='<%# Bind("modelo") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtModeloGrid" runat="server" Text='<%# Bind("modelo") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Kilometraje" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl24" runat="server" Text='<%# Bind("kilometros") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtKilometrosGrid" TextMode="Number" min="0" runat="server" Text='<%# Bind("kilometros") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Año" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl25" runat="server" Text='<%# Eval("anio", "{0:yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAnioGrid" TextMode="Number" min="0" runat="server" Text='<%# Bind("anio", "{0:yyyy}") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Color" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl29" runat="server" Text='<%# Bind("color") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtColorGrid" runat="server" Text='<%# Bind("color") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio Venta" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl27" runat="server" Text='<%# Bind("precioVenta") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrecioVentaGrid" TextMode="Number" min="0" runat="server" Text='<%# Bind("precioVenta") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio Alquiler" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl28" runat="server" Text='<%# Bind("precioAlquiler") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrecioAlquilerGrid" TextMode="Number" min="0" runat="server" Text='<%# Bind("precioAlquiler") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Imagen 1" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Image ID="lbl20" runat="server" ImageUrl='<%# Bind("imagen1") %>' Width="150"></asp:Image>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtImagen1Grid" runat="server" Text='<%# Bind("imagen1") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Imagen 2" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Image ID="lbl21" runat="server" ImageUrl='<%# Bind("imagen2") %>' Width="150"></asp:Image>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtImagen2Grid" runat="server" Text='<%# Bind("imagen2") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Imagen 3" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Image ID="lbl22" runat="server" ImageUrl='<%# Bind("imagen3") %>' Width="150"></asp:Image>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtImagen3Grid" runat="server" Text='<%# Bind("imagen3") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Editar" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-primary" ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton CssClass="btn btn-primary" ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                            <asp:LinkButton CssClass="btn btn-secondary" ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Eliminar" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-dark" ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton CssClass="btn btn-dark" ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
