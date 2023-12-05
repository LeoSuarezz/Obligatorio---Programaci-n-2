using Prueba_de_appWEB_ASP.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba_de_appWEB_ASP
{
    public partial class Alquileres : System.Web.UI.Page
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
                lstClientes.DataSource = BaseDeDatos.listaClientes;
                lstClientes.DataTextField = "datosCliente";
                lstClientes.DataValueField = "documentoCliente";
                lstClientes.DataBind();

                this.gvAlquiler.DataSource = BaseDeDatos.listaAlquileres;
                this.gvAlquiler.DataBind();

                var vehiculosDisponibles = BaseDeDatos.listaVehiculos.Where(v => v.disponible).ToList()
                    .Where(v => v.disponible)
                    .OrderBy(v => v.GetType().Name)  // Ordena por el nombre de la clase (Auto, Camion, Moto)
                    .ThenBy(v => v.datosParaLista)  // Luego por orden alfabético
                    .ToList();
                    
                cboVehiculos.DataSource = vehiculosDisponibles;
                cboVehiculos.DataTextField = "datosParaLista";
                cboVehiculos.DataValueField = "matricula";
                cboVehiculos.DataBind();

                txtCantDias.TextChanged += new EventHandler(txtCantDias_TextChanged);

            }
        }
        protected void txtCantDias_TextChanged(object sender, EventArgs e)
        {
            // Este método se ejecutará cuando cambie el texto en el TextBox
            ActualizarPrecio();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Alquiler alquiler = new Alquiler();
            alquiler.setDocumentoCliente(lstClientes.SelectedItem.Value);
            alquiler.setMatricula(cboVehiculos.SelectedItem.Value);
            alquiler.setUsername(BaseDeDatos.usuarioLogeado.getUsername());

            string Matricula = cboVehiculos.SelectedItem.Value;

            int cantDias = Convert.ToInt32(txtCantDias.Text);
            alquiler.setCantidadDias(cantDias);


            int precioTotal = 0;
            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (alquiler.getMatricula() == vehiculo.getMatricula())
                {
                    precioTotal = vehiculo.getPrecioAlquiler() * cantDias;
                }
            }
            alquiler.setPrecioTotal(precioTotal);
            DateTime fechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            alquiler.setFechaInicio(fechaInicio);

            int numAlquilerAnterior = BaseDeDatos.listaAlquileres.Any() ? BaseDeDatos.listaAlquileres.Max(alquiler1 => alquiler1.numAlquiler) : 0;
            int numAlquilerNuevo = numAlquilerAnterior + 1;
            alquiler.setNumAlquiler(numAlquilerNuevo);

            BaseDeDatos.listaAlquileres.Add(alquiler);

            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (alquiler.getMatricula() == vehiculo.getMatricula())
                {
                    vehiculo.setDisponible(false);
                }
            }
            //this.gvAlquiler.DataSource = BaseDeDatos.listaAlquileres; //le dice "ESTE ES EL LISTADO A CARGAR"
            //this.gvAlquiler.DataBind();
            

            ActualizarListaVehiculos(); //actualisa visualmente la lista de vehiculos a vender
        }

        protected void gvAlquiler_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvAlquiler.EditIndex = e.NewEditIndex;
            this.gvAlquiler.DataSource = BaseDeDatos.listaAlquileres;
            this.gvAlquiler.DataBind();
        }
        protected void gvAlquiler_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(this.gvAlquiler.DataKeys[e.RowIndex].Values[0]);   //se carga el ID de alquiler de la fila en la que se da click en eliminar
            foreach (var alquiler in BaseDeDatos.listaAlquileres)
            {
                if (alquiler.getNumAlquiler() == ID)
                {
                    BaseDeDatos.listaAlquileres.Remove(alquiler);
                    break;  //se agrega el break para que corte al momento de elimiar y saltar el error que dice que se está recorriendo una lista que se está modificando en tiempo real
                }
            }

            this.gvAlquiler.EditIndex = -1;
            this.gvAlquiler.DataSource = BaseDeDatos.listaAlquileres;
            this.gvAlquiler.DataBind();
        }
        protected void gvAlquiler_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow filaSeleccionada = gvAlquiler.Rows[e.RowIndex];
            int ID = Convert.ToInt32(this.gvAlquiler.DataKeys[e.RowIndex].Values[0]);

            string matricula = (filaSeleccionada.FindControl("txtMatriculaGrid") as TextBox).Text;
            CheckBox chkAutoDevuelto = (CheckBox)filaSeleccionada.FindControl("chkDevueltoGrid");

            //string apellido = (filaSeleccionada.FindControl("txtApellidoGrid") as TextBox).Text;
            //string direccion = (filaSeleccionada.FindControl("txtDireccionGrid") as TextBox).Text;
            //string telefono = (filaSeleccionada.FindControl("txtTelefonoGrid") as TextBox).Text;

            foreach (var alquiler in BaseDeDatos.listaAlquileres)
            {
                if (alquiler.getNumAlquiler() == ID)
                {
                    alquiler.setMatricula(matricula);
                    alquiler.setEstadoAlquiler(chkAutoDevuelto.Checked);
                    
                }
            }

            this.gvAlquiler.EditIndex = -1;
            this.gvAlquiler.DataSource = BaseDeDatos.listaAlquileres;
            this.gvAlquiler.DataBind();

        }

        protected void cboVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();
        }

        protected void gvAlquiler_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Obtener la matrícula de la fila actual
                string matricula = DataBinder.Eval(e.Row.DataItem, "matriculaVehiculo").ToString();

                // Obtener la lista de vehículos desde la clase BaseDeDatos
                List<Vehiculo> listaVehiculos = BaseDeDatos.ObtenerDatosVehiculos();

                // Buscar el vehículo por matrícula
                Vehiculo vehiculo = listaVehiculos.Find(v => v.matricula == matricula);

            }
        }

        protected string ObtenerMarcaVehiculo(object matriculaObject)
        {
            string matricula = matriculaObject.ToString();
            Vehiculo vehiculo = BaseDeDatos.ObtenerDatosVehiculos().Find(v => v.matricula == matricula);

            return vehiculo != null ? vehiculo.marca : "No disponible";
        }
        protected string ObtenerModeloVehiculo(object matriculaObject)
        {
            string matricula = matriculaObject.ToString();
            Vehiculo vehiculo = BaseDeDatos.ObtenerDatosVehiculos().Find(v => v.matricula == matricula);

            return vehiculo != null ? vehiculo.modelo : "No disponible";
        }
        protected string ObtenerColorVehiculo(object matriculaObject)
        {
            string matricula = matriculaObject.ToString();
            Vehiculo vehiculo = BaseDeDatos.ObtenerDatosVehiculos().Find(v => v.matricula == matricula);

            return vehiculo != null ? vehiculo.color : "No disponible";
        }
        protected string ObtenerAnioVehiculo(object matriculaObject)
        {
            string matricula = matriculaObject.ToString();
            Vehiculo vehiculo = BaseDeDatos.ObtenerDatosVehiculos().Find(v => v.matricula == matricula);

            return vehiculo != null ? vehiculo.anio.Year.ToString() : "No disponible";
        }
        protected string ObtenerPrecioAlquilerVehiculo(object matriculaObject)
        {
            string matricula = matriculaObject.ToString();
            Vehiculo vehiculo = BaseDeDatos.ObtenerDatosVehiculos().Find(v => v.matricula == matricula);

            return vehiculo != null ? "$" + vehiculo.precioAlquiler.ToString() : "No disponible";
        }
        protected string ObtenerDocumentoCliente(object documentoObject)
        {
            string documento = documentoObject.ToString();
            Cliente cliente = BaseDeDatos.ObtenerDatosClientes().Find(v => v.documentoCliente == documento);

            return cliente != null ? cliente.documentoCliente.ToString() : "No disponible";
        }
        protected string ObtenerNombreApellidoCliente(object documentoObject)
        {
            string documento = documentoObject.ToString();
            Cliente cliente = BaseDeDatos.ObtenerDatosClientes().Find(v => v.documentoCliente == documento);

            return cliente != null ? cliente.nombreCliente.ToString() + " " + cliente.apellidoCliente.ToString() : "No disponible";
        }

        private void ActualizarListaVehiculos() // //actualista visualmente la lista de vehiculos a vender
        {
            var vehiculosDisponibles = BaseDeDatos.listaVehiculos.Where(v => v.disponible).ToList();

            cboVehiculos.DataSource = vehiculosDisponibles;
            cboVehiculos.DataTextField = "datosParaLista";
            cboVehiculos.DataValueField = "matricula";
            cboVehiculos.DataBind();
        }

        private void ActualizarPrecio()
        {
            string Matricula = cboVehiculos.SelectedItem.Value;
            Alquiler alquiler = new Alquiler();

            int precioTotal = 0;
            int cantDias = 0;

            if (txtCantDias.Text != "")
            {
                cantDias = Convert.ToInt32(txtCantDias.Text);
            }
            alquiler.setCantidadDias(cantDias);

            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (vehiculo.matricula == Matricula)
                {
                    precioTotal = vehiculo.getPrecioAlquiler() * cantDias;
                    lblPrecio.Text = precioTotal.ToString();
                    lblPrecio.Visible = true;
                    lblSimbolo.Visible = true;
                }
            }
        }
    }
}