using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Venta
    {
        public int numVenta { get; set; }
        public int totalVenta { get; set; }
        public DateTime fechaVenta { get; set; }
        public string documentoCliente { get; set; }    
        public string matriculaVehiculo { get; set; }
        public string username { get; set; }

        public Venta() { }
        public Venta(int numVenta, int totalVenta, DateTime fechaVenta, string documento,string matricula,string username)
        {
            this.numVenta = numVenta;
            this.totalVenta = totalVenta;
            this.fechaVenta = fechaVenta;
            this.documentoCliente = documento;
            this.matriculaVehiculo = matricula;
            this.username = username;
        }
        public int getNumVenta() {  return numVenta; }
        public int getTotalVenta() { return totalVenta; }
        public DateTime getFechaVenta() { return fechaVenta; }
        public string getDocumentoCliente() { return documentoCliente; }
        public string getMatricula() { return matriculaVehiculo; }
        public string getUsername() { return username; }

        public void setNumVenta (int numVenta) { this.numVenta =numVenta; }
        public void setTotalVenta (int totalVenta) { this.totalVenta=totalVenta; }
        public void setFechaVenta (DateTime fechaVenta) { this.fechaVenta=fechaVenta; }
        public void setDocumentoCliente(string documento) { this.documentoCliente = documento; }
        public void setMatricula(string matricula) { this.matriculaVehiculo = matricula; }
        public void setUsername(string username) { this.username = username; }
    }
}