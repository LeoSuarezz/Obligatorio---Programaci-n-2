using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Moto : Vehiculo
    {
        private int cilindrada;
        public Moto() { }
        public Moto(string matricula, string marca, string modelo, int kilometros, int año, string color, int precioVenta, int precioAlquiler, int cilindrada) :
            base(matricula, marca, modelo, kilometros, año, color, precioVenta, cilindrada)
        {
            this.cilindrada = cilindrada;
        } 
        public int getCilindrada() { return cilindrada; }
        public void setCilindrada(int cilindrada) { this.cilindrada = cilindrada; }
    }
}