using System;

namespace Pizzas.API.Models
{
    public class Pizza
    {
        public int      Id              { get; set; }
        public string   Nombre          { get; set; }
        public bool     LibreGluten     { get; set; }
        public float    Importe         { get; set; }
        public string   Descripcion     { get; set; }
    }

    public Pizza(int Id ,string Nombre, bool LibreGluten, float Importe, string Descripcion){
            _IdPizza=Id;
            _nombre=Nombre;
            _LibreGluten=LibreGluten;
            _Importe=Importe;
            _descripcion=Descripcion;
        }

}
