using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SistemaGestionIndicadores.Models
{
    public class Fuente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Fuente(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public Fuente(int id)
        {
            Id = id;
        }
        public Fuente(string nombre)
        {
            Nombre = nombre;
        }

        public Fuente()
        {
        }
    }
}