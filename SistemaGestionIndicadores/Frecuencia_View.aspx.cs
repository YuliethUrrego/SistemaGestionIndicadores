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
    }
}