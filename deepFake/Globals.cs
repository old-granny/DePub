using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace deepFake
{
    static internal class Globals
    {
        public static bool FlagChanger { get; set; }
        public static bool AppRunning {  get; set; }
    }

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
    }
}
