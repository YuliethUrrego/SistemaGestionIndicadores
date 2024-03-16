using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SistemaGestionIndicadores.Models
{
    public class RepresenVisual
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public RepresenVisual(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public RepresenVisual(int id)
        {
            Id = id;
        }
        public RepresenVisual(string nombre)
        {
            Nombre = nombre;
        }

        public RepresenVisual()
        {
        }
    }
}