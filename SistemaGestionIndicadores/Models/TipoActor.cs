using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SistemaGestionIndicadores.Models
{
    public class TipoActor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public TipoActor(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        public TipoActor(int id)
        {
            Id = id;
        }
        public TipoActor(string nombre)
        {
            Nombre = nombre;
        }
        public TipoActor()
        {
        }
    }
}