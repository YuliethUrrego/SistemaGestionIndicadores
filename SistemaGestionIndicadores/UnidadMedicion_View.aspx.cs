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
    public partial class UnidadMedicion_View : System.Web.UI.Page
    {
        protected List<UnidadMedicion> listaUnidadMedicion = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            UnidadMedicionController objUnidadMedicionController = new UnidadMedicionController();
            listaUnidadMedicion = objUnidadMedicionController.List();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text;
            UnidadMedicion objUnidadMedicion = new UnidadMedicion(descripcion);
            UnidadMedicionController objUnidadMedicionController = new UnidadMedicionController(objUnidadMedicion);
            objUnidadMedicionController.Create();
            Response.Redirect("UnidadMedicion_View.aspx");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            UnidadMedicion objUnidadMedicion = new UnidadMedicion(id);
            UnidadMedicionController objUnidadMedicionController = new UnidadMedicionController(objUnidadMedicion);
            txtDescripcion.Text = objUnidadMedicionController.Search().Descripcion;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string descripcion = txtDescripcion.Text;
            UnidadMedicion objUnidadMedicion = new UnidadMedicion(id, descripcion);
            UnidadMedicionController objUnidadMedicionController = new UnidadMedicionController(objUnidadMedicion);
            objUnidadMedicionController.Update();
            Response.Redirect("UnidadMedicion_View.aspx");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            UnidadMedicion objUnidadMedicion = new UnidadMedicion(id);
            UnidadMedicionController objUnidadMedicionController = new UnidadMedicionController(objUnidadMedicion);
            objUnidadMedicionController.Delete();
            Response.Redirect("UnidadMedicion_View.aspx");
        }
    }
}