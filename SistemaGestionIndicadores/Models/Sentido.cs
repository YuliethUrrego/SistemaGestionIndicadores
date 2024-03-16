using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SistemaGestionIndicadores.Models
{
    public class Sentido
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Sentido(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public Sentido(int id)
        {
            Id = id;
        }
        public Sentido(string nombre)
        {
            Nombre = nombre;
        }

        public Sentido()
        {
        }
    }
}