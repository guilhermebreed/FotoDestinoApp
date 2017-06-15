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
using SQLite.Net.Platform.XamarinAndroid;
using FotoDestinoApp.Droid;
using FotoDestinoApp.Infra;
using SQLite.Net;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(ConexaoBancoDeDados))]
namespace FotoDestinoApp.Droid
{
    public class ConexaoBancoDeDados : IBancoDeDados
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "AppFotoGPS.db3";
            string documentsFolder = Android.OS.Environment.
                GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).
                AbsolutePath;
            //string documentsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsFolder, dbName);
            var platform = new SQLitePlatformAndroid();
            return new SQLiteConnection(platform, path, false);
        }
    }
}