using SistemaGestionIndicadores.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaGestionIndicadores.Controllers
{
    public class RepresenVisualController
    {
        RepresenVisual objRepresenVisual;

        public RepresenVisualController(RepresenVisual objRepresenVisual)
        {
            this.objRepresenVisual = objRepresenVisual;
        }

        public RepresenVisualController()
        {
        }

        public void Create()
        {
            try
            {
                string sql = "INSERT INTO represenvisual (nombre) VALUES (@Nombre)";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Nombre", objRepresenVisual.Nombre)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la representacion visual: " + ex.Message);
            }
        }

        public List<RepresenVisual> List()
        {
            List<RepresenVisual> represenVisual = new List<RepresenVisual>();

            try
            {
                string sql = "SELECT * FROM represenvisual";

                ConnectionController objConnection = new ConnectionController();
                DataSet objDataset = objConnection.ExecuteSelect(sql);

                foreach (DataRow row in objDataset.Tables[0].Rows)
                {
                    RepresenVisual objRepresenVisual = new RepresenVisual
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = row["nombre"].ToString()
                    };
                    represenVisual.Add(objRepresenVisual);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar las representaciones visuales: " + ex.Message);
            }

            return represenVisual;
        }

        public void Update()
        {
            try
            {
                string sql = "UPDATE represenvisual SET nombre = @Nombre WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objRepresenVisual.Id),
                    new SqlParameter("@Nombre", objRepresenVisual.Nombre)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la representacion visual: " + ex.Message);
            }
        }

        public void Delete()
        {
            try
            {
                string sql = "DELETE FROM represenvisual WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objRepresenVisual.Id)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la representacion visual: " + ex.Message);
            }
        }

        public RepresenVisual Search()
        {
            RepresenVisual represenVisual = null;
            try
            {
                string sql = "SELECT * FROM represenvisual WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objRepresenVisual.Id)
                };

                ConnectionController objConnection = new ConnectionController();
                DataSet objDataset = objConnection.ExecuteSelect(sql, parametros);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    DataRow row = objDataset.Tables[0].Rows[0];
                    represenVisual = new RepresenVisual
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = row["nombre"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar la representacion visual: " + ex.Message);
            }

            return represenVisual;
        }
    }
}