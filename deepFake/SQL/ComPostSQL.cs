using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace deepFake.SQL
{
    public class ComPostSQL
    {
        // Ici devrait etre des variable d'enviroment
        const string DATABASENAME = "deepfake";
        const string TABLENAME = "post_data";
        private string ConnectionString = $"Server=127.0.0.1;Port=3306;Database = {DATABASENAME};User Id=root;Password=;";

        // Attribut
        private MySqlConnection conn;

        private static ComPostSQL Instance_;

        public static ComPostSQL Instance 
        {
            get 
            {
                if (Instance_ == null)
                {
                    return new ComPostSQL();
                }
                return Instance_;
            
            }
        
        }
        // Constructor
        private ComPostSQL()
        {

            if (!connectionDataBase())
            { // Si la connection n'a pas fonctionner
                throw new Exception("Tes con");
            }
            Instance_ = this;

        }
        /// <summary>
        /// Set l'instance de conn
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Vas inserer les donnees du post dans la base de donne
        /// La facon dont les images seront gere sera porter a changer pour seulemet savoir quelle image et non sauvegarder l'image
        /// </summary>
        /// <param name="title"> titre du post </param>
        /// <param name="content"> le contenue du titre </param>
        /// <param name="img0"> premiere image </param>
        /// <param name="img1"> deuxieme image </param>
        /// <param name="img2"> troisieme image </param>
        /// <returns> si l'action a fonctionner </returns>
        public bool insertIntoData(string order, string title, List<string> content, List<byte[]> images)
        {
            // Vérifier si les données sont sécurisées
            if (!Algorithme.IsPostDataSecure(title, content, images))
            {
                Console.WriteLine("didn't work");
                return false; // On stoppe l'insertion si les données ne sont pas sécurisées
            }

            // Command SQL 
            string cmd = $"INSERT INTO {TABLENAME} (title, structure, content1, content2, content3, content4, image1, image2, image3) VALUES (@title, @structure, @content1, @content2, @content3, @content4, @img1, @img2, @img3)";

            int pos_c = content.Count - 1;
            for (int i = pos_c; i < 4; i++) content.Add("");

            int pos_i = images.Count - 1;
            for (int i = pos_i; i < 4; i++) images.Add(new byte[0]);

            // Utilisation des paramètres sécurisés
            using (MySqlCommand query = new MySqlCommand(cmd, conn))
            {
                query.Parameters.AddWithValue("@title", title);
                query.Parameters.AddWithValue("@structure", order);

                query.Parameters.AddWithValue("@content1", content[0] ?? "");
                query.Parameters.AddWithValue("@content2", content[1] ?? "");
                query.Parameters.AddWithValue("@content3", content[2] ?? "");
                query.Parameters.AddWithValue("@content4", content[3] ?? "");

                query.Parameters.Add("@img1", MySqlDbType.MediumBlob).Value = images[0] ?? new byte[0];
                query.Parameters.Add("@img2", MySqlDbType.MediumBlob).Value = images[1] ?? new byte[0];
                query.Parameters.Add("@img3", MySqlDbType.MediumBlob).Value = images[2] ?? new byte[0];

                query.ExecuteNonQuery();
            }

            return true;
        }

        /// <summary>
        /// Vas allez retrive une list de id qui se trouve dans la table SQL
        /// </summary>
        /// <param name="nbPost"> nombre de post voulue </param>
        /// <returns> List de id </returns>
        public List<int> getIdPost(int nbPost)
        {
            List<int> ids = new List<int>(); // List contenant les IDs

            // Si le nombre de post voulue est superieur a la quantiter de post present bloque au nombre de post
            if (nbPost > getNbPost(TABLENAME))
                nbPost = getNbPost(TABLENAME);

            // Aller chercher tout les id dans la table
            string cmd = $"SELECT ID FROM {TABLENAME}";
            using (MySqlCommand query = new MySqlCommand(cmd, conn))
            {
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                { // Lire les row dans qu'il en reste
                    int id = reader.GetInt32("id"); // transformer en int 
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

        /// <summary>
        /// Fait la lecture compete d'un tableau de donnees dans comPost
        /// </summary>
        /// <param name="tableName">nom de la table</param>
        /// <returns> retourne une list de chaque row de la table de donnees </returns>
        private List<string[]> getTableContent(string tableName)
        {
            // Methode un peu insecure a verifier car ne devrait pas avoir une methode qui
            // contient 100% des donnees de la table
            // devrait une utiliter plus simple
            List<string[]> tableContent = new List<string[]>();

            string cmd = $"SELECT * FROM {tableName};";

            MySqlCommand query = new MySqlCommand(cmd, conn);
            MySqlDataReader reader = query.ExecuteReader(); // Executer le liseur

            while (reader.Read()) // Lire tant qu'il y a des donnees
            {
                string[] row = new string[reader.FieldCount]; // tableau des mots dans la ligne
                for (int i = 0; i < reader.FieldCount; i++) // Lire tant que chaque colonne na pas ete lue
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

        /// <summary>
        /// Aller chercher une row selon le id
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        /// <returns> un tableau avec titre et contenue </returns>
        /// <exception cref="ArgumentException"></exception>
        public List<string> getPostData(string tableName, int id)
        {
            // Verifier si le ID est correct 
            if (id <= 0) throw new ArgumentException("Invalid ID");

            string query = $"SELECT title, content1 FROM {tableName} WHERE ID = @id"; // la commande pour aller chercher le titre et le contenue
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // Move to the first row
                {
                    List<string> content = [reader.IsDBNull(0) ? null : reader.GetString(0), reader.IsDBNull(1) ? null : reader.GetString(1)]; // ["titre", "contenue"]
                    reader.Close();
                    return content;
                }

            }
            return null; // No data found
        }


        /// <summary>
        /// Retrive 3 images from the table row
        /// if an image is null than return a list of 2 images and so on
        /// </summary>
        /// <param name="tableName"> name of the table</param>
        /// <param name="id"> id of the needed row</param>
        /// <returns></returns>
        public List<Image> GetTableImages(string tableName, int id)
        {
            List<Image> tableImages = new List<Image>();
            for (int i = 1; i <= 3; i++) // Retrieve all three images
            {
                tableImages.Add(GetSingleImage(tableName, id, $"image{i}"));
            }
            return tableImages;
        }

        /// <summary>
        /// Vas chercher uniquement une seule image selon l'image voulue
        /// </summary>
        /// <param name="tableName"> name of table </param>
        /// <param name="id"> id of the row </param>
        /// <param name="columnName"> image1, image2, image3 </param>
        /// <returns></returns>
        private Image GetSingleImage(string tableName, int id, string columnName)
        {
            Image image = null; // Instancier a null si pas d'image
            string query = $"SELECT {columnName} FROM {tableName} WHERE ID = @id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id); // inserer le id dans la query

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read() && !reader.IsDBNull(0)) // is le reader n'est pas null
                {
                    byte[] imageData = (byte[])reader[0];
                    if (imageData.Length > 1)
                    {
                        image = (Bitmap)new ImageConverter().ConvertFrom(imageData); // Permet de lire l'image BLOB(bytes) et le transformer en IMAGE
                    }
                }
                reader.Close();
            }

            return image;
        }

        public string GetFormatWithId(string tableName, int idPost)
        {
            // Format row -> id | title | structure | 
            string query = $"SELECT structure FROM {tableName} WHERE ID = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", idPost); // inserer le id dans la query
            string format = "";
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read() && !reader.IsDBNull(0)) // is le reader n'est pas null
                {
                    format = reader.GetString(0);
                    
                }
                reader.Close();
            }
            return format;
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
            // CREATE TABLE post_data (id int NOT NULL AUTO_INCREMENT, title varchar(55) DEFAULT NULL, content varchar(2500) DEFAULT NULL, image1 mediumBlob NULL, image2 mediumBlob NULL, image3 mediumBlob NULL,  PRIMARY KEY (id));

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
