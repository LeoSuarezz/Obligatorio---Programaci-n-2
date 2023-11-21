using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Camion : Vehiculo
    {
        private int capacidadCarga;
        public Camion() { }
        public Camion(string matricula, string marca, string modelo, int kilometros, int año, string color, int precioVenta, int precioAlquiler, int capacidadCarga) :
            base(matricula, marca, modelo, kilometros, año, color, precioVenta,capacidadCarga)
        {
            this.capacidadCarga = capacidadCarga;
        }
        public int getCapacidadCarga() { return capacidadCarga; }
        public void setCapacidadCarga(int capacidadCarga) { this.capacidadCarga = capacidadCarga; }
    }
}