using SistemaGestionIndicadores.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestionIndicadores.Controllers
{
    public class TipoIndicadorController
    {
        public void Create(TipoIndicador tipoIndicador)
        {
            string sql = "INSERT INTO tipoindicador (nombre) VALUES (@Nombre)";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Nombre", tipoIndicador.Nombre)
            };

            ConnectionController objConnection = new ConnectionController();
            objConnection.ExecuteCommand(sql, parametros);
        }

        public List<TipoIndicador> List()
        {
            List<TipoIndicador> tiposIndicador = new List<TipoIndicador>();
            string sql = "SELECT * FROM tipoindicador";

            ConnectionController objConnection = new ConnectionController();
            DataSet objDataset = objConnection.ExecuteSelect(sql);

            foreach (DataRow row in objDataset.Tables[0].Rows)
            {
                TipoIndicador tipoIndicador = new TipoIndicador
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nombre = row["nombre"].ToString()
                };
                tiposIndicador.Add(tipoIndicador);
            }

            return tiposIndicador;
        }

        public void Update(TipoIndicador tipoIndicador)
        {
            string sql = "UPDATE tipoindicador SET nombre = @Nombre WHERE id = @Id";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Id", tipoIndicador.Id),
                new SqlParameter("@Nombre", tipoIndicador.Nombre)
            };

            ConnectionController objConnection = new ConnectionController();
            objConnection.ExecuteCommand(sql, parametros);
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM tipoindicador WHERE id = @Id";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };

            ConnectionController objConnection = new ConnectionController();
            objConnection.ExecuteCommand(sql, parametros);
        }

        public TipoIndicador Search(int id)
        {
            TipoIndicador tipoIndicador = null;
            string sql = "SELECT * FROM tipoindicador WHERE id = @Id";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };

            ConnectionController objConnection = new ConnectionController();
            DataSet objDataset = objConnection.ExecuteSelect(sql, parametros);

            if (objDataset.Tables[0].Rows.Count > 0)
            {
                DataRow row = objDataset.Tables[0].Rows[0];
                tipoIndicador = new TipoIndicador
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nombre = row["nombre"].ToString()
                };
            }

            return tipoIndicador;
        }
    }
}