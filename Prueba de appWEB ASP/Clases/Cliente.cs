using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Cliente
    {
        public string documentoCliente { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
        public string direccionCliente { get; set; }
        public string telefonoCliente { get; set; }

        public string datosCliente
        {
            get { return $"Documento: {documentoCliente} - Nombre y Apellido: {nombreCliente} {apellidoCliente} - Teléfono: {telefonoCliente}"; }
        }

        public Cliente() { } 
        public Cliente(string documento, string nombreCliente, string apellidoCliente, string direccionCliente, string telefonoCliente)
        {
            this.documentoCliente = documento;
            this.nombreCliente = nombreCliente;
            this.apellidoCliente = apellidoCliente;
            this.direccionCliente = direccionCliente;
            this.telefonoCliente = telefonoCliente;
        }

        public string getDocumentoCliente() { return documentoCliente; }
        public string getNombreCliente() { return nombreCliente; }
        public string getApellidoCliente() { return apellidoCliente; }
        public string getDireccionCliente() { return direccionCliente; }
        public string getTelefonoCliente() { return telefonoCliente; }
        public void setDocumentoCliente(string documento) { this.documentoCliente=documento; }
        public void setNombreCliente(string nombreCliente) { this.nombreCliente = nombreCliente; }
        public void setApellidoCliente(string apellidoCliente) { this.apellidoCliente = apellidoCliente; }
        public void setDireccionCliente (string direccion) { this.direccionCliente =direccion; }
        public void setTelefonoCliente (string telefono) { this.telefonoCliente = telefono; }
    }
}