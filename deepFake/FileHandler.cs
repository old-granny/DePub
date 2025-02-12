using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Drawing.Printing;



namespace deepFake
{
    public class FileHandler
    {
        const string DATABASENAME = "deepfake";
        const string TABLENAME = "post_data";
        private string ConnectionString = $"Server=localhost;Port=3306;Database = {DATABASENAME};User Id=root;Password=yourpassword;";
        private MySqlConnection conn;
        
        public FileHandler()
        {
            connectionDataBase();
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
        
        public bool insertIntoData(string title, string content)
        {
            // Methode tres insecure a verifier !!!!!!!!!!!
            string cmd = $"INSERT INTO {TABLENAME} VALUES (NULL, '{title}', '{content}');";
            MySqlCommand query = new MySqlCommand(cmd, conn);
            query.ExecuteNonQuery();

            return true;
        }




        // Cree une dataBase simple et universel comme sa n'importe quelle serveur auront les meme 
        // paramettre
        private bool createDataBase() {
            
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
    }
}
