using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Camion : Vehiculo
    {
        public int capacidadCarga { get; set; }
        public Camion() { }
        public Camion(bool disponible, string matricula, string marca, string modelo, int kilometros, DateTime anio, string color, int precioVenta, int precioAlquiler, string imagen1, string imagen2, string imagen3, int capacidadCarga) :
            base(disponible, matricula, marca, modelo, kilometros, anio, color, precioVenta, precioAlquiler, imagen1, imagen2, imagen3)
        {
            this.capacidadCarga = capacidadCarga;
        }
        public int getCapacidadCarga() { return capacidadCarga; }
        public void setCapacidadCarga(int capacidadCarga) { this.capacidadCarga = capacidadCarga; }
    }
}