using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Alquiler
    {
        public int numAlquiler { get; set; }
        public int precioTotal { get; set; }
        public DateTime fechaInicio { get; set; }
        public int cantidadDias { get; set; }
        
        public bool autoDevuelto { get; set; }
        public string estado
        {
            get
            {
                if (!autoDevuelto && DateTime.Now > fechaInicio.AddDays(cantidadDias))
                {
                    return "Atrasado";
                }
                else if (!autoDevuelto)
                {
                    return "Al día";
                }
                else
                {
                    return "Vehículo devuelto";
                }
            }
        }
        public string documentoCliente { get; set; }
        public string matriculaVehiculo { get; set; }
        public string username { get; set; }
        public Alquiler() { }
        public Alquiler(int numAlquiler, int precioTotal, DateTime fechaInicio, int cantidadDias, bool autoDevuelto, string documentoCliente, string matriculaVehiculo, string username)
        {
            this.numAlquiler = numAlquiler;
            this.precioTotal = precioTotal;
            this.fechaInicio = fechaInicio;
            this.cantidadDias = cantidadDias;
            this.autoDevuelto = autoDevuelto;
            this.documentoCliente = documentoCliente;
            this.matriculaVehiculo = matriculaVehiculo;
            this.username = username;
        }
        public int getNumAlquiler() { return numAlquiler; }
        public int getPrecioTotal() { return precioTotal; }
        public DateTime getFechaInicio() { return fechaInicio; }
        public int getCantidadDias() { return cantidadDias; }
        public bool getAutoDevuelto() { return autoDevuelto; }
        public string getDocumentoCliente() { return documentoCliente; }
        public string getMatricula() { return matriculaVehiculo; }
        public string getUsername() { return username; }

        public void setNumAlquiler(int numAlquiler) { this.numAlquiler = numAlquiler; }
        public void setPrecioTotal(int precioTotal) { this.precioTotal = precioTotal; }
        public void setFechaInicio(DateTime fechaInicio) { this.fechaInicio = fechaInicio; }
        public void setCantidadDias(int cantidadDias) { this.cantidadDias = cantidadDias; }
        public void setEstadoAlquiler(bool autoDevuelto) { this.autoDevuelto = autoDevuelto; }
        public void setDocumentoCliente(string documentoCliente) { this.documentoCliente = documentoCliente; }
        public void setMatricula(string matricula) { this.matriculaVehiculo = matricula; }
        public void setUsername(string username) { this.username = username; }

    }
}