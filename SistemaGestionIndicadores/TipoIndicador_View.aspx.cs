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
    public partial class TipoIndicador_View : System.Web.UI.Page
    {
        protected List<TipoIndicador> listaTipoIndicador = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            TipoIndicadorController objTipoIndicadorController = new TipoIndicadorController();
            listaTipoIndicador = objTipoIndicadorController.List();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            TipoIndicador objTipoIndicador = new TipoIndicador(nombre);
            TipoIndicadorController objTipoIndicadorController = new TipoIndicadorController(objTipoIndicador);
            objTipoIndicadorController.Create();
            Response.Redirect("/");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            TipoIndicador objTipoIndicador = new TipoIndicador(id);
            TipoIndicadorController objTipoIndicadorController = new TipoIndicadorController(objTipoIndicador);
            txtNombre.Text = objTipoIndicadorController.Search().Nombre;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            TipoIndicador objTipoIndicador = new TipoIndicador(id, nombre);
            TipoIndicadorController objTipoIndicadorController = new TipoIndicadorController(objTipoIndicador);
            objTipoIndicadorController.Update();
            Response.Redirect("/");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            TipoIndicador objTipoIndicador = new TipoIndicador(id);
            TipoIndicadorController objTipoIndicadorController = new TipoIndicadorController(objTipoIndicador);
            objTipoIndicadorController.Delete();
            Response.Redirect("/");
        }
    }
}