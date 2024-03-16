using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGestionIndicadores.Models
{
    public class Frecuencia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Frecuencia(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public Frecuencia(int id)
        {
            Id = id;
        }
        public Frecuencia(string nombre)
        {
            Nombre = nombre;
        }

        public Frecuencia()
        {
        }
    }
}