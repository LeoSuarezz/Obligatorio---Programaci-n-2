using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Moto : Vehiculo
    {
        public int cilindrada { get; set; }
        public Moto() { }
        public Moto(bool disponible, string matricula, string marca, string modelo, int kilometros, DateTime anio, string color, int precioVenta, int precioAlquiler, string imagen1, string imagen2, string imagen3, int cilindrada) :
            base(disponible, matricula, marca, modelo, kilometros, anio, color, precioVenta, precioAlquiler, imagen1, imagen2, imagen3)
        {
            this.cilindrada = cilindrada;
        }
        public int getCilindrada() { return cilindrada; }
        public void setCilindrada(int cilindrada) { this.cilindrada = cilindrada; }
    }
}