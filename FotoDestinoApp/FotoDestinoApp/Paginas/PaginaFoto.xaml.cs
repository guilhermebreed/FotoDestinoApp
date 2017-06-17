using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FotoDestinoApp.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaFoto : ContentPage
    {
        public PaginaFoto()
        {
            InitializeComponent();
        }
        private async void btnFoto(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaFoto1());
        }

        private async void btnCodigoBarra(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaFoto2());
        }

        private async void btnTeste(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaGetAll());
        }

        private async void btnPesquisa(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaPesquisa());
        }
    }
}