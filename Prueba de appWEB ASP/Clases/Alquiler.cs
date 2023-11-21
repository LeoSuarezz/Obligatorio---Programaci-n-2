using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Alquiler
    {
        private int numAlquiler;
        private int precioTotal;
        private DateTime fechaInicio;
        private int cantidadDias;
        private bool estadoAlquiler;
        private Cliente cliente;
        private List<Vehiculo> listaVehiculosAlquilados;

        public Alquiler() { }
        public Alquiler(int numAlquiler, int precioTotal, DateTime fechaInicio, int cantidadDias, bool estadoAlquiler, Cliente cliente, List<Vehiculo> listaVehiculos)
        {
            this.numAlquiler = numAlquiler;
            this.precioTotal = precioTotal;
            this.fechaInicio = fechaInicio;
            this.cantidadDias = cantidadDias;
            this.estadoAlquiler = estadoAlquiler;
            this.cliente = cliente;
            this.listaVehiculosAlquilados = listaVehiculos;
        }
        public int getNumAlquiler() { return numAlquiler; }
        public int getPrecioTotal() { return precioTotal; }
        public DateTime getFechaInicio() { return fechaInicio; }
        public int getCantidadDias() { return cantidadDias; }
        public bool getEstadoAlquiler() { return estadoAlquiler; }
        public Cliente getCliente() { return cliente; }
        public List<Vehiculo> getListaVehiculos() { return listaVehiculosAlquilados; }

        public void setNumAlquiler(int numAlquiler) { this.numAlquiler = numAlquiler; }
        public void setPrecioTotal(int precioTotal) { this.precioTotal = precioTotal; }
        public void setFechaInicio(DateTime fechaInicio) { this.fechaInicio = fechaInicio; }
        public void setCantidadDias(int cantidadDias) { this.cantidadDias = cantidadDias; }
        public void setEstadoAlquiler(bool estadoAlquiler) { this.estadoAlquiler = estadoAlquiler; }
        public void setCliente(Cliente cliente) { this.cliente = cliente; }
        public void setListaVehiculos(List<Vehiculo> listaVehiculos) { this.listaVehiculosAlquilados = listaVehiculos; }

    }
}