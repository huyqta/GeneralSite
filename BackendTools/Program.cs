using Microsoft.EntityFrameworkCore;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.IO;

namespace BackendTools
{
    class Program
    {

        static void Main(string[] args)
        {
            MySqlConnection connection = new MySqlConnection();
            try
            {
                string connectionString = "Server=128.199.64.249;Port=3306;Database=generaldb;Uid=huyquan;Pwd=sql";
                connection.ConnectionString = connectionString;
                Console.WriteLine(connection.DataSource);
                Console.WriteLine(connection.Database);
                Console.WriteLine(connection.ConnectionString);
                connection.Open();
                Console.WriteLine("Opened! Press Enter to close!");
                Console.ReadLine();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.ReadLine();
            }

            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("MySQL has been closed!");
                }
                
            }

        }
    }
}
