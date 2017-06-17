using FotoDestinoApp.Dal;
using FotoDestinoApp.Model;
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
    public partial class PaginaGetAll : ContentPage
    {
        MBFotoDAL mbFotoDAL = new MBFotoDAL();

        public PaginaGetAll()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lvFotos.ItemsSource = mbFotoDAL.GetAll();
        }

        private void lvFotos_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (PaginaPesquisa.qualImagem)
            {
                PaginaPesquisa.imagem1 = (MBFoto)e.SelectedItem;
            }
            else
            {
                PaginaPesquisa.imagem2 = (MBFoto)e.SelectedItem;
            }

            Navigation.PopModalAsync(true);
        }
    }
}