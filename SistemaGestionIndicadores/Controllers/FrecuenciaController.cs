using SistemaGestionIndicadores.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaGestionIndicadores.Controllers
{
    public class FrecuenciaController
    {
        Frecuencia objFrecuencia;

        public FrecuenciaController(Frecuencia objFrecuencia)
        {
            this.objFrecuencia = objFrecuencia;
        }

        public FrecuenciaController()
        {
        }

        public void Create()
        {
            try
            {
                string sql = "INSERT INTO frecuencia (nombre) VALUES (@Nombre)";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Nombre", objFrecuencia.Nombre)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la frecuencia: " + ex.Message);
            }
        }

        public List<Frecuencia> List()
        {
            List<Frecuencia> frecuencias = new List<Frecuencia>();

            try
            {
                string sql = "SELECT * FROM frecuencia";

                ConnectionController objConnection = new ConnectionController();
                DataSet objDataset = objConnection.ExecuteSelect(sql);

                foreach (DataRow row in objDataset.Tables[0].Rows)
                {
                    Frecuencia frecuencia = new Frecuencia
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = row["nombre"].ToString()
                    };
                    frecuencias.Add(frecuencia);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar las frecuencias: " + ex.Message);
            }

            return frecuencias;
        }

        public void Update()
        {
            try
            {
                string sql = "UPDATE frecuencia SET nombre = @Nombre WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objFrecuencia.Id),
                    new SqlParameter("@Nombre", objFrecuencia.Nombre)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la frecuencia: " + ex.Message);
            }
        }

        public void Delete()
        {
            try
            {
                string sql = "DELETE FROM frecuencia WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objFrecuencia.Id)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la frecuencia: " + ex.Message);
            }
        }

        public Frecuencia Search()
        {
            Frecuencia frecuencia = null;
            try
            {
                string sql = "SELECT * FROM frecuencia WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objFrecuencia.Id)
                };

                ConnectionController objConnection = new ConnectionController();
                DataSet objDataset = objConnection.ExecuteSelect(sql, parametros);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    DataRow row = objDataset.Tables[0].Rows[0];
                    frecuencia = new Frecuencia
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = row["nombre"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar la frecuencia: " + ex.Message);
            }

            return frecuencia;
        }
    }
}