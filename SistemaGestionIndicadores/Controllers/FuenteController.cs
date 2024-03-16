using SistemaGestionIndicadores.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaGestionIndicadores.Controllers
{
    public class FuenteController
    {
        Fuente objFuente;

        public FuenteController(Fuente objFuente)
        {
            this.objFuente = objFuente;
        }

        public FuenteController()
        {
        }

        public void Create()
        {
            try
            {
                string sql = "INSERT INTO fuente (nombre) VALUES (@Nombre)";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Nombre", objFuente.Nombre)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la fuente: " + ex.Message);
            }
        }

        public List<Fuente> List()
        {
            List<Fuente> fuentes = new List<Fuente>();

            try
            {
                string sql = "SELECT * FROM fuente";

                ConnectionController objConnection = new ConnectionController();
                DataSet objDataset = objConnection.ExecuteSelect(sql);

                foreach (DataRow row in objDataset.Tables[0].Rows)
                {
                    Fuente fuente = new Fuente
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = row["nombre"].ToString()
                    };
                    fuentes.Add(fuente);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar las fuentes: " + ex.Message);
            }

            return fuentes;
        }

        public void Update()
        {
            try
            {
                string sql = "UPDATE fuente SET nombre = @Nombre WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objFuente.Id),
                    new SqlParameter("@Nombre", objFuente.Nombre)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la fuente: " + ex.Message);
            }
        }

        public void Delete()
        {
            try
            {
                string sql = "DELETE FROM fuente WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objFuente.Id)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la fuente: " + ex.Message);
            }
        }

        public Fuente Search()
        {
            Fuente fuente = null;
            try
            {
                string sql = "SELECT * FROM fuente WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objFuente.Id)
                };

                ConnectionController objConnection = new ConnectionController();
                DataSet objDataset = objConnection.ExecuteSelect(sql, parametros);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    DataRow row = objDataset.Tables[0].Rows[0];
                    fuente = new Fuente
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = row["nombre"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar la fuente: " + ex.Message);
            }

            return fuente;
        }
    }
}