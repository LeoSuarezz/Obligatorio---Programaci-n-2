using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Venta
    {
        private int numVenta;
        private int totalVenta;
        private DateTime fechaVenta;
        private Cliente cliente;
        private List<Vehiculo> listaVehiculosVendidos;
        public Venta() { }
        public Venta(int numVenta, int totalVenta, DateTime fechaVenta, Cliente cliente,List<Vehiculo> listaVehiculos)
        {
            this.numVenta = numVenta;
            this.totalVenta = totalVenta;
            this.fechaVenta = fechaVenta;
            this.cliente = cliente;
            this.listaVehiculosVendidos = listaVehiculos;
        }
        public int getNumVenta() {  return numVenta; }
        public int getTotalVenta() { return totalVenta; }
        public DateTime getFechaVenta() { return fechaVenta; }
        public Cliente getCliente() {  return cliente; }
        public List<Vehiculo> getListaVehiculos() { return listaVehiculosVendidos; }
        public void setNumVenta (int numVenta) { this.numVenta =numVenta; }
        public void setTotalVenta (int totalVenta) { this.totalVenta=totalVenta; }
        public void setFechaVenta (DateTime fechaVenta) { this.fechaVenta=fechaVenta; }
        public void setCliente(Cliente cliente) { this.cliente = cliente;}
        public void setListaVehiculosVendidos(List<Vehiculo> listaVehiculosVendidos) { this.listaVehiculosVendidos = listaVehiculosVendidos; }
    }
}