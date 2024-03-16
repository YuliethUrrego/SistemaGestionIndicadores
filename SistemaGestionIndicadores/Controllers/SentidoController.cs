using SistemaGestionIndicadores.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaGestionIndicadores.Controllers
{
    public class SentidoController
    {
        Sentido objSentido;

        public SentidoController(Sentido objSentido)
        {
            this.objSentido = objSentido;
        }

        public SentidoController()
        {
        }

        public void Create()
        {
            try
            {
                string sql = "INSERT INTO sentido (nombre) VALUES (@Nombre)";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Nombre", objSentido.Nombre)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el sentido: " + ex.Message);
            }
        }

        public List<Sentido> List()
        {
            List<Sentido> sentidos = new List<Sentido>();
            try
            {
                string sql = "SELECT * FROM sentido";

                ConnectionController objConnection = new ConnectionController();
                DataSet objDataset = objConnection.ExecuteSelect(sql);

                foreach (DataRow row in objDataset.Tables[0].Rows)
                {
                    Sentido sentido = new Sentido
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = row["nombre"].ToString()
                    };
                    sentidos.Add(sentido);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar los sentidos: " + ex.Message);
            }

            return sentidos;
        }

        public void Update()
        {
            try
            {
                string sql = "UPDATE sentido SET nombre = @Nombre WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objSentido.Id),
                    new SqlParameter("@Nombre", objSentido.Nombre)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el sentido: " + ex.Message);
            }
        }

        public void Delete()
        {
            try
            {
                string sql = "DELETE FROM sentido WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objSentido.Id)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el sentido: " + ex.Message);
            }
        }

        public Sentido Search()
        {
            Sentido sentido = null;
            try
            {
                string sql = "SELECT * FROM sentido WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objSentido.Id)
                };

                ConnectionController objConnection = new ConnectionController();
                DataSet objDataset = objConnection.ExecuteSelect(sql, parametros);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    DataRow row = objDataset.Tables[0].Rows[0];
                    sentido = new Sentido
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = row["nombre"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar el sentido: " + ex.Message);
            }

            return sentido;
        }
    }
}