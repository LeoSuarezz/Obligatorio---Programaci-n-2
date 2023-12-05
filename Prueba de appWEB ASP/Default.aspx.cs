﻿using Prueba_de_appWEB_ASP.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba_de_appWEB_ASP
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("lnkUsuarios").Visible = BaseDeDatos.usuarioLogeado.getVerUsuarios();
            Master.FindControl("lnkClientes").Visible = BaseDeDatos.usuarioLogeado.getVerClientes();
            Master.FindControl("lnkVehiculos").Visible = BaseDeDatos.usuarioLogeado.getVerVehiculos();
            Master.FindControl("lnkVentas").Visible = BaseDeDatos.usuarioLogeado.getVerVentas();
            Master.FindControl("lnkAlquileres").Visible = BaseDeDatos.usuarioLogeado.getVerAlquileres();

            if (!IsPostBack)
            {
                UserNameLabel.Text = BaseDeDatos.usuarioLogeado.getUsername();

                // Verificar los permisos y ocultar los botones según sea necesario
                if (!BaseDeDatos.usuarioLogeado.getVerVentas())
                {
                    btnVentas.Visible = false;
                }

                if (!BaseDeDatos.usuarioLogeado.getVerAlquileres())
                {
                    // Ajusta el ID del botón de Alquileres según tu código real
                    btnAlquileres.Visible = false;
                }
            }
        }

    }
}