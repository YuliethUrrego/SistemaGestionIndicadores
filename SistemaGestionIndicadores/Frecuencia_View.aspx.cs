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
    public partial class Frecuencia_View : System.Web.UI.Page
    {
        protected List<Frecuencia> listaFrecuencias = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            FrecuenciaController objFrecuenciaController = new FrecuenciaController();
            listaFrecuencias = objFrecuenciaController.List();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            Frecuencia objFrecuencia = new Frecuencia(nombre);
            FrecuenciaController objFrecuenciaController = new FrecuenciaController(objFrecuencia);
            objFrecuenciaController.Create();
            Response.Redirect("/");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Frecuencia objFrecuencia = new Frecuencia(id);
            FrecuenciaController objFrecuenciaController = new FrecuenciaController(objFrecuencia);
            txtNombre.Text = objFrecuenciaController.Search().Nombre;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            Frecuencia objFrecuencia = new Frecuencia(id, nombre);
            FrecuenciaController objFrecuenciaController = new FrecuenciaController(objFrecuencia);
            objFrecuenciaController.Update();
            Response.Redirect("/");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Frecuencia objFrecuencia = new Frecuencia(id);
            FrecuenciaController objFrecuenciaController = new FrecuenciaController(objFrecuencia);
            objFrecuenciaController.Delete();
            Response.Redirect("/");
        }
    }
}