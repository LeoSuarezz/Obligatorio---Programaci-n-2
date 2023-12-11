using Prueba_de_appWEB_ASP.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba_de_appWEB_ASP
{
    public partial class Vehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("lnkUsuarios").Visible = BaseDeDatos.usuarioLogeado.getVerUsuarios();
            Master.FindControl("lnkClientes").Visible = BaseDeDatos.usuarioLogeado.getVerClientes();
            Master.FindControl("lnkVehiculos").Visible = BaseDeDatos.usuarioLogeado.getVerVehiculos();
            Master.FindControl("lnkVentas").Visible = BaseDeDatos.usuarioLogeado.getVerVentas();
            Master.FindControl("lnkAlquileres").Visible = BaseDeDatos.usuarioLogeado.getVerAlquileres();

            if (!BaseDeDatos.usuarioLogeado.getVerVehiculos())
            {
                Response.Redirect("Default.aspx");

            }

            if (!Page.IsPostBack)
            {
                var vehiculosDisponibles = BaseDeDatos.listaVehiculos.Where(v => v.disponible).ToList();                   

                this.gvVehiculos.DataSource = vehiculosDisponibles;
                this.gvVehiculos.DataBind(); 
            }
        }

        protected void gvVehiculos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvVehiculos.EditIndex = -1;
            var vehiculosDisponibles = BaseDeDatos.listaVehiculos.Where(v => v.disponible).ToList();

            this.gvVehiculos.DataSource = vehiculosDisponibles;
            this.gvVehiculos.DataBind();
        }

        protected void gvVehiculos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string matricula = this.gvVehiculos.DataKeys[e.RowIndex].Values[0].ToString();  
            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (vehiculo.getMatricula() == matricula)
                {
                    BaseDeDatos.listaVehiculos.Remove(vehiculo);
                    break;  
                }
            }

            this.gvVehiculos.EditIndex = -1;
            this.gvVehiculos.DataSource = BaseDeDatos.listaVehiculos;
            this.gvVehiculos.DataBind();
        }


        protected void gvVehiculos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow filaSeleccionada = gvVehiculos.Rows[e.RowIndex];
            string matricula = this.gvVehiculos.DataKeys[e.RowIndex].Values[0].ToString();

            string marca = (filaSeleccionada.FindControl("txtMarcaGrid") as TextBox).Text;
            string modelo = (filaSeleccionada.FindControl("txtModeloGrid") as TextBox).Text;

            int valorIngresadoKilometros;
            int valorIngresadoAnio;
            int valorIngresadoPrecioVenta;
            int valorIngresadoPrecioAlquiler;

            if (int.TryParse((filaSeleccionada.FindControl("txtKilometrosGrid") as TextBox).Text, out valorIngresadoKilometros) && valorIngresadoKilometros >= 1
                && int.TryParse((filaSeleccionada.FindControl("txtAnioGrid") as TextBox).Text, out valorIngresadoAnio) && valorIngresadoAnio >= 1
                && int.TryParse((filaSeleccionada.FindControl("txtPrecioVentaGrid") as TextBox).Text, out valorIngresadoPrecioVenta) && valorIngresadoPrecioVenta >= 1
                && int.TryParse((filaSeleccionada.FindControl("txtPrecioAlquilerGrid") as TextBox).Text, out valorIngresadoPrecioAlquiler) && valorIngresadoPrecioAlquiler >= 1)
            {
                foreach (var vehiculo in BaseDeDatos.listaVehiculos)
                {
                    if (vehiculo.getMatricula() == matricula)
                    {
                        vehiculo.setMarca(marca);
                        vehiculo.setModelo(modelo);
                        vehiculo.setKilometros(valorIngresadoKilometros);
                        vehiculo.setAnio(new DateTime(valorIngresadoAnio, 1, 1));
                        vehiculo.setColor((filaSeleccionada.FindControl("txtColorGrid") as TextBox).Text);
                        vehiculo.setPrecioVenta(valorIngresadoPrecioVenta);
                        vehiculo.setPrecioAlquiler(valorIngresadoPrecioAlquiler);
                        vehiculo.setImagen1((filaSeleccionada.FindControl("txtImagen1Grid") as TextBox).Text);
                        vehiculo.setImagen2((filaSeleccionada.FindControl("txtImagen2Grid") as TextBox).Text);
                        vehiculo.setImagen3((filaSeleccionada.FindControl("txtImagen3Grid") as TextBox).Text);
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Ha ingresado un valor incorrecto, verifique e intente nuevamente.')</script>");
            }

            this.gvVehiculos.EditIndex = -1;
            var vehiculosDisponibles = BaseDeDatos.listaVehiculos.Where(v => v.disponible).ToList();

            this.gvVehiculos.DataSource = vehiculosDisponibles;
            this.gvVehiculos.DataBind();
        }


        protected void gvVehiculos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvVehiculos.EditIndex = e.NewEditIndex;
            var vehiculosDisponibles = BaseDeDatos.listaVehiculos.Where(v => v.disponible).ToList();

            this.gvVehiculos.DataSource = vehiculosDisponibles;
            this.gvVehiculos.DataBind();
        }

        protected void rblTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblTipoVehiculo.SelectedItem.Value == "Moto")
            {
                txtCilindradas.Visible = true;
                txtCantidadPasajeros.Visible = false;
                txtToneladas.Visible = false;
            }
            if (rblTipoVehiculo.SelectedItem.Value == "Auto")
            {
                txtCilindradas.Visible = false;
                txtCantidadPasajeros.Visible = true;
                txtToneladas.Visible = false;
            }
            if (rblTipoVehiculo.SelectedItem.Value == "Camion")
            {
                txtCilindradas.Visible = false;
                txtCantidadPasajeros.Visible = false;
                txtToneladas.Visible = true;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool matriculaCorrecta = true;
            foreach (Vehiculo vehiculos in BaseDeDatos.listaVehiculos)
            {
                if (vehiculos.matricula == txtMatricula.Text)
                {
                    lblError.Visible = true;
                    txtMatricula.Text = string.Empty;
                    matriculaCorrecta = false;
                }
            }

            if (rblTipoVehiculo.SelectedItem.Value == "Moto" && matriculaCorrecta == true)
            {
                Moto vehiculo = new Moto();
                vehiculo.setDisponible(true);
                vehiculo.setMatricula(txtMatricula.Text);
                vehiculo.setMarca(txtMarca.Text);
                vehiculo.setModelo(txtModelo.Text);
                int kilometros = Convert.ToInt32(txtKilometros.Text);
                vehiculo.setKilometros(kilometros);
            
                vehiculo.setColor(txtColor.Text);
                int precioventa = Convert.ToInt32(txtPrecioVenta.Text);
                vehiculo.setPrecioVenta(precioventa);
                int precioAlquiler = Convert.ToInt32(txtPrecioAlquiler.Text);
                vehiculo.setPrecioAlquiler(precioAlquiler);
                vehiculo.setImagen1(txtimagen1.Text);
                vehiculo.setImagen2(txtimagen2.Text);
                vehiculo.setImagen3(txtimagen3.Text);
                int cilindrada = Convert.ToInt32(txtCilindradas.Text);
                vehiculo.setCilindrada(cilindrada);

                BaseDeDatos.listaVehiculos.Add(vehiculo);
                this.gvVehiculos.DataSource = BaseDeDatos.listaVehiculos; 
                this.gvVehiculos.DataBind(); 
            }
            if (rblTipoVehiculo.SelectedItem.Value == "Auto" && matriculaCorrecta == true)
            {
                Auto vehiculo = new Auto();
                vehiculo.setDisponible(true);
                vehiculo.setMatricula(txtMatricula.Text);
                vehiculo.setMarca(txtMarca.Text);
                vehiculo.setModelo(txtModelo.Text);
                int kilometros = Convert.ToInt32(txtKilometros.Text);
                vehiculo.setKilometros(kilometros);
            
                vehiculo.setColor(txtColor.Text);
                int precioventa = Convert.ToInt32(txtPrecioVenta.Text);
                vehiculo.setPrecioVenta(precioventa);
                int precioAlquiler = Convert.ToInt32(txtPrecioAlquiler.Text);
                vehiculo.setPrecioAlquiler(precioAlquiler);
                vehiculo.setImagen1(txtimagen1.Text);
                vehiculo.setImagen2(txtimagen2.Text);
                vehiculo.setImagen3(txtimagen3.Text);
                int cantPasajeros = Convert.ToInt32(txtCantidadPasajeros.Text);
                vehiculo.setNumPasajeros(cantPasajeros);

                BaseDeDatos.listaVehiculos.Add(vehiculo);
                this.gvVehiculos.DataSource = BaseDeDatos.listaVehiculos; 
                this.gvVehiculos.DataBind(); 
            }
            if (rblTipoVehiculo.SelectedItem.Value == "Camion" && matriculaCorrecta == true)
            {
                Camion vehiculo = new Camion();
                vehiculo.setDisponible(true);
                vehiculo.setMatricula(txtMatricula.Text);
                vehiculo.setMarca(txtMarca.Text);
                vehiculo.setModelo(txtModelo.Text);
                int kilometros = Convert.ToInt32(txtKilometros.Text);
                vehiculo.setKilometros(kilometros);
               
                vehiculo.setColor(txtColor.Text);
                int precioventa = Convert.ToInt32(txtPrecioVenta.Text);
                vehiculo.setPrecioVenta(precioventa);
                int precioAlquiler = Convert.ToInt32(txtPrecioAlquiler.Text);
                vehiculo.setPrecioAlquiler(precioAlquiler);
                vehiculo.setImagen1(txtimagen1.Text);
                vehiculo.setImagen2(txtimagen2.Text);
                vehiculo.setImagen3(txtimagen3.Text);
                int toneladas = Convert.ToInt32(txtToneladas.Text);
                vehiculo.setCapacidadCarga(toneladas);

                BaseDeDatos.listaVehiculos.Add(vehiculo);
                this.gvVehiculos.DataSource = BaseDeDatos.listaVehiculos; 
                this.gvVehiculos.DataBind();  

            }

            txtMatricula.Text = string.Empty; 
            txtMarca.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtKilometros.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtimagen1.Text = string.Empty;
            txtimagen2.Text = string.Empty;
            txtimagen2.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            txtPrecioAlquiler.Text = string.Empty;
            txtCantidadPasajeros.Text = string.Empty;
            txtCilindradas.Text = string.Empty;
            txtToneladas.Text = string.Empty;
        }
        protected void gvVehiculos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (gvVehiculos.EditIndex != -1 && e.Row.RowType == DataControlRowType.DataRow)
            {
               
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (lnkDelete != null)
                {
                    lnkDelete.Enabled = false;
                    lnkDelete.CssClass = "btn btn-dark";
                }
            }
        }
    }
}