using Prueba_de_appWEB_ASP.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba_de_appWEB_ASP
{
    public partial class Ventas : System.Web.UI.Page
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

                this.gvVentas.DataSource = BaseDeDatos.listaVentas;
                this.gvVentas.DataBind();

                var vehiculosDisponibles = BaseDeDatos.listaVehiculos.Where(v => v.disponible).ToList()
                    .Where(v => v.disponible)
                    .OrderBy(v => v.GetType().Name)  // Ordena por el nombre de la clase (Auto, Camion, Moto)
                    .ThenBy(v => v.datosParaLista)  // Luego por orden alfabético
                    .ToList();

                cboVehiculos.DataSource = vehiculosDisponibles;
                cboVehiculos.DataTextField = "datosParaLista";
                cboVehiculos.DataValueField = "matricula";
                cboVehiculos.DataBind();

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();
            venta.setDocumentoCliente(lstClientes.SelectedItem.Value);
            venta.setMatricula(cboVehiculos.SelectedItem.Value);
            venta.setUsername(BaseDeDatos.usuarioLogeado.getUsername());

            string Matricula = cboVehiculos.SelectedItem.Value;
            int precio = 0;
            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (vehiculo.matricula == Matricula)
                {
                    precio = vehiculo.precioVenta;
                    break;
                }
            }
            venta.setTotalVenta(precio);
            venta.setFechaVenta(DateTime.Now);

            int numVentaAnterior = BaseDeDatos.listaVentas.Any() ? BaseDeDatos.listaVentas.Max(venta1 => venta1.numVenta) : 0;
            int numVentaNuevo = numVentaAnterior + 1;
            venta.setNumVenta(numVentaNuevo);

            BaseDeDatos.listaVentas.Add(venta);

            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (venta.getMatricula() == vehiculo.getMatricula())
                {
                    vehiculo.setDisponible(false);
                }
            }
            this.gvVentas.DataSource = BaseDeDatos.listaVentas; //le dice "ESTE ES EL LISTADO A CARGAR"
            this.gvVentas.DataBind();

            ActualizarListaVehiculos(); //actualisa visualmente la lista de vehiculos a vender
        }

        protected void cboVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Matricula = cboVehiculos.SelectedItem.Value;

            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (vehiculo.matricula == Matricula)
                {
                    lblPrecio.Text = vehiculo.precioVenta.ToString();
                    lblPrecio.Visible = true;
                    lblSimbolo.Visible = true;
                }
            }
        }

        protected void gvVentas_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected string ObtenerPrecioVentaVehiculo(object matriculaObject)
        {
            string matricula = matriculaObject.ToString();
            Vehiculo vehiculo = BaseDeDatos.ObtenerDatosVehiculos().Find(v => v.matricula == matricula);

            return vehiculo != null ? "$" + vehiculo.precioVenta.ToString() : "No disponible";
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

    }
}