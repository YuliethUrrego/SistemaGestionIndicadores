using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaGestionIndicadores.Controllers
{
    public class ConnectionController
    {
        // Declaración de variables de clase
        String cadenaConexion;
        SqlConnection objSqlConnection;

        // Constructor por defecto
        public ConnectionController()
        {
            // Se construye la cadena de conexión utilizando la base de datos especificada
            this.cadenaConexion = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BDGestionIndicadores.mdf;Integrated Security = True";
        }

        // Método para abrir la conexión a la base de datos
        public String Open()
        {
            String msg = "ok";
            try
            {
                // Se crea una nueva instancia de SqlConnection utilizando la cadena de conexión
                objSqlConnection = new SqlConnection(cadenaConexion);
                // Se abre la conexión a la base de datos
                objSqlConnection.Open();
            }
            catch (Exception Ex)
            {
                // Si ocurre un error, se captura el mensaje de excepción
                msg = Ex.Message;
            }
            return msg;
        }

        // Método para cerrar la conexión a la base de datos
        public String Close()
        {
            String msg = "ok";
            try
            {
                // Se cierra la conexión a la base de datos
                objSqlConnection.Close();
            }
            catch (Exception Ex)
            {
                // Si ocurre un error, se captura el mensaje de excepción
                msg = Ex.Message;
            }
            return msg;
        }

        // Método para ejecutar un comando SQL en la base de datos insert into, update, delete
        public String ExecuteCommand(String comandoSql, SqlParameter[] parametros = null)
        {
            String msg = "ok";
            try
            {
                // Open DataBase
                Open();

                // Se crea un nuevo SqlCommand utilizando el comando SQL y la conexión a la base de datos
                SqlCommand sqlComando = new SqlCommand(comandoSql, objSqlConnection);

                // Si hay parámetros, los añadimos al comando SQL
                if (parametros != null)
                {
                    sqlComando.Parameters.AddRange(parametros);
                }

                // Se ejecuta el comando SQL en la base de datos
                sqlComando.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                // Si ocurre un error, se captura el mensaje de excepción
                msg = Ex.Message;
            }
            finally
            {
                //Close DataBase
                Close();
            }

            return msg;
        }

        // Método para ejecutar una consulta SQL en la base de datos y devolver un DataSet select * from....
        public DataSet ExecuteSelect(String comandoSql, SqlParameter[] parametros = null)
        {
            String msg = "ok";
            DataSet objDataSet = new DataSet();

            try
            {
                // Open DataBase
                Open();

                // Se crea un nuevo SqlCommand utilizando el comando SQL y la conexión a la base de datos
                SqlCommand sqlComando = new SqlCommand(comandoSql, objSqlConnection);

                // Si hay parámetros, los añadimos al comando SQL
                if (parametros != null)
                {
                    sqlComando.Parameters.AddRange(parametros);
                }

                // Se crea un nuevo SqlDataAdapter utilizando el SqlCommand y la conexión a la base de datos
                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlComando);

                // Se llena el DataSet con los resultados de la consulta SQL
                sqlDataAdap.Fill(objDataSet);
            }
            catch (Exception Exc)
            {
                // Si ocurre un error, se captura el mensaje de excepción
                msg = Exc.Message;
            }
            finally
            {
                //Close DataBase
                Close();
            }

            return objDataSet;
        }
    }
}