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
    public partial class PaginaFoto2 : ContentPage
    {
        public PaginaFoto2()
        {
            InitializeComponent();
            lblCodigo.Text = "";
        }

        private void btnLerCodigo(object sender, EventArgs e)
        {
            try
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                scanner.Scan().ContinueWith(
                    t =>
                    {
                        if (t.Result != null)
                        {
                            lblCodigo.Text = t.Result.ToString();
                        }
                        else
                        {
                            if (t.IsCanceled)
                            {
                                lblCodigo.Text = "";
                            }
                            else
                            {
                                if (t.IsFaulted)
                                {
                                    lblCodigo.Text = "";
                                }
                            }
                        }

                    });
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }

        }
    }
}