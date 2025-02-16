using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace deepFake
{


    
    internal class ComSQL
    {
        const string DATABASENAME = "deepfake";
        const string TABLENAME = "post_data";
        private string ConnectionString = $"Server=localhost;Port=3306;Database = {DATABASENAME};User Id=root;Password=wx2413#10MIA?;";
        private MySqlConnection conn;


        public ComSQL()
        {
            if (!connectionDataBase()) {
                throw new Exception("Erreur de connection");
            }        
        
        }

        private bool connectionDataBase()
        {
            conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        private bool createDeepSeek()
        {

            if (createDataBase())
            {
                createTable();
            }
            return true;

        }

        // Cree une dataBase simple et universel comme sa n'importe quelle serveur auront les meme 
        // paramettre
        private bool createDataBase()
        {

            string query = $"CREATE DATABASE {DATABASENAME}";


            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.ExecuteNonQuery(); // Execute query
            }

            Console.WriteLine("Database created successfully.");
            return true;

        }
        private bool deleteDataBase()
        {
            string query = $"DROP DATABASE {DATABASENAME}";


            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.ExecuteNonQuery(); // Execute query
            }

            Console.WriteLine("Database created successfully.");
            return true;
        }

        private bool createTable()
        {
            string query = "CREATE TABLE 'post_data' (" +
                "'id' int NOT NULL AUTO_INCREMENT," +
                "'title' varchar(55) DEFAULT NULL," +
                "'content' varchar(2500) DEFAULT NULL," +
                "PRIMARY KEY('id')" +
                ");";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.ExecuteNonQuery(); // Execute query
            }
            return true;

        }

    }

     



}
