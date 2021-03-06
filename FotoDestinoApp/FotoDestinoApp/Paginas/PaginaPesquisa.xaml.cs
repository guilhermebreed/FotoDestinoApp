﻿using FotoDestinoApp.Model;
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
    public partial class PaginaPesquisa : ContentPage
    {
        public static MBFoto imagem1 = new MBFoto();
        public static MBFoto imagem2 = new MBFoto();

        //True = imagem1 False = imagem2
        public static bool qualImagem;

        public PaginaPesquisa()
        {
            InitializeComponent();
        }

        public async void btnImagem1() {
            qualImagem = true;
            await Navigation.PushModalAsync(new PaginaGetAll());
            img1.Source = ImageSource.FromFile(imagem1.pathFoto);
        }

        public async void btnImagem2()
        {
            qualImagem = false;
            await Navigation.PushModalAsync(new PaginaGetAll());
            img2.Source = ImageSource.FromFile(imagem2.pathFoto);
        }
    }
}