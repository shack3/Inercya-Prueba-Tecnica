using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _4_Customers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");

            var server = @"127.0.0.1:3306";//your server
            var database = "BaseDatos"; //your database name
            var username = "root"; //username of server to connect
            var password = "5kc;2X(b"; //password

            //your connection string 
            string connString = "Data Source=DESKTOP-P3OADLJ/MySQL80;" +
                                "Initial Catalog=BaseDatos;" +
                                "User id=root;" +
                                "Password=";

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }
    }
}
