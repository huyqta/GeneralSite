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
            try
            {
                MySqlConnection connection = new MySqlConnection();
                string connectionString = "Server=128.199.64.249;Port=3306;Database=generaldb;Uid=huyquan;Pwd=sql;SslMode=None";
                connection.ConnectionString = connectionString;
                Console.WriteLine(connection.DataSource);
                Console.WriteLine(connection.Database);
                Console.WriteLine(connection.ConnectionString);
                connection.Open();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.ReadLine();
            }
            //Console.WriteLine("Hello World!");


            //DbContext context = new DbContext();
            //context.

            //var listcategory = File.ReadAllLines(@"C:/Users/HUYQTA/Desktop/category.txt");
            //string insertCate = "INSERT INTO Category (Id, Name, ParentId, DateCRT) VALUES({0}, {1}, {2})";
            //foreach (var line in listcategory)
            //{
            //    string id = line.Split('\t')[0];
            //    string name = line.Split('\t')[1];
            //    string ParentId = "-1";
            //    string query = string.Format(insertCate, id, name, ParentId);
            //    MySqlCommand cmd = new MySqlCommand(query, connection);
            //    cmd.ExecuteNonQuery();
            //}


        }
    }
}
