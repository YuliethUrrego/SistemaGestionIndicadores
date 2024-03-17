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
    public partial class Fuente_View : System.Web.UI.Page
    {
        protected List<Fuente> listaFuente = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            FuenteController objFuenteController = new FuenteController();
            listaFuente = objFuenteController.List();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            Fuente objFuente = new Fuente(nombre);
            FuenteController objFuenteController = new FuenteController(objFuente);
            objFuenteController.Create();
            Response.Redirect("/");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Fuente objFuente = new Fuente(id);
            FuenteController objFuenteController = new FuenteController(objFuente);
            txtNombre.Text = objFuenteController.Search().Nombre;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            Fuente objFuente = new Fuente(id, nombre);
            FuenteController objFuenteController = new FuenteController(objFuente);
            objFuenteController.Update();
            Response.Redirect("/");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Fuente objFuente = new Fuente(id);
            FuenteController objFuenteController = new FuenteController(objFuente);
            objFuenteController.Delete();
            Response.Redirect("/");
        }

    }
}