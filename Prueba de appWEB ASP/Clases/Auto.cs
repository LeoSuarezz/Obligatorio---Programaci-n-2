using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Auto : Vehiculo
    {
        private int numPasajeros;
        public Auto() { }
        public Auto(string matricula, string marca, string modelo, int kilometros, int año, string color, int precioVenta, int precioAlquiler, int numPasajeros) :
            base(matricula, marca, modelo, kilometros, año, color, precioVenta,precioAlquiler)
        {
            this.numPasajeros = numPasajeros;
        }
        public int getNumPasajeros() { return numPasajeros; }
        public void setNumPasajeros(int numPasajeros) { this.numPasajeros = numPasajeros; }
    }
}