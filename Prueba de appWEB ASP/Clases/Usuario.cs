using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string username { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string password { get; set; }
        public bool verClientes { get; set; }
        public bool verUsuarios { get; set; }
        public bool verVentas { get; set; }
        public bool verVehiculos { get; set; }
        public bool verAlquileres { get; set; }

        public Usuario() { }
        public Usuario(int idUsuario, string username, string nombreUsuario, string apellidoUsuario, string password, bool verClientes, bool verUsuarios, bool verVentas, bool verVehiculos, bool verAlquileres)
        {
            this.idUsuario = idUsuario;
            this.username = username;
            this.nombreUsuario = nombreUsuario;
            this.apellidoUsuario = apellidoUsuario;
            this.password = password;
            this.verClientes = verClientes;
            this.verUsuarios = verUsuarios;
            this.verVentas = verVentas;
            this.verVehiculos = verVehiculos;
            this.verAlquileres = verAlquileres;
        }

        public int getIdUsuario() { return idUsuario; }
        public string getUsername() { return username; }
        public string getNombreUsuario() { return nombreUsuario; }
        public string getApellidoUsuario() { return apellidoUsuario; }
        public string getPassword() { return password; } 
        public bool getVerClientes() { return verClientes; }
        public bool getVerUsuarios() { return verUsuarios; }
        public bool getVerVentas() { return verVentas; }
        public bool getVerVehiculos() { return verVehiculos; }
        public bool getVerAlquileres() { return verAlquileres; }

        public void setIdUsuario(int idUsuario) { this.idUsuario = idUsuario; }
        public void setUsername(string username) { this.username = username; }
        public void setNombreUsuario(string nombreUsuario) { this.nombreUsuario = nombreUsuario; }
        public void setApellidoUsuario(string apellidoUsuario) { this.apellidoUsuario = apellidoUsuario; }
        public void setPassword(string password) { this.password = password; }
        public void setVerClientes(bool verClientes) { this.verClientes = verClientes; }
        public void setVerUsuarios(bool verUsuarios) { this.verUsuarios = verUsuarios; }
        public void setVerVentas(bool verVentas) { this.verVentas = verVentas; }
        public void setVerVehiculos(bool verVehiculos) { this.verVehiculos = verVehiculos; }
        public void setVerAlquileres(bool verAlquileres) { this.verAlquileres = verAlquileres; }
    }
}