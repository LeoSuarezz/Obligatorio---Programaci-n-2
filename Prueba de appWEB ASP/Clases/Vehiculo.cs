using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_de_appWEB_ASP.Clases
{
    public class Vehiculo
    {
        public bool disponible { get; set; }
        public string matricula { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int kilometros { get; set; }
        public DateTime anio { get; set; }
        public string color { get; set; }
        public int precioVenta { get; set; }
        public int precioAlquiler { get; set; }
        public string imagen1 { get; set; }
        public string imagen2 { get; set; }
        public string imagen3 { get; set; }

        public string datosParaLista 
        {
            get { return $"{this.GetType().Name} - Matrícula: {matricula} - Marca: {marca} - Año: {anio.Year} - Precio: ${precioVenta}"; }
        }

        public string datosParaListaAlq
        {
            get { return $"{this.GetType().Name} - Matrícula: {matricula} - Marca: {marca} - Año: {anio.Year} - Precio diario: ${precioAlquiler}"; }
        }

        public Vehiculo(bool disponible, string matricula, string marca, string modelo, int kilometros, DateTime anio,
            string color, int precioVenta, int precioAlquiler, string imagen1, string imagen2, string imagen3)
        {
            this.disponible = disponible;
            this.matricula = matricula;
            this.marca = marca;
            this.modelo = modelo;
            this.kilometros = kilometros;
            this.anio = anio;
            this.color = color;
            this.precioVenta = precioVenta;
            this.precioAlquiler = precioAlquiler;
            this.imagen1 = imagen1;
            this.imagen2 = imagen2;
            this.imagen3 = imagen3;
        }
        public Vehiculo() { }
        public bool getDisponible() { return this.disponible; } 
        public string getMatricula() { return this.matricula; }
        public string getMarca() { return this.marca; }
        public string getModelo() { return this.modelo; }
        public int getKilometros() { return this.kilometros; }
        public DateTime getAnio() { return this.anio; }
        public string getColor() { return this.color; }
        public int getPrecioVenta() { return this.precioVenta; }
        public int getPrecioAlquiler() { return this.precioAlquiler; }
        public string getImagen1() { return this.imagen1; }
        public string getImagen2() { return this.imagen2; }
        public string getImagen3() { return this.imagen3; }

        public void setDisponible(bool disponible) { this.disponible = disponible; }
        public void setMatricula(string matricula) { this.matricula = matricula; }
        public void setMarca(string marca) {  this.marca = marca; }
        public void setModelo(string modelo) { this.modelo = modelo; }
        public void setKilometros (int kilometros) { this.kilometros = kilometros; }
        public void setAnio(DateTime anio) { this.anio = anio; }
        public void setColor(string color) {  this.color = color; }
        public void setPrecioVenta(int precioVenta) { this.precioVenta = precioVenta; }
        public void setPrecioAlquiler(int precioAlquiler) { this.precioAlquiler = precioAlquiler; }
        public void setImagen1(string imagen1) { this.imagen1 = imagen1; }
        public void setImagen2(string imagen2) { this.imagen2 = imagen2; }
        public void setImagen3(string imagen3) { this.imagen3 = imagen3; }


    }
}