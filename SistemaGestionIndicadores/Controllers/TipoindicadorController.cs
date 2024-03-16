﻿using SistemaGestionIndicadores.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestionIndicadores.Controllers
{
    public class TipoIndicadorController
    {
        TipoIndicador objTipoIndicador;

        public TipoIndicadorController(TipoIndicador objTipoIndicador)
        {
            this.objTipoIndicador = objTipoIndicador;
        }

        public TipoIndicadorController()
        {
        }

        public void Create()
        {
            try
            {
                string sql = "INSERT INTO tipoindicador (nombre) VALUES (@Nombre)";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Nombre", objTipoIndicador.Nombre)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el tipo de indicador: " + ex.Message);
            }
        }

        public List<TipoIndicador> List()
        {
            List<TipoIndicador> tiposIndicador = new List<TipoIndicador>();
            try
            {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar los tipos de indicador: " + ex.Message);
            }

            return tiposIndicador;
        }

        public void Update()
        {
            try
            {
                string sql = "UPDATE tipoindicador SET nombre = @Nombre WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objTipoIndicador.Id),
                    new SqlParameter("@Nombre", objTipoIndicador.Nombre)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el tipo de indicador: " + ex.Message);
            }
        }

        public void Delete()
        {
            try
            {
                string sql = "DELETE FROM tipoindicador WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objTipoIndicador.Id)
                };

                ConnectionController objConnection = new ConnectionController();
                objConnection.ExecuteCommand(sql, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el tipo de indicador: " + ex.Message);
            }
        }

        public TipoIndicador Search()
        {
            TipoIndicador tipoIndicador = null;
            try
            {
                string sql = "SELECT * FROM tipoindicador WHERE id = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Id", objTipoIndicador.Id)
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar el tipo de indicador: " + ex.Message);
            }

            return tipoIndicador;
        }
    }
}