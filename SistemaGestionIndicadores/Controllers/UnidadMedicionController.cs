using SistemaGestionIndicadores.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaGestionIndicadores.Controllers
{
    public class UnidadMedicionController
    {
        UnidadMedicion objUnidadMedicion;

        public UnidadMedicionController(UnidadMedicion objUnidadMedicion)
        {
            this.objUnidadMedicion = objUnidadMedicion;
        }

        public UnidadMedicionController()
        {
        }

        public void Create()
        {
            try
            {
                string sql = "INSERT INTO unidadmedicion (descripcion) VALUES (@Descripcion)";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Descripcion", objUnidadMedicion.Descripcion)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la unidad de medición: " + ex.Message);
            }
        }

        public List<UnidadMedicion> List()
        {
            List<UnidadMedicion> unidadesMedicion = new List<UnidadMedicion>();
            try
            {
                string sql = "SELECT * FROM unidadmedicion";

                ConnectionController objConnection = new ConnectionController();
                DataSet objDataset = objConnection.ExecuteSelect(sql);

                foreach (DataRow row in objDataset.Tables[0].Rows)
                {
                    UnidadMedicion unidadMedicion = new UnidadMedicion
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Descripcion = row["descripcion"].ToString()
                    };
                    unidadesMedicion.Add(unidadMedicion);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar las unidades de medición: " + ex.Message);
            }

            return unidadesMedicion;
        }

        public void Update()
        {
            try
            {
                string sql = "UPDATE unidadmedicion SET descripcion = @Descripcion WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objUnidadMedicion.Id),
                    new SqlParameter("@Descripcion", objUnidadMedicion.Descripcion)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la unidad de medición: " + ex.Message);
            }
        }

        public void Delete()
        {
            try
            {
                string sql = "DELETE FROM unidadmedicion WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objUnidadMedicion.Id)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la unidad de medición: " + ex.Message);
            }
        }

        public UnidadMedicion Search()
        {
            UnidadMedicion unidadMedicion = null;
            try
            {
                string sql = "SELECT * FROM unidadmedicion WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objUnidadMedicion.Id)
                };

                ConnectionController objConnection = new ConnectionController();
                DataSet objDataset = objConnection.ExecuteSelect(sql, parametros);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    DataRow row = objDataset.Tables[0].Rows[0];
                    unidadMedicion = new UnidadMedicion
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Descripcion = row["descripcion"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar la unidad de medición: " + ex.Message);
            }

            return unidadMedicion;
        }
    }
}