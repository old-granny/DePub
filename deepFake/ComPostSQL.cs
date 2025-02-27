using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace deepFake
{


    
    public class ComPostSQL
    {
        // Ici devrait etre des variable d'enviroment
        const string DATABASENAME = "deepfake";
        const string TABLENAME = "post_data";
        private string ConnectionString = $"Server=127.0.0.1;Port=3306;Database = {DATABASENAME};User Id=root;Password=;";
        
        // Attribut
        private MySqlConnection conn;
        private List<string[]> CurrentContent;


        // Constructor
        public ComPostSQL()
        {
            
            if (!connectionDataBase()) {
                throw new Exception("Erreur de connection");
            }
            
            CurrentContent = getTableContent(TABLENAME);
            
            //createTable();
        }

        public bool contentChange()
        {
            bool changed = CurrentContent == getTableContent(TABLENAME);
            CurrentContent = getTableContent(TABLENAME);
            return changed;
        }

        // Ici oubliger d'etre dans post data
        public bool insertIntoData(string title, string content, byte[] img0, byte[] img1, byte[] img2)
        {
            string cmd = $"INSERT INTO {TABLENAME} (title, content, image1, image2, image3) VALUES (@title, @content, @img0, @img1, @img2)";

            
            using (MySqlCommand query = new MySqlCommand(cmd, conn))
            {
                query.Parameters.AddWithValue("@title", title);
                query.Parameters.AddWithValue("@content", content);
                query.Parameters.Add("@img0", MySqlDbType.MediumBlob).Value = (img0 ?? new byte[0]);
                query.Parameters.Add("@img1", MySqlDbType.MediumBlob).Value = (img1 ?? new byte[0]);
                query.Parameters.Add("@img2", MySqlDbType.MediumBlob).Value = (img2 ?? new byte[0]);

                query.ExecuteNonQuery();
            }

            return true;
        }
        public List<int> getIdPost(int nbPost)
        {
            List<int> ids = new List<int>();
            if(nbPost > getNbPost(TABLENAME))
            {
                nbPost = getNbPost(TABLENAME);
            }
            string cmd = $"SELECT ID FROM {TABLENAME}";
            using(MySqlCommand query  = new MySqlCommand(cmd, conn))
            {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read()) { 
                    int id = reader.GetInt32("id");
                    ids.Add(id);
                }
                reader.Close();
            }
            return ids;
        }

        /// <summary>
        /// Vas retourner le nombre de ligne que la table contient
        /// donc le nombre de post total
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int getNbPost(string tableName) =>
            getTableContent(TABLENAME).Count;
       

        private List<string[]> getTableContent(string tableName)
        {
            // Methode un peu insecure a verifier car ne devrait pas avoir une methode qui
            // contient 100% des donnees de la table
            // devrait une utiliter plus simple
            List<string[]> tableContent = new List<string[]>();
         
            string cmd = $"SELECT * FROM {tableName};";
            MySqlCommand query = new MySqlCommand(cmd, conn);
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                string[] row = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader[i] != null)
                    {
                        row[i] = reader[i].ToString();
                    }
                }
                tableContent.Add(row);
            }
            reader.Close();
            return tableContent;
        }

        public string[] getPostData(string tableName, int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid ID");

            string query = $"SELECT title, content FROM {tableName} WHERE ID = @id";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read()) // Move to the first row
                {
                    string[] content = [reader.IsDBNull(0) ? null : reader.GetString(0), reader.IsDBNull(1) ? null : reader.GetString(1)];
                    reader.Close();
                    return content;
                }
                
            }
            return null; // No data found
        }


        public List<Image> GetTableImages(string tableName, int id)
        {
            List<Image> tableImages = new List<Image>();
            for (int i = 1; i <= 3; i++) // Retrieve all three images
            {
                tableImages.Add(GetSingleImage(tableName, id, $"image{i}"));
            }
            return tableImages;
        }

        private Image GetSingleImage(string tableName, int id, string columnName)
        {
            Image image = null;
            string query = $"SELECT {columnName} FROM {tableName} WHERE ID = @id";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() && !reader.IsDBNull(0))
                    {
                        byte[] imageData = (byte[])reader[0];
                        if (imageData.Length > 1) { 
                            image = (Bitmap)((new ImageConverter()).ConvertFrom(imageData));
                        }
                    }
                    reader.Close();
                }
            }
            return image;
        }
        // Fonction Basique

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


        // Cree une dataBase simple et universel comme sa n'importe quelle serveur auront les meme 
        // paramettre
        private bool createDeepSeek()
        {

            if (createDataBase())
            {
                createTable();
            }
            return true;

        }

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
            // CREATE TABLE post_data (id int NOT NULL AUTO_INCREMENT, title varchar(55) DEFAULT NULL, content varchar(2500) DEFAULT NULL, PRIMARY KEY (id));

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
