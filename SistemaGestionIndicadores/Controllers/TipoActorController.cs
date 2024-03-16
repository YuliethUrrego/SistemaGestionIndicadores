using SistemaGestionIndicadores.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaGestionIndicadores.Controllers
{
    public class TipoActorController
    {
        TipoActor objTipoActor;

        public TipoActorController(TipoActor objTipoActor)
        {
            this.objTipoActor = objTipoActor;
        }

        public TipoActorController()
        {
        }

        public void Create()
        {
            try
            {
                string sql = "INSERT INTO tipoactor (nombre) VALUES (@Nombre)";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Nombre", objTipoActor.Nombre)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el tipo de actor: " + ex.Message);
            }
        }

        public List<TipoActor> List()
        {
            List<TipoActor> tiposActores = new List<TipoActor>();
            try
            {
                string sql = "SELECT * FROM tipoactor";

                ConnectionController objConnection = new ConnectionController();
                DataSet objDataset = objConnection.ExecuteSelect(sql);

                foreach (DataRow row in objDataset.Tables[0].Rows)
                {
                    TipoActor tipoActor = new TipoActor
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = row["nombre"].ToString()
                    };
                    tiposActores.Add(tipoActor);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar los tipos de actor: " + ex.Message);
            }

            return tiposActores;
        }

        public void Update()
        {
            try
            {
                string sql = "UPDATE tipoactor SET nombre = @Nombre WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objTipoActor.Id),
                    new SqlParameter("@Nombre", objTipoActor.Nombre)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el tipo de actor: " + ex.Message);
            }
        }

        public void Delete()
        {
            try
            {
                string sql = "DELETE FROM tipoactor WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objTipoActor.Id)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el tipo de actor: " + ex.Message);
            }
        }

        public TipoActor Search()
        {
            TipoActor tipoActor = null;
            try
            {
                string sql = "SELECT * FROM tipoactor WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objTipoActor.Id)
                };

                ConnectionController objConnection = new ConnectionController();
                DataSet objDataset = objConnection.ExecuteSelect(sql, parametros);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    DataRow row = objDataset.Tables[0].Rows[0];
                    tipoActor = new TipoActor
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = row["nombre"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar el tipo de actor: " + ex.Message);
            }

            return tipoActor;
        }
    }
}