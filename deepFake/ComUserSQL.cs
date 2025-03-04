using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace deepFake
{
    internal class ComUserSQL
    {
        // Ici devrait etre des variable d'enviroment
        const string DATABASENAME = "deepfakeUsers";
        const string TABLENAME = "users_infos";
        private string ConnectionString = $"Server=localhost;Port=3306;Database = {DATABASENAME};User Id=root;Password=;";
        private string ConnectionStringCreateDatabse = $"Server=localhost;Port=3306;User Id=root;Password=wx2413#10MIA?;";
        // Attribut
        private MySqlConnection conn;

        public ComUserSQL()
        {   
            connectionDataBase(); // Instancier la connection
        }
        
        
        public bool createNewUser(string username, string name, string prename, string email, string password, string date)
        {
            // Etape 1 verification initial
            if(!Algorithme.IsSignUpParamSecure(username, name, prename, email, password, date)) return false;

            // Etape 2 utiliser hashing sur le mot de passe
            string hashedPassword = Algorithme.HashPassword(password);

            string cmd = $"INSERT INTO {TABLENAME} VALUES (NULL, @username, @name, @prename,@email,@password,@date);";

            try
            {
                MySqlCommand query = new MySqlCommand(cmd, conn);
                // Ajouter les paramettre
                query.Parameters.AddWithValue("@username", username);
                query.Parameters.AddWithValue("@password", hashedPassword);
                query.Parameters.AddWithValue("@name", name);
                query.Parameters.AddWithValue("@prename", prename);
                query.Parameters.AddWithValue("@email", email);
                query.Parameters.AddWithValue("@date", date);

                query.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine("There was an error inserting data");
                Console.WriteLine(ex.ToString());
                return false;
            }
            
        }

        public bool SigningCheck(string username, string password)
        {
            bool validUser = false;
            string hashedPassword = Algorithme.HashPassword(password);
            Console.WriteLine(hashedPassword);

            if (!Algorithme.VerifySigningParam(username, password)) return false;
            
            List<string[]> tableContent = new List<string[]>();
            string cmd = $"SELECT COUNT(*) FROM {TABLENAME} WHERE username = @username AND password = @password";

            
            using (MySqlCommand query = new MySqlCommand(cmd, conn))
            {
                query.Parameters.AddWithValue("@username", username);
                query.Parameters.AddWithValue("@password", hashedPassword);


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
            }
            
            // Devrait utiliser tryParse

            // Vas parse le premier paramettre recu apres le query pour obtenir l'ID
            int id = Int32.Parse(tableContent[0][0]); 
            if (id > 0) { // Si le ID n'est pas 0 alors la combinaison username - password n'existe pas
                validUser = true;   
            }

            return validUser;
        }


        public string getUsername() =>
            getTableContent(TABLENAME)[0][0];
        


        private List<string[]> getTableContent(string tableName)
        {
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

        // ---------------------------- Section a retirer ------------------------------------------//
        //   --------->
        private bool createUserDb()
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
            //CREATE TABLE `TABLENAME` (`id` INT NOT NULL AUTO_INCREMENT, `username` VARCHAR(55) DEFAULT NULL, `name` VARCHAR(55) DEFAULT NULL, `prename` VARCHAR(55) DEFAULT NULL, `email` VARCHAR(55) DEFAULT NULL, `password` VARCHAR(55) DEFAULT NULL, `date` VARCHAR(55) DEFAULT NULL, PRIMARY KEY (`id`));

            string query = $"CREATE TABLE `{TABLENAME}` (" +
                "`id` int NOT NULL AUTO_INCREMENT," +
                "`username` varchar(55) DEFAULT NULL," +
                "`name` varchar(55) DEFAULT NULL," +
                "`prename` varchar(55) DEFAULT NULL," +
                "`email` varchar(55) DEFAULT NULL," +
                "`password` varchar(55) DEFAULT NULL," +
                "`date` varchar(55) DEFAULT NULL," +
                "PRIMARY KEY(`id`)" +
                ");";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.ExecuteNonQuery(); // Execute query
            }
            return true;
        }
    }
}
