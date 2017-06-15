using FotoDestinoApp.Dal;
using FotoDestinoApp.Intefaces;
using FotoDestinoApp.Model;
using PCLStorage;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FotoDestinoApp.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaFoto1 : ContentPage
    {
        private Position posicao;

        private String caminhoFoto;

        private double latitude;

        private double longitute;

        public PaginaFoto1()
        {
            InitializeComponent();
        }

        private async void btnAlbum(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Álbum não suportado", "Não existe permissão para acessar o álbum de fotos", "OK");
                return;
            }

            // Este método habilita a seleção de uma foto.
            var file = await CrossMedia.Current.PickPhotoAsync();
            // a variável file retorna com null no caso do usuário não ter selecionado uma foto
            if (file == null)
                return;

            pegarLocalizacao();
            imgFoto.Source = ImageSource.FromStream(() =>
            {
                
                var stream = file.GetStream();
                caminhoFoto = file.Path;
                file.Dispose();                
                return stream;
            });
        }

        private async void btnFoto(object sender, EventArgs e)
        {
            // Inicializar o componente para integrar com a máquina fotográfica
            await CrossMedia.Current.Initialize();

            // Verifica se a câmera está disponível e se tem suporte para tirar a foto
            if (!CrossMedia.Current.IsCameraAvailable ||
                !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Não existe câmera", "A câmera não está disponível.", "OK");
                return;
            }

            // Habilitar a câmera e informar os dados do arquivo a ser gerado.
            // Local de armazenamento, nome do arquivo e se é para slavar no album
            // de fotos
            var file = await CrossMedia.Current.TakePhotoAsync(new
                Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = FileSystem.Current.LocalStorage.Name,
                Name = "fotoTeste.jpg",
                SaveToAlbum = true
            });

            // Se o usuário não tirou a foto, a variável file estará com o valor nulo
            if (file == null)
                return;

            pegarLocalizacao();
            // O file.path retorna o local de gravação da foto.
            var caminhoArquivo = file.Path;
            // Recupera a foto e a atribui para a imagem criada na tela
            imgFoto.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                caminhoFoto = file.Path;
                file.Dispose();                
                return stream;
            });
        }

        private async void pegarLocalizacao() {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(1000);
                if (position == null)
                    return;
                //Modificar para o banco de dados.
                posicao = position;
                latitude = position.Latitude;
                longitute = position.Longitude;
                
            }
            catch (Exception ex)
            {
               // Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
            }            
        }

        private async void btnSalvar()
        {
            MBFotoDAL mbFotoDAL = new MBFotoDAL();
            MBFoto mbFoto = new MBFoto();
            mbFoto.pathFoto = caminhoFoto;
            mbFoto.latitude = latitude;
            mbFoto.longitude = longitute;

            try
            {
                mbFotoDAL.Add(mbFoto);
                lblLatitude.Text = "Deu certinho";
                
            }
            catch (Exception ex)
            {

            }

        }
    }
}