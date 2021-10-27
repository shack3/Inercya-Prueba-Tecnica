using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace _4_Customers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adquiriendo Conexión ...");

            //Datos del servidor y conexion a la base de datos
            string dataBase = "Y4BswmLq2r";
            string server = "remotemysql.com";
            uint port = 3306;
            string userID = "Y4BswmLq2r";
            string pass = "MGUmmA9K0R";
            string tableName = "customers";
            string rutaCSV = @"A:\Documents\0 - GIT\Inercya-Prueba-Tecnica\4-Customers\Customers.csv";


            //Creacion de string de conexion.
            MySqlConnection conn = GetMySqlConnection(dataBase, server, port, userID, pass);;
            
            //Conexion y carga al Servidor.
            try
            {
                MySqlCommand command;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string sql;
                string[] rawData = LoadCSV(rutaCSV);

                //Creacion del comando para SQL

                Console.WriteLine("\nAdquiriendo la tabla de la base de datos: " + dataBase);
                Console.WriteLine("\nIniciando carga de datos....");

                string[] csvHeaders = rawData[0].Split(';');
                for (int i=1; i<rawData.Length; i++)
                {
                    sql = "INSERT INTO `" + dataBase + "`." + tableName + " (";
                    for (int j = 0; j < csvHeaders.Length - 1; j++)
                    {
                        sql += csvHeaders[j] + ", ";
                    }

                    sql += csvHeaders[csvHeaders.Length - 1] + ") VALUES(";

                    string[] csv = rawData[i].Split(';');
                    for (int j = 0; j < csv.Length - 1; j++)
                    {
                        sql += "'" + csv[j] + "'" + ", ";
                    }
                    sql += "'" + csv[csv.Length - 1] + "'" + ");";
                    //Comando creado
                    command = new MySqlCommand(sql, conn);

                    //Lanzar el comando al Servidor de SQL Elegido.
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                }
                
                Console.WriteLine("\n\nCarga de datos Finalizada.\nPulse cualquier tecla para cerrar esta ventana...");

                conn.Close();

                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }

        //"Constructor" del string de conexion
        public static MySqlConnection GetMySqlConnection(string dataBase, string server, uint port, string userID, string pass)
        {
            MySqlConnectionStringBuilder myBuilder = new MySqlConnectionStringBuilder();
            myBuilder.Database = dataBase;
            myBuilder.Server = server;
            myBuilder.Port = port;
            myBuilder.UserID = userID;
            myBuilder.Password = pass;

            MySqlConnection myconn = new MySqlConnection(myBuilder.ConnectionString);

            try
            {
                Console.WriteLine("Abriendo conexión ...");

                myconn.Open();

                Console.WriteLine("Conexón establecida!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                myconn.Close();
            }
            return myconn;
        }
        //Loader del csv en un array por lineas.
        private static string[] LoadCSV(string filename)
        {
            // Direccion del CSV.
            string whole_file = System.IO.File.ReadAllText(filename);

            // Dividir en lineas.
            whole_file = whole_file.Replace('\n', '\r');
            whole_file = whole_file.Replace('\'', ' ');
            string[] lines = whole_file.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            return lines;
        }
    }
}
