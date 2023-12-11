<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Prueba_de_appWEB_ASP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row text-center" aria-labelledby="welcomeTitle">
            <h1 id="welcomeTitle" class="font-weight-bold" style="color:#0052AA; b">L.A. Motors: Rent & Buy Your Ride</h1>
            <hr class="my-4"/>
        </section>
        <section class="row " aria-labelledby="welcomeTitle">
            <div class="row">
                <p class="lead">
                    Bienvenido nuevamente, <strong>
                        <asp:Label ID="UserNameLabel" runat="server" Text="<%# User.Identity.Name %>" /></strong>. Aquí puedes comenzar tus operaciones:
                </p>
            </div>
        </section>

        <div class="row">
            <section class="col-md-6">
                <h2>Ventas</h2>
                <p>
                    Registra ventas detalladas y administra la lista de transacciones de vehículos.
                </p>
                <p>
                    <a id="btnVentas" runat="server" class="btn btn-primary" visible="true" href="Ventas.aspx">Ir a Ventas &raquo;</a>
                </p>
            </section>
            <section class="col-md-6">
                <h2>Alquileres</h2>
                <p>
                    Administra los alquileres de vehículos, registra nuevos contratos de alquiler y gestiona las fechas y detalles de devolución. 
                </p>
                <p>
                    <a id="btnAlquileres" runat="server" class="btn btn-primary" visible="true" href="Alquileres.aspx">Ir a Alquileres &raquo;</a>
                </p>
            </section>
        </div>

        <div class="row">
            <section class="col-md-6">
                <h2>Clientes</h2>
                <p>
                    Gestiona la lista de clientes: añade nuevos y edita la información existente.
                </p>
                <p>
                    <a id="btnClientes" runat="server" class="btn btn-primary" visible="true" href="Clientes.aspx">Ir a Clientes &raquo;</a>
                </p>
            </section>
            <section class="col-md-6">
                <h2>Vehículos</h2>
                <p>
                    Administra el inventario de vehículos: ingresa nuevos y edita el stock.
                </p>
                <p>
                    <a id="btnVehiculos" runat="server" class="btn btn-primary" visible="true" href="Vehiculos.aspx">Ir a Vehículos &raquo;</a>
                </p>
            </section>
        </div>
    </main>
</asp:Content>
