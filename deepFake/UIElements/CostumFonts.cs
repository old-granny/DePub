using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace deepFake.UIElements
{
    public static class CostumFonts
    {
        private static PrivateFontCollection customFonts = new PrivateFontCollection();
        private static bool isFontLoaded = false;

        public static Font LoadCustomFont(float size)
        {
            if (!isFontLoaded)
            {
                var assembly = Assembly.GetExecutingAssembly();
                // Remplacez ce nom par celui obtenu avec GetManifestResourceNames()
                string resourceName = "deepFake.Fonts.Volkhov-Regular.ttf";
                using (Stream fontStream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (fontStream == null)
                        throw new Exception($"Font resource '{resourceName}' not found! Vérifiez le nom de la ressource.");

                    byte[] fontData = new byte[fontStream.Length];
                    fontStream.Read(fontData, 0, fontData.Length);

                    IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                    try
                    {
                        Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                        customFonts.AddMemoryFont(fontPtr, fontData.Length);
                        isFontLoaded = true;
                    }
                    finally
                    {
                        Marshal.FreeCoTaskMem(fontPtr);
                    }
                }
            }

            if (customFonts.Families.Length == 0)
                throw new Exception("Aucune famille de police chargée.");

            return new Font(customFonts.Families[0], size, FontStyle.Regular);
        }
    }
}