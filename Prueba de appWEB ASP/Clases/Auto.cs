using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Auto : Vehiculo
    {
        public int numPasajeros { get; set; }
        public Auto() { }
        public Auto(bool disponible, string matricula, string marca, string modelo, int kilometros, DateTime anio, string color, int precioVenta, int precioAlquiler, string imagen1, string imagen2, string imagen3, int numPasajeros) :
            base(disponible, matricula, marca, modelo, kilometros, anio, color, precioVenta, precioAlquiler, imagen1, imagen2, imagen3)
        {
            this.numPasajeros = numPasajeros;
        }
        public int getNumPasajeros() { return numPasajeros; }
        public void setNumPasajeros(int numPasajeros) { this.numPasajeros = numPasajeros; }
    }
}