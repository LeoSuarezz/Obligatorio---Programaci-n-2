using Prueba_de_appWEB_ASP.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba_de_appWEB_ASP
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("lnkUsuarios").Visible = BaseDeDatos.usuarioLogeado.getVerUsuarios();
            Master.FindControl("lnkClientes").Visible = BaseDeDatos.usuarioLogeado.getVerClientes();
            Master.FindControl("lnkVehiculos").Visible = BaseDeDatos.usuarioLogeado.getVerVehiculos();
            Master.FindControl("lnkVentas").Visible = BaseDeDatos.usuarioLogeado.getVerVentas();
            Master.FindControl("lnkAlquileres").Visible = BaseDeDatos.usuarioLogeado.getVerAlquileres();

            if (!Page.IsPostBack)
            {
                this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
                this.gvUsuarios.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool userCorrecto = true;

            foreach (Usuario usuario in BaseDeDatos.listaUsuarios)
            {
                if (usuario.username == txtUsername.Text)
                {
                    lblError.Visible = true;
                    txtUsername.Text = string.Empty;
                    userCorrecto = false;
                }
            }

            if (userCorrecto == true)
            {
                Usuario usuario = new Usuario();

                int IdAnterior = BaseDeDatos.listaUsuarios.Any() ? BaseDeDatos.listaUsuarios.Max(usuario1 => usuario1.idUsuario) : 0;
                int IdNuevo = IdAnterior + 1;
                usuario.setIdUsuario(IdNuevo);
                
                usuario.setUsername(txtUsername.Text);
                usuario.setNombreUsuario(txtNombreUsuario.Text);
                usuario.setApellidoUsuario(txtApellidoUsuario.Text);
                usuario.setPassword(txtPassword.Text);
                usuario.setVerClientes(chkVerClientes.Checked);
                usuario.setVerUsuarios(false);
                usuario.setVerVentas(chkVerVentas.Checked);
                usuario.setVerVehiculos(chkVerVehiculos.Checked);
                usuario.setVerAlquileres(chkVerAlquileres.Checked);

                BaseDeDatos.listaUsuarios.Add(usuario);
                this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
                this.gvUsuarios.DataBind();

                txtUsername.Text = string.Empty;
                txtNombreUsuario.Text = string.Empty;
                txtApellidoUsuario.Text = string.Empty;
                txtPassword.Text = string.Empty;
                chkVerClientes.Checked = false;
                chkVerVentas.Checked = false;
                chkVerVehiculos.Checked = false;
                chkVerAlquileres.Checked = false;

            }

        }

        protected void gvUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvUsuarios.EditIndex = -1;
            this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
            this.gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string username = this.gvUsuarios.DataKeys[e.RowIndex].Values[0].ToString();  //se carga el usuario de la linea que se está por borrar
            foreach (var usuario in BaseDeDatos.listaUsuarios)
            {
                if (usuario.getUsername() == username)
                {
                    BaseDeDatos.listaUsuarios.Remove(usuario);
                    break;  //se agrega el break para que corte al momento de elimiar y saltar el error que dice que se está recorriendo una lista que se está modificando en tiempo real
                }
            }

            this.gvUsuarios.EditIndex = -1;
            this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
            this.gvUsuarios.DataBind();
        }


        protected void gvUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow filaSeleccionada = gvUsuarios.Rows[e.RowIndex];
            string username = this.gvUsuarios.DataKeys[e.RowIndex].Values[0].ToString();
           
            string nombre = (filaSeleccionada.FindControl("txtNombreGrid") as TextBox).Text;
            string apellido = (filaSeleccionada.FindControl("txtApellidoGrid") as TextBox).Text;
            CheckBox chkVerClientes = (CheckBox)filaSeleccionada.FindControl("chkVerClientes");
            CheckBox chkVerUsuarios = (CheckBox)filaSeleccionada.FindControl("chkVerUsuarios");
            CheckBox chkVerVentas = (CheckBox)filaSeleccionada.FindControl("chkVerVentas");
            CheckBox chkVerVehiculos = (CheckBox)filaSeleccionada.FindControl("chkVerVehiculos");
            CheckBox chkVerAlquileres = (CheckBox)filaSeleccionada.FindControl("chkVerAlquileres");

            foreach (var usuario in BaseDeDatos.listaUsuarios)
            {
                if (usuario.getUsername() == username)
                {
                    usuario.setNombreUsuario(nombre);
                    usuario.setApellidoUsuario(apellido);
                    usuario.setVerUsuarios(chkVerUsuarios.Checked);
                    usuario.setVerClientes(chkVerClientes.Checked);   
                    usuario.setVerVentas(chkVerVentas.Checked);
                    usuario.setVerVehiculos(chkVerVehiculos.Checked);
                    usuario.setVerAlquileres(chkVerAlquileres.Checked);
                        
                }
            }
            this.gvUsuarios.EditIndex = -1;
            this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
            this.gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvUsuarios.EditIndex = e.NewEditIndex;
            this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
            this.gvUsuarios.DataBind();
        }
        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e) //metodo para que cuando se está editando no se pueda usar el boton de eliminar en esa línea y en las demás líneas
        {
            if (gvUsuarios.EditIndex != -1 && e.Row.RowType == DataControlRowType.DataRow)
            {
                // Estás en modo de edición, deshabilita el botón de eliminación para todas las filas
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (lnkDelete != null)
                {
                    lnkDelete.Enabled = false;
                    lnkDelete.CssClass = "disabled-link"; // Agrega una clase CSS para cambiar la apariencia si lo deseas
                }
            }
        }
    }
}