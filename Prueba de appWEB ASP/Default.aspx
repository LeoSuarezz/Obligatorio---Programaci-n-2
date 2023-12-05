<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Prueba_de_appWEB_ASP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row text-center" aria-labelledby="welcomeTitle">
            <h1 id="welcomeTitle">L.A. Motors: Rent & Buy Your Ride</h1>

        </section>
        <section class="row " aria-labelledby="welcomeTitle">
            <div class="row">
                <p class="lead">Bienvenido nuevamente, <strong>
                    <asp:Label ID="UserNameLabel" runat="server" Text="<%# User.Identity.Name %>" /></strong>. Aquí puedes comenzar tus operaciones:</p>
            </div>
        </section>

        <div class="row">
            <section class="col-md-6">
                <h2>Ventas</h2>
                <p>
                    Realiza la venta de un vehículo disponible en el stock.
                </p>
                <p>
                    <a id="btnVentas" runat="server" class="btn btn-primary" visible="true" href="Ventas.aspx">Ir a Ventas &raquo;</a>
                </p>
            </section>
            <section class="col-md-6">
                <h2>Alquileres</h2>
                <p>
                    Realiza el alquiler de un vehículo disponible en el stock.
                </p>
                <p>
                    <a id="btnAlquileres" runat="server" class="btn btn-primary" visible="true" href="Alquileres.aspx">Ir a Alquileres &raquo;</a>
                </p>
            </section>
        </div>
    </main>
</asp:Content>
