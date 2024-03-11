using SistemaGestionIndicadores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGestionIndicadores.Controllers
{
    public class UsuarioController
    {
        Usuario objUsuario = new Usuario();

        public UsuarioController(Usuario objUsuario)
        {
            this.objUsuario = objUsuario;
        }

        public UsuarioController()
        {
            this.objUsuario = null;
        }

        public void create()
        {
            string email = this.objUsuario.Email;
            string contrasena = this.objUsuario.Contrasena;
            string sql = "insert into usuario values('" + email + "','" + contrasena + "')";
            ConnectionController objConnection = new ConnectionController();
            objConnection.executeCommand(sql);
        }
        public void read()
        {

        }

        public void update()
        {

        }

        public void delete()
        {

        }

    }
}