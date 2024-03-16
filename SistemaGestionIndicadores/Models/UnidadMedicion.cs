using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SistemaGestionIndicadores.Models
{
    public class UnidadMedicion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public UnidadMedicion(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
        public UnidadMedicion(int id)
        {
            Id = id;
        }
        public UnidadMedicion(string descripcion)
        {
            Descripcion = descripcion;
        }
        public UnidadMedicion()
        {
        }
    }
}