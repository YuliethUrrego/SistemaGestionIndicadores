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
    public partial class TipoActor_View : System.Web.UI.Page
    {
        protected List<TipoActor> listaTipoActor = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            TipoActorController objTipoActorController = new TipoActorController();
            listaTipoActor = objTipoActorController.List();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            TipoActor objTipoActor = new TipoActor(nombre);
            TipoActorController objTipoActorController = new TipoActorController(objTipoActor);
            objTipoActorController.Create();
            Response.Redirect("/");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            TipoActor objTipoActor = new TipoActor(id);
            TipoActorController objTipoActorController = new TipoActorController(objTipoActor);
            txtNombre.Text = objTipoActorController.Search().Nombre;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            TipoActor objTipoActor = new TipoActor(id, nombre);
            TipoActorController objTipoActorController = new TipoActorController(objTipoActor);
            objTipoActorController.Update();
            Response.Redirect("/");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            TipoActor objTipoActor = new TipoActor(id);
            TipoActorController objTipoActorController = new TipoActorController(objTipoActor);
            objTipoActorController.Delete();
            Response.Redirect("/");
        }
    }
}