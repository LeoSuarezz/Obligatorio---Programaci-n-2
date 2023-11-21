using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Cliente
    {
        private int documentoCliente;
        private string nombreCliente;
        private string apellidoCliente;
        private int edadCliente;
        private string direccionCliente;
        private string telefonoCliente;
        public Cliente () { }
        public Cliente(int documento, string nombreCliente, string apellidoCliente, int edadCliente, string direccionCliente, string telefonoCliente)
        {
            this.documentoCliente = documento;
            this.nombreCliente = nombreCliente;
            this.apellidoCliente = apellidoCliente;
            this.edadCliente = edadCliente;
            this.direccionCliente = direccionCliente;
            this.telefonoCliente = telefonoCliente;
        }
        public int getDocumentoCliente() { return documentoCliente; }
        public string getNombreCliente() { return nombreCliente; }
        public string getApellidoCliente() { return apellidoCliente; }
        public int getEdadCliente() { return edadCliente; }
        public string getDireccionCliente() { return direccionCliente; }
        public string getTelefonoCliente() { return telefonoCliente; }
        public void setDocumentoCliente(int documento) { this.documentoCliente=documento; }
        public void setNombreCliente(string nombreCliente) { this.nombreCliente = nombreCliente; }
        public void setApellidoCliente(string apellidoCliente) { this.apellidoCliente = apellidoCliente; }
        public void setEdadCliente (int edad) { this.edadCliente = edad; }
        public void setDireccionCliente (string direccion) { this.direccionCliente =direccion; }
        public void setTelefonoCliente (string telefono) { this.telefonoCliente = telefono; }

    }
}