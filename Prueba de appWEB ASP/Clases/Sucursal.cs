using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Sucursal
    {
        public string nombreSucursal { get; set; }
        public string direccionSucursal { get; set; }
        public List<Cliente> listaClientes { get; set; }
        public List<Vehiculo> listaVehiculos { get; set; }
        public List<Alquiler> listaVehiculosAlquilados { get; set; }
        public List<Venta> listaVehiculosVendidos { get; set; }
        public List<Usuario> listaUsuarios { get; set; }
        public Sucursal() { }
        public Sucursal(string nombreSucursal, string direccionSucursal, List<Cliente> clientes, List<Vehiculo> vehiculos, List<Alquiler> alquileres, List<Venta> ventas, List<Usuario> usuarios)
        {
            this.nombreSucursal = nombreSucursal;
            this.direccionSucursal = direccionSucursal;
            this.listaClientes = clientes;
            this.listaVehiculos = vehiculos;
            this.listaVehiculosAlquilados = alquileres;
            this.listaVehiculosVendidos = ventas;
            this.listaUsuarios = usuarios;
        }
        public string getNombreSucursal() { return nombreSucursal; }
        public string getDireccionSucursal() { return direccionSucursal; }
        public List<Cliente> getListaClientes() { return listaClientes; }
        public List<Vehiculo> getListaVehiculos() { return listaVehiculos; }
        public List<Alquiler> getListaVehiculosAlquilados() { return listaVehiculosAlquilados; }
        public List<Venta> getListaVehiculosVendidos() { return listaVehiculosVendidos; }
        public List<Usuario> getListaUsuarios() { return listaUsuarios; }
        public void setNombreSucursal(string nombreSucursal) { this.nombreSucursal = nombreSucursal; }
        public void setDireccionSucursal(string direccionSucursal) { this.direccionSucursal = direccionSucursal; }
        public void setListaClientes(List<Cliente> clientes) { this.listaClientes = clientes; }
        public void setListaVehiculos(List<Vehiculo> vehiculos) { this.listaVehiculos = vehiculos; }
        public void setListaVehiculosAlquilados(List<Alquiler> alquileres) { this.listaVehiculosAlquilados = alquileres; }
        public void setListaVehiculosVendidos(List<Venta> ventas) { this.listaVehiculosVendidos = ventas; }
        public void setListaUsuarios(List<Usuario> usuarios) { this.listaUsuarios = usuarios; }

    }
}