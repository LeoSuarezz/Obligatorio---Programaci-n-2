using Prueba_de_appWEB_ASP.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba_de_appWEB_ASP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("nombreapp").Visible = false;
            Master.FindControl("lnkUsuarios").Visible = false;
            Master.FindControl("lnkClientes").Visible = false;
            Master.FindControl("lnkVehiculos").Visible = false;
            Master.FindControl("lnkVentas").Visible = false;
            Master.FindControl("lnkAlquileres").Visible = false;
            Master.FindControl("lnkLogOut").Visible = false;

          
            if (!Page.IsPostBack)
            {
                if (BaseDeDatos.listaUsuarios.Count == 0)
                {
                    BaseDeDatos.CagarDatosIniciales();

                }

            }
            //PostBack es cuando la pagina se carga despues de cada evento, un click, cambio en la grilla 
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (var usuario in BaseDeDatos.listaUsuarios)
            {

                if (usuario.getUsername() == txtUsuario.Text && usuario.getPassword() == txtContrasena.Text)
                {
                    BaseDeDatos.GuardarUsuarioLogeado(usuario);
                    Response.Redirect("Default.aspx");
                }
            }
            lblError.Visible = true;
            //muestra el msj que estaba oculto

            //otra forma, salta el popUp:
            //Response.Write("<script>alert('usuario y/o contraseña incorrectos')</script>");
        }
    }
}