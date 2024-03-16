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
    public partial class Sentido_View : System.Web.UI.Page
    {
        protected List<Sentido> listaSentido = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            SentidoController objSentidoController = new SentidoController();
            listaSentido = objSentidoController.List();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            Sentido objSentido = new Sentido(nombre);
            SentidoController objSentidoController = new SentidoController(objSentido);
            objSentidoController.Create();
            Response.Redirect("Sentido_View.aspx");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Sentido objSentido = new Sentido(id);
            SentidoController objSentidoController = new SentidoController(objSentido);
            txtNombre.Text = objSentidoController.Search().Nombre;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            Sentido objSentido = new Sentido(id, nombre);
            SentidoController objSentidoController = new SentidoController(objSentido);
            objSentidoController.Update();
            Response.Redirect("Sentido_View.aspx");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Sentido objSentido = new Sentido(id);
            SentidoController objSentidoController = new SentidoController(objSentido);
            objSentidoController.Delete();
            Response.Redirect("Sentido_View.aspx");
        }
    }
}