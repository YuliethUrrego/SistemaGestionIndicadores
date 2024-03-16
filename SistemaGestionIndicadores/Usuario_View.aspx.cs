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
        protected Usuario[] arrayUsuario=null;

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioController objUsuarioController = new UsuarioController();
            arrayUsuario = objUsuarioController.List();

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string contrasena = txtContrasena.Text;
            Usuario objUsuario = new Usuario(email, contrasena);
            UsuarioController objControlUsuario = new UsuarioController(objUsuario);
            objControlUsuario.Create();
            Response.Redirect("FrmUsuario.aspx");
        }



        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string contrasena = txtContrasena.Text;
            Usuario objUsuario = new Usuario(email, contrasena);
            UsuarioController objControlUsuario = new UsuarioController(objUsuario);
            objControlUsuario.Update();
            Response.Redirect("FrmUsuario.aspx");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            Usuario objUsuario = new Usuario(email, "");
            UsuarioController objControlUsuario = new UsuarioController(objUsuario);
            objControlUsuario.Delete();
            Response.Redirect("FrmUsuario.aspx");
        }


        protected void Ingresar_Click(object sender, EventArgs e)
        {





            /*** PRUEBA TIPO INDICADOR***/
            //TipoIndicadorController tipoIndicadorController = new TipoIndicadorController(new TipoIndicador(5, "Eficiencia"));
            //tipoIndicadorController.Create();

            //tipoIndicadorController.Update();

            //tipoIndicadorController.Delete();

            //List<TipoIndicador> tiposIndicadores = tipoIndicadorController.List();
            //foreach (TipoIndicador tipoIndicador in tiposIndicadores)
            //{
            //    Response.Write($" ID: {tipoIndicador.Id}, Nombre: {tipoIndicador.Nombre}");
            //}
            //TipoIndicador tipoIndicadorSearch = tipoIndicadorController.Search();
            //Response.Write($" busqueda: ID: {tipoIndicadorSearch.Id}, Nombre: {tipoIndicadorSearch.Nombre}");

            /*** PRUEBA FUENTE***/

            //FuenteController fuenteController = new FuenteController(new Fuente("Nueva Fuente"));
            //fuenteController.Create();

            //Fuente fuenteExistente = new Fuente { Id = 1, Nombre = "Fuente Actualizada" };
            //FuenteController fuenteController2 = new FuenteController(new Fuente(1, "Cambio nombre"));
            //fuenteController2.Update();

            //FuenteController fuenteController3 = new FuenteController(new Fuente(2));
            //fuenteController3.Delete();

            //FuenteController fuenteController4 = new FuenteController();
            //List<Fuente> listaFuentes = fuenteController4.List();
            //foreach (Fuente fuente in listaFuentes)
            //{
            //    Response.Write($"ID: {fuente.Id}, Nombre: {fuente.Nombre}");
            //}

            //FuenteController fuenteController5 = new FuenteController(new Fuente(4));
            //Fuente fuenteEncontrada = fuenteController5.Search();
            //if (fuenteEncontrada != null)
            //{
            //    Response.Write($"ID: {fuenteEncontrada.Id}, Nombre: {fuenteEncontrada.Nombre}");
            //}
            //else
            //{
            //    Response.Write("Fuente no encontrada.");
            //}

            /*** PRUEBA REPRESENTACION VISUAL ***/

            //// Caso de prueba 1: Crear una nueva representación visual
            //RepresenVisualController represenVisualController1 = new RepresenVisualController(new RepresenVisual("Nueva Representación Visual"));
            //represenVisualController1.Create();

            //// Caso de prueba 2: Actualizar una representación visual existente
            //RepresenVisualController represenVisualController2 = new RepresenVisualController(new RepresenVisual(5, "Representación Visual Actualizada"));
            //represenVisualController2.Update();

            // Caso de prueba 3: Eliminar una representación visual existente siempre y cuando no sea fk de otro registro
            //RepresenVisualController represenVisualController3 = new RepresenVisualController(new RepresenVisual(5));
            //represenVisualController3.Delete();

            //// Caso de prueba 4: Listar todas las representaciones visuales
            //RepresenVisualController represenVisualController4 = new RepresenVisualController();
            //List<RepresenVisual> listaRepresenVisual = represenVisualController4.List();
            //foreach (RepresenVisual represenVisual in listaRepresenVisual)
            //{
            //    Response.Write($"ID: {represenVisual.Id}, Nombre: {represenVisual.Nombre}");
            //}

            //// Caso de prueba 5: Buscar una representación visual por su ID
            //RepresenVisualController represenVisualController5 = new RepresenVisualController(new RepresenVisual(2));
            //RepresenVisual represenVisualEncontrada = represenVisualController5.Search();
            //if (represenVisualEncontrada != null)
            //{
            //    Response.Write($"ID: {represenVisualEncontrada.Id}, Nombre: {represenVisualEncontrada.Nombre}");
            //}
            //else
            //{
            //    Response.Write("Representación visual no encontrada.");
            //}

            /*** PRUEBA FRECUENCIA***/

            //FrecuenciaController frecuenciaController = new FrecuenciaController(new Frecuencia("Nueva frecuencia"));
            //frecuenciaController.Create();


            //FrecuenciaController frecuenciaController2 = new FrecuenciaController(new Frecuencia(3, "Frecuencia actualizada"));
            //frecuenciaController2.Update();

            //FrecuenciaController frecuenciaController3 = new FrecuenciaController(new Frecuencia(3));
            //frecuenciaController3.Delete();

            //FrecuenciaController frecuenciaController4 = new FrecuenciaController();
            //List<Frecuencia> listaFuentes = frecuenciaController4.List();
            //foreach (Frecuencia fuente in listaFuentes)
            //{
            //    Response.Write($"ID: {fuente.Id}, Nombre: {fuente.Nombre}");
            //}

            //FrecuenciaController frecuenciaController5 = new FrecuenciaController(new Frecuencia(4));
            //Frecuencia fuenteEncontrada = frecuenciaController5.Search();
            //if (fuenteEncontrada != null)
            //{
            //    Response.Write($"ID: {fuenteEncontrada.Id}, Nombre: {fuenteEncontrada.Nombre}");
            //}
            //else
            //{
            //    Response.Write("Fuente no encontrada.");
            //}


        }
    }
}