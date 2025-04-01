using deepFake.Elements;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace deepFake
{
    /// <summary>
    /// The class Globals contains Global variable, so the instance will be static,
    /// so variable can change and other are const
    /// </summary>
    static internal class Globals
    {
        public static bool FlagChanger { get; set; }
        public static bool AppRunning {  get; set; }
        
        // Constante Global
        public const int MinimumPasswordCount = 10; 
        public const int MaximumPasswordCount = 50;
        
        public const int MinimumUsernameCount = 5;
        public const int MaximumUsernameCount = 25;

        public const int MaximumEmailCount = 100;

        public const int MinimumNameCount = 2;
        public const int MaximumNameCount = 20;

        public const int MinimumPrenameCount = 2;
        public const int MaximumPrenameCount = 20;


    }

    /// <summary>
    /// The Algorithme class will contain multitude of fonction that will be static and can be reusse in mulitple places
    /// </summary>
    static internal class Algorithme
    {
        /// <summary>
        /// Fonction de validation des données
        /// </summary>
        /// <param name="title"> le titre </param>
        /// <param name="content"> le contenue </param>
        /// <param name="img0"> image en byte</param>
        /// <param name="img1"> image en byte </param>
        /// <param name="img2"> image en byte </param>
        /// <returns> true si les donnees securitere sinon false </returns>
        public static bool IsPostDataSecure(string title, string content, byte[] img0, byte[] img1, byte[] img2)
        {
            // Vérifier si les champs ne sont pas vides ou trop longs
            if (string.IsNullOrWhiteSpace(title) || title.Length > 255)
                return false;

            if (string.IsNullOrWhiteSpace(content) || content.Length > 10000) // Augmenté pour permettre du texte long
                return false;

            // Vérifier la présence de caractères "bizarres" qui pourraient causer des bugs (ex: null byte)
            if (title.Contains('\0') || content.Contains('\0'))
                return false;


            // Vérifier la taille des images (éviter des fichiers trop volumineux)
            const int maxImageSize = 16_777_210; // 16 Mo par image
            if ((img0 != null && img0.Length > maxImageSize) ||
                 (img1 != null && img1.Length > maxImageSize) ||
                 (img2 != null && img2.Length > maxImageSize))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Will check whenever the use want to signing
        /// </summary>
        /// <param name="username"> the username </param>
        /// <param name="password"> the password </param>
        /// <returns> if the param are secure true if not false</returns>
        static public bool VerifySigningParam(string username, string password)
        {
            // look if the size of the username is correct
            if (string.IsNullOrWhiteSpace(username) || username.Length > Globals.MaximumUsernameCount || username.Length < Globals.MinimumUsernameCount)
                return false;

            // Check if the lenght of the password is okey
            if (string.IsNullOrWhiteSpace(password) || password.Length > Globals.MaximumPasswordCount || username.Length < Globals.MinimumPasswordCount)
                return false;

            // Prevent SQL injection using Regex
            string forbiddenPattern = @"(--|;|/\*|\*/|=|['""\\]|xp_|exec|union|select|insert|delete|update|drop|truncate|alter|create|shutdown|grant|revoke)";
            if (Regex.IsMatch(username, forbiddenPattern, RegexOptions.IgnoreCase) ||
                Regex.IsMatch(password, forbiddenPattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            return true; // everything was secure
        }

        static public bool IsSignUpParamSecure(string username, string name, string prename, string email, string password, string date)
        {
            // Validate username length
            if (string.IsNullOrWhiteSpace(username) || username.Length < Globals.MinimumUsernameCount || username.Length > Globals.MaximumUsernameCount)
                return false;

            // Validate password length
            if (string.IsNullOrWhiteSpace(password) || password.Length < Globals.MinimumPasswordCount || password.Length > Globals.MaximumPasswordCount)
                return false;

            // Validate name length
            if (string.IsNullOrWhiteSpace(name) || name.Length < Globals.MinimumNameCount || name.Length > Globals.MaximumNameCount)
                return false;

            // Validate prename length
            if (string.IsNullOrWhiteSpace(prename) || prename.Length < Globals.MinimumPrenameCount || prename.Length > Globals.MaximumPrenameCount)
                return false;

            // Validate email length and format
            if (string.IsNullOrWhiteSpace(email) || email.Length > Globals.MaximumEmailCount || !IsValidEmail(email))
                return false;

            // Validate date format
            if (string.IsNullOrWhiteSpace(date))
                return false;

            // Prevent SQL injection using Regex
            string forbiddenPattern = @"(--|;|/\*|\*/|=|['""\\]|xp_|exec|union|select|insert|delete|update|drop|truncate|alter|create|shutdown|grant|revoke)";
            if (Regex.IsMatch(username, forbiddenPattern, RegexOptions.IgnoreCase) ||
                Regex.IsMatch(password, forbiddenPattern, RegexOptions.IgnoreCase) ||
                Regex.IsMatch(name, forbiddenPattern, RegexOptions.IgnoreCase) ||
                Regex.IsMatch(prename, forbiddenPattern, RegexOptions.IgnoreCase) ||
                Regex.IsMatch(email, forbiddenPattern, RegexOptions.IgnoreCase) ||
                Regex.IsMatch(date, forbiddenPattern, RegexOptions.IgnoreCase))
            {
                return false;
            }

            return true; // Everything is secure
        }

        // Helper function to validate email format
        static public bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }





        /// <summary>
        /// The fonction will hash the password using SHA256
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns> hashed string </returns>
        public static string HashPassword(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        //helper Fonction
        private static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string StringToLinedString(string inputString, int maxCharLine)
        {
            StringBuilder sb = new StringBuilder();
            int pos = 0;
            int nbCharAdded = 0;
            while (sb.Length < inputString.Length)
            {
                sb.Append(inputString[pos]);
                if (inputString[pos] == '\n')
                {
                    nbCharAdded = 0;
                }
                if (nbCharAdded % maxCharLine == 0 && nbCharAdded != 0)
                {
                    sb.Append('\n');
                }
                pos += 1;
                nbCharAdded += 1;
            }
            if (pos % maxCharLine != 0)
                sb.Append('\n');
            string final = sb.ToString();
            return final;
        }

        public static float DistanceBetween2Point(Point pt1, Point pt2)
        {
            int dx = pt2.X - pt1.X;
            int dy = pt2.Y - pt1.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        public static int GetMaxFx(int maxFx) {
            if (maxFx <= 610) return 0;  // Below a threshold, return 0
            return (int)Math.Round(-1.03125f * maxFx + 837.1875f);
        }


        /// <summary>
        /// Checks if any part of to_check is within original.
        /// </summary>
        /// <param name="original">The original control.</param>
        /// <param name="to_check">The control to check.</param>
        /// <returns>True if any part of to_check is within original, otherwise false.</returns>
        public static bool IsWithinControl(Control original, Control to_check)
        {
            if (to_check == null || original == null) return false;

            Rectangle originalBounds = new Rectangle(original.Location, original.Size);
            Rectangle toCheckBounds = new Rectangle(to_check.Location, to_check.Size);

            return originalBounds.IntersectsWith(toCheckBounds);
        }

        /// <summary>
        /// Check if control Y is higher (so lower on the UI) than the check
        /// </summary>
        /// <param name="ctrl1">the element</param>
        /// <param name="to_check"> if this element is under ctrl1 than true, else false</param>
        /// <returns></returns>
        public static bool isUnderControl(Control ctrl1, Control to_check)
        {
            if (ctrl1.Location.Y < to_check.Location.Y) return true;
            else return false;
        }


        public static List<Control> OrderListWithLocation(List<Control> controls)
        {
            return controls.OrderBy(c => c.Location.Y).ThenBy(c => c.Location.X).ToList();
        }

        public static List<DraggablePanel> OrderListWithLocation(List<DraggablePanel> draggablePanels)
        {
            return draggablePanels.OrderBy(c => c.Location.Y).ToList();
        }
        public static Control OverWith(Control original, List<DraggablePanel> to_check, int range)
        {
            Control panelOver = null;
            foreach (Control panel in to_check)
            {
                if (panel != original)
                {
                    if (Algorithme.IsWithinControl(original, panel))
                    {
                        panelOver = panel; break;
                    }
                }
            }
            return panelOver;
        }

        public static Control OverWith(Control original, List<Control> to_check, int range)
        {
            Control panelOver = null;
            foreach (Control panel in to_check)
            {
                if (panel != original)
                {
                    if (Algorithme.IsWithinControl(original, panel))
                    {
                        panelOver = panel; break;
                    }
                }
            }
            return panelOver;
        }

        

    }

    internal class Stack<T>
    {
        List<T> list;
        public Stack()
        {
            list = new List<T>();
        }


        public void Push(T item) { 
            list.Add(item);
        }

        public void Pop() {
            if (list.Count > 0)
            {
                T element = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
            }
        }

        public T GetValue(int index) { 
            return list[index];
        }

    }
}
