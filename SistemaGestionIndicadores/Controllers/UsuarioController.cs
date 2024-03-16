using SistemaGestionIndicadores.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void Create()
        {
            string sql = "INSERT INTO usuario VALUES('" + objUsuario.Email + "','" + objUsuario.Contrasena + "')";
            ConnectionController objConnection = new ConnectionController();
            objConnection.ExecuteCommand(sql);
        }
        public Usuario[] List()
        {
            int n = 0;
            int i = 0;
            Usuario[] arrayUsuario = null;
            string sql = "SELECT * FROM usuario";
            ConnectionController objConnection = new ConnectionController();
            DataSet objDataset = objConnection.ExecuteSelect(sql);
            n = objDataset.Tables[0].Rows.Count;
            arrayUsuario = new Usuario[n];
            while (i < n)
            {
                Usuario objUsuario = new Usuario();
                objUsuario.Email = objDataset.Tables[0].Rows[i]["email"].ToString();
                objUsuario.Contrasena = objDataset.Tables[0].Rows[i]["contrasena"].ToString();
                arrayUsuario[i] = objUsuario;
                i++;
            }
            return arrayUsuario;
        }

        public void Update()
        {
            string sql = "UPDATE usuario SET contrasena='" + objUsuario.Contrasena + "' WHERE email='" + objUsuario.Email + "'";
            ConnectionController objConnection = new ConnectionController();
            objConnection.ExecuteCommand(sql);
        }

        public void Delete()
        {
            string sql = "DELETE FROM usuario WHERE email='" + objUsuario.Email + "'";
            ConnectionController objConnection = new ConnectionController();
            objConnection.ExecuteCommand(sql);
        }

        public Usuario Search()
        {
            string sql = "SELECT * FROM usuario WHERE email='" + objUsuario.Email + "'";
            ConnectionController objConnection = new ConnectionController();
            DataSet objDataset = objConnection.ExecuteSelect(sql);
            objUsuario.Contrasena = objDataset.Tables[0].Rows[0]["contrasena"].ToString();
            return objUsuario;
        }

    }
}