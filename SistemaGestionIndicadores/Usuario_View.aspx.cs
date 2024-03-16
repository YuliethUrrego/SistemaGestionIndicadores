using SistemaGestionIndicadores.Controllers;
using SistemaGestionIndicadores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaGestionIndicadores
{
    public partial class Usuario_Vista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Ingresar_Click(object sender, EventArgs e)
        {
            //string email = "PruebaYu";
            //string contrasena = "123";
            //Usuario objUsuario = new Usuario(email, contrasena);
            //UsuarioController objUsuarioController = new UsuarioController(objUsuario);
            //objUsuarioController.Create();

            TipoIndicadorController tipoIndicadorController = new TipoIndicadorController(new TipoIndicador(5, "Eficiencia"));
            //tipoIndicadorController.Create();

            //tipoIndicadorController.Update();

            //tipoIndicadorController.Delete();

            List<TipoIndicador> tiposIndicadores = tipoIndicadorController.List();
            foreach (TipoIndicador tipoIndicador in tiposIndicadores)
            {
                Response.Write($" ID: {tipoIndicador.Id}, Nombre: {tipoIndicador.Nombre}");
            }
            TipoIndicador tipoIndicadorSearch = tipoIndicadorController.Search();
            Response.Write($" busqueda: ID: {tipoIndicadorSearch.Id}, Nombre: {tipoIndicadorSearch.Nombre}");


        }
    }
}