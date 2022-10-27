using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;

namespace RCOTruckApp.StaticServices
{
    internal static class GenericService
    {
        internal static IBaseTheme GetAppTheme()
        {
            if (Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["DarkAppTheme"]))
            {
                return Theme.Dark;
            }
            else
            {
                return Theme.Light;
            }
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static byte[] PadLines(byte[] bytes, int rows, int columns)
        {
            int currentStride = columns; // 3
            int newStride = columns;  // 4
            byte[] newBytes = new byte[newStride * rows];
            for (int i = 0; i < rows; i++)
                Buffer.BlockCopy(bytes, currentStride * i, newBytes, newStride * i, currentStride);
            return newBytes;
        }

        public static string[] PropertiesFromType(object atype)
        {
            if (atype == null) return new string[] { };
            Type t = atype.GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            List<string> propNames = new List<string>();
            foreach (System.Reflection.PropertyInfo prp in props)
            {
                propNames.Add(prp.Name);
            }
            return propNames.ToArray();
        }
    }
}
