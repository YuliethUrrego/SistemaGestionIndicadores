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
    public partial class RepresenVisual_View : System.Web.UI.Page
    {
        protected List<RepresenVisual> listaRepresenVisual = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            RepresenVisualController objRepresenVisualController = new RepresenVisualController();
            listaRepresenVisual = objRepresenVisualController.List();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            RepresenVisual objRepresenVisual = new RepresenVisual(nombre);
            RepresenVisualController objRepresenVisualController = new RepresenVisualController(objRepresenVisual);
            objRepresenVisualController.Create();
            Response.Redirect("/");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            RepresenVisual objRepresenVisual = new RepresenVisual(id);
            RepresenVisualController objRepresenVisualController = new RepresenVisualController(objRepresenVisual);
            txtNombre.Text = objRepresenVisualController.Search().Nombre;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            RepresenVisual objRepresenVisual = new RepresenVisual(id, nombre);
            RepresenVisualController objRepresenVisualController = new RepresenVisualController(objRepresenVisual);
            objRepresenVisualController.Update();
            Response.Redirect("/");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            RepresenVisual objRepresenVisual = new RepresenVisual(id);
            RepresenVisualController objRepresenVisualController = new RepresenVisualController(objRepresenVisual);
            objRepresenVisualController.Delete();
            Response.Redirect("/");
        }
    }
}