using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FotoDestinoApp.Intefaces;
using Android.Graphics;
using Android.Util;
using Java.IO;

namespace FotoDestinoApp.Droid
{
    public class FileUtility : IFileUtility

    {

        public string SaveFile(string fileName, byte[] imageStream)

        {

            string path = null;

            string imageFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ProductImages");



            //Check if the folder exist or not

            if (!System.IO.Directory.Exists(imageFolderPath))

            {

                System.IO.Directory.CreateDirectory(imageFolderPath);

            }

            string imagefilePath = System.IO.Path.Combine(imageFolderPath, fileName);



            //Try to write the file bytes to the specified location.

            try

            {

                System.IO.File.WriteAllBytes(imagefilePath, imageStream);

                path = imagefilePath;

            }

            catch (System.Exception e)

            {

                throw e;

            }

            return path;

        }



        public void DeleteDirectory()

        {

            string imageFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ProductImages");

            if (System.IO.Directory.Exists(imageFolderPath))

            {

                System.IO.Directory.Delete(imageFolderPath, true);

            }

        }
        
    }
}