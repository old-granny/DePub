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
        public FileHandler()
        {
            
        }


       
        
        public bool insertIntoData(string title, string content)
        {
            // Methode tres insecure a verifier !!!!!!!!!!!
            string cmd = $"INSERT INTO {TABLENAME} VALUES (NULL, '{title}', '{content}');";
            MySqlCommand query = new MySqlCommand(cmd, conn);
            query.ExecuteNonQuery();

            return true;
        }

        public List<string[]> SelectData()
        {
            string cmd = $"SELECT * FROM {TABLENAME};";
            MySqlCommand query = new MySqlCommand(cmd, conn);
            MySqlDataReader reader = query.ExecuteReader();

            List<string[]> results = new List<string[]>();
            while (reader.Read())
            {
                string[] row = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[i] = reader[i].ToString();
                }
                results.Add(row);
            }
            reader.Close();
            return results;
        }


        public List<Panel> getPosts()
        {
            List<Panel> list = new List<Panel>();
            List<string[]> res = SelectData();
            int x = 0;
            int y = 0;
            for(int i = 0; i < res.Count; i++)
            {
                list.Add(CreatePostPanel(res[i][1], res[i][2], x, y));
                y += 250;
            }
            return list;
        }


        public Panel CreatePostPanel(string title, string content, int x, int y)
        {
            Panel panelContenuePost = new Panel();
            TextBox Titre = new TextBox();
            TextBox Contenue = new TextBox();

            // Panel settings
            panelContenuePost.Location = new Point(x, y);
            panelContenuePost.Controls.Add(Titre);
            panelContenuePost.Controls.Add(Contenue);
            panelContenuePost.Size = new Size(333, 254);
            panelContenuePost.BorderStyle = BorderStyle.FixedSingle;

            // Title settings
            Titre.Location = new Point(0, 3);
            Titre.Size = new Size(325, 23);
            Titre.Text = title;
            Titre.ReadOnly = true;

            // Content settings
            Contenue.Location = new Point(0, 32);
            Contenue.Multiline = true;
            Contenue.Size = new Size(325, 186);
            Contenue.Text = content;
            Contenue.ReadOnly = true;

            return panelContenuePost;
        }




        
    }
}
