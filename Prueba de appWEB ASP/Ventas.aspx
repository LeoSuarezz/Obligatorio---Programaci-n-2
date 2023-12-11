<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Prueba_de_appWEB_ASP.Ventas" %>

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
            <h3>Realizar la venta de un vehículo</h3>
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
            <asp:Label ID="lblSimbolo" runat="server" Visible="false" ForeColor="Blue">Precio de venta: $</asp:Label>
            <asp:Label ID="lblPrecio" runat="server" Visible="false" ForeColor="Blue"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Vender" OnClick="btnGuardar_Click" ValidationGroup="Guardar" />
        </div>
    </div>
    <hr />

   

    <div class="row">
        <div class="col-lg-7">
            <h3>Lista de vehículos vendidos</h3>
            <asp:GridView ID="gvVentas" runat="server" Width="80%" BorderWidth="2px" CellSpacing="15"
                AutoGenerateColumns="false"
                DataKeyNames="numVenta"
                OnRowDeleting="gvVentas_RowDeleting"
                OnRowDataBound="gvVentas_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Número de Venta" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl10" runat="server" Text='<%# Bind("NumVenta") %>'></asp:Label>
                       
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Matrícula" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl11" runat="server" Text='<%# Bind("matriculaVehiculo") %>'></asp:Label>
                      
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
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
                     
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Color" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblColor" runat="server" Text='<%# ObtenerColorVehiculo(Eval("matriculaVehiculo")) %>'></asp:Label>
                     
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Año" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblAño" runat="server" Text='<%# ObtenerAnioVehiculo(Eval("matriculaVehiculo")) %>'></asp:Label>
                     
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio Venta" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPrecioAlquiler" runat="server" Text='<%# ObtenerPrecioVentaVehiculo(Eval("matriculaVehiculo")) %>'></asp:Label>
                      
                        </ItemTemplate>
                        <ItemStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Documento Cliente" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDocumentoCliente" runat="server" Text='<%# ObtenerDocumentoCliente(Eval("documentoCliente")) %>'></asp:Label>
               
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre y Apellido Cliente" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNombreApellido" runat="server" Text='<%# ObtenerNombreApellidoCliente(Eval("documentoCLiente")) %>'></asp:Label>
                      
                        </ItemTemplate>
                        <ItemStyle Width="500px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Eliminar" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-dark" ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
