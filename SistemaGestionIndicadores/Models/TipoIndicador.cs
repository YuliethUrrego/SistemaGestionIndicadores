using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SistemaGestionIndicadores.Models
{
    public class TipoIndicador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public TipoIndicador(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        public TipoIndicador(int id)
        {
            Id = id;
        }

        public TipoIndicador(string nombre)
        {
            Nombre = nombre;
        }

        public TipoIndicador()
        {
        }
    }
}