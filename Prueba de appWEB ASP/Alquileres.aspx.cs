using Prueba_de_appWEB_ASP.Clases;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            if (!BaseDeDatos.usuarioLogeado.getVerAlquileres())
            {
                Response.Redirect("Default.aspx");

            }

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
                    .OrderBy(v => v.GetType().Name)  
                    .ThenBy(v => v.datosParaLista)  
                    .ToList();

                cboVehiculos.DataSource = vehiculosDisponibles;
                cboVehiculos.DataTextField = "datosParaListaAlq";
                cboVehiculos.DataValueField = "matricula";
                cboVehiculos.DataBind();

                txtCantDias.TextChanged += new EventHandler(txtCantDias_TextChanged);

            }
        }
        protected void txtCantDias_TextChanged(object sender, EventArgs e)
        {
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
            this.gvAlquiler.DataSource = BaseDeDatos.listaAlquileres; 
            this.gvAlquiler.DataBind();


            ActualizarListaVehiculos(); 
        }

        protected void gvAlquiler_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvAlquiler.EditIndex = e.NewEditIndex;
            this.gvAlquiler.DataSource = BaseDeDatos.listaAlquileres;
            this.gvAlquiler.DataBind();
        }
        protected void gvAlquiler_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(this.gvAlquiler.DataKeys[e.RowIndex].Values[0]); 
            foreach (var alquiler in BaseDeDatos.listaAlquileres)
            {
                if (alquiler.getNumAlquiler() == ID)
                {
                    string matricula = alquiler.getMatricula();
            
                    var vehiculo = BaseDeDatos.listaVehiculos.Find(v => v.getMatricula() == matricula);

                    if (vehiculo != null)
                    {
                      
                        vehiculo.setDisponible(true);
                    }

                    BaseDeDatos.listaAlquileres.Remove(alquiler);

                    break; 
                }
            }

            this.gvAlquiler.EditIndex = -1;
            this.gvAlquiler.DataSource = BaseDeDatos.listaAlquileres;
            this.gvAlquiler.DataBind();

            ActualizarListaVehiculos();
        }
        protected void gvAlquiler_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow filaSeleccionada = gvAlquiler.Rows[e.RowIndex];
            int ID = Convert.ToInt32(this.gvAlquiler.DataKeys[e.RowIndex].Values[0]);

            CheckBox chkAutoDevuelto = (CheckBox)filaSeleccionada.FindControl("chkDevueltoGrid");

            foreach (var alquiler in BaseDeDatos.listaAlquileres)
            {
                if (alquiler.getNumAlquiler() == ID)
                {
                    alquiler.setEstadoAlquiler(chkAutoDevuelto.Checked);

                    var vehiculo = BaseDeDatos.listaVehiculos.Find(v => v.getMatricula() == alquiler.getMatricula());

                    if (vehiculo != null)
                    {
                   
                        vehiculo.setDisponible(true);
                    }

                }
            }

            this.gvAlquiler.EditIndex = -1;
            this.gvAlquiler.DataSource = BaseDeDatos.listaAlquileres;
            this.gvAlquiler.DataBind();

            ActualizarListaVehiculos();
        }
        protected void gvAlquiler_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
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
             
                string matricula = DataBinder.Eval(e.Row.DataItem, "matriculaVehiculo").ToString();

              
                List<Vehiculo> listaVehiculos = BaseDeDatos.ObtenerDatosVehiculos();

          
                Vehiculo vehiculo = listaVehiculos.Find(v => v.matricula == matricula);

                Label lblEstado = e.Row.FindControl("lbl34") as Label;
                if (lblEstado != null)
                {
                    string estado = lblEstado.Text;

                   if (estado == "Atrasado")
                    {
                        

                        int columnIndex = GetColumnIndexByName(gvAlquiler, "Estado"); 

                        if (columnIndex >= 0)
                        {
                            e.Row.Cells[columnIndex].BackColor = ColorTranslator.FromHtml("#F6C095");
                            lblEstado.ForeColor = ColorTranslator.FromHtml("#C70039");                        }
                    }
                }

            }
            if (gvAlquiler.EditIndex != -1 && e.Row.RowType == DataControlRowType.DataRow)
            {
                
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                if (lnkDelete != null)
                {
                    lnkDelete.Enabled = false;
                    lnkDelete.CssClass = "btn btn-dark"; 
                }
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

        private void ActualizarListaVehiculos() 
        {
            var vehiculosDisponibles = BaseDeDatos.listaVehiculos.Where(v => v.disponible).ToList()
                    .Where(v => v.disponible)
                    .OrderBy(v => v.GetType().Name)  
                    .ThenBy(v => v.datosParaLista)  
                    .ToList();

            cboVehiculos.DataSource = vehiculosDisponibles;
            cboVehiculos.DataTextField = "datosParaListaAlq";
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
        private int GetColumnIndexByName(GridView grid, string columnName)
        {
            foreach (DataControlField field in grid.Columns)
            {
                if (field.HeaderText.Equals(columnName) || (field is BoundField && ((BoundField)field).DataField.Equals(columnName)))
                {
                    return grid.Columns.IndexOf(field);
                }
            }
            return -1;
        }
    }
}