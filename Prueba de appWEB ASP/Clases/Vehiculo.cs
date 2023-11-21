using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Vehiculo
    {
        protected string matricula; 
        protected string marca; 
        protected string modelo;
        protected int kilometros;
        protected int año;
        protected string color;
        protected int precioVenta;
        protected int precioAlquiler;

        public Vehiculo(string matricula, string marca, string modelo, int kilometros, int año, string color, int precioVenta, int precioAlquiler)
        {
            this.matricula = matricula;
            this.marca = marca;
            this.modelo = modelo;
            this.kilometros = kilometros;
            this.año = año;
            this.color = color;
            this.precioVenta = precioVenta;
            this.precioAlquiler = precioAlquiler;
        }
        public Vehiculo() { }
        public string getMatricula() { return this.matricula; }
        public string getMarca() { return this.marca; }
        public string getModelo() { return this.modelo; }
        public int getKilometros() { return this.kilometros; }
        public int getAño() { return this.año; }
        public string getColor() { return this.color; }
        public int getPrecioVenta() { return this.precioVenta; }
        public int getPrecioAlquiler() { return this.precioAlquiler; }
        public void setMatricula(string matricula) { this.matricula = matricula; }
        public void setMarca(string marca) {  this.marca = marca; }
        public void setModelo(string modelo) { this.modelo = modelo; }
        public void setKilometros (int kilometros) { this.kilometros = kilometros; }
        public void setAño(int año) { this.año = año; }
        public void setColor(string color) {  this.color = color; }
        public void setPrecioVenta(int precioVenta) { this.precioVenta = precioVenta; }
        public void setPrecioAlquiler(int precioAlquiler) { this.precioAlquiler = precioAlquiler; }

    }
}