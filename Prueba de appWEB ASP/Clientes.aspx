<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Prueba_de_appWEB_ASP.Clientes" %>

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
            <h3>Agregar un nuevo Cliente</h3>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre del Cliente" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="Ingrese el nombre del Cliente" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Apellido del Cliente" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido"
                ErrorMessage="Ingrese el apellido del Cliente" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" placeholder="Documento del Cliente" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ControlToValidate="txtDocumento"
                ErrorMessage="Ingrese el documento del Cliente" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red">Cliente ya registrado.</asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:Label ID="lblErrorCedulaUruguaya" runat="server" Visible="false" ForeColor="Red">El documento ingresado no es válido.</asp:Label>
        </div>
    </div>


    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Dirección del Cliente" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion"
                ErrorMessage="Ingrese la dirección del Cliente" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox TextMode="Number" min="0" ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Teléfono del Cliente" Style="width: 250px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono"
                ErrorMessage="Ingrese el teléfono del Cliente" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">
            </asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="Guardar" />
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:Label ID="lblIngresoCorrecto" runat="server" Visible="false" ForeColor="Blue">Cliente ingresado correctamente.</asp:Label>
        </div>
    </div>

    <hr />

    <div class="row">
        <div class="col-lg-7">
            <h3>Lista de Clientes</h3>
            <asp:GridView ID="gvClientes" runat="server" Width="80%" BorderWidth="2px" CellSpacing="15"
                OnRowCancelingEdit="gvClientes_RowCancelingEdit"
                OnRowDeleting="gvClientes_RowDeleting"
                OnRowEditing="gvClientes_RowEditing"
                OnRowUpdating="gvClientes_RowUpdating"
                AutoGenerateColumns="false"
                DataKeyNames="documentoCliente"
                OnRowDataBound="gvClientes_RowDataBound">

                <Columns>
                    <asp:TemplateField HeaderText="Documento" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl100" runat="server" Text='<%# Bind("documentoCliente") %>'></asp:Label>
                           
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <EditItemTemplate>
                            <asp:Label ID="txtDocumentoGrid" runat="server" Text='<%# Bind("documentoCliente") %>'></asp:Label>
                         
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nombre" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl101" runat="server" Text='<%# Bind("nombreCliente") %>'></asp:Label>
                          
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombreGrid" runat="server" Text='<%# Bind("nombreCliente") %>'></asp:TextBox>
                          
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Apellido" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl102" runat="server" Text='<%# Bind("apellidoCliente") %>'></asp:Label>
                           
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <EditItemTemplate>
                            <asp:TextBox ID="txtApellidoGrid" runat="server" Text='<%# Bind("apellidoCliente") %>'></asp:TextBox>
                          
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Dirección" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbl103" runat="server" Text='<%# Bind("direccionCliente") %>'></asp:Label>
                         
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDireccionGrid" runat="server" Text='<%# Bind("direccionCliente") %>'></asp:TextBox>
                       
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Teléfono" ItemStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label TextMode="Number" ID="lbl104" runat="server" Text='<%# Bind("telefonoCliente") %>'></asp:Label>
                        
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <EditItemTemplate>
                            <asp:TextBox TextMode="Number" min="1" ID="txtTelefonoGrid" runat="server" Text='<%# Bind("telefonoCliente") %>'></asp:TextBox>
                        
                        </EditItemTemplate>
                    </asp:TemplateField>
                 

                    <asp:TemplateField HeaderText="Editar" ItemStyle-BorderWidth="2px" 
                        ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" 
                        HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" 
                        HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="btn btn-primary" ID="lnkEdit" runat="server" 
                            CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton CssClass="btn btn-primary" ID="lnkUpdate" runat="server" 
                            CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                            <asp:LinkButton CssClass="btn btn-secondary" ID="lnkCancel" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Eliminar" ItemStyle-BorderWidth="2px" 
                        ItemStyle-BorderStyle="Solid" ItemStyle-HorizontalAlign="Center" 
                        HeaderStyle-BorderWidth="2px" HeaderStyle-BorderStyle="Solid" 
                        HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                          <asp:LinkButton CssClass="btn btn-dark" ID="lnkDelete" runat="server" 
                          CausesValidation="False" CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>
            </asp:GridView>
        </div>
    </div>


</asp:Content>

