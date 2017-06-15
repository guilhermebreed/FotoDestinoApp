using FotoDestinoApp.Dal;
using FotoDestinoApp.Paginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FotoDestinoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            BancoDeDadosDAL bDal = new BancoDeDadosDAL();
            bDal.CriarTabelas();
            MainPage = new NavigationPage(new PaginaFoto());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
