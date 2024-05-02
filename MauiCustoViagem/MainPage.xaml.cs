﻿using System.Collections.ObjectModel;
using MauiCustoViagem.Models;

namespace MauiCustoViagem
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Models.Viagem> lista_viagens = new ObservableCollection<Models.Viagem>();
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.VerViagens());
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                Viagem v = new Viagem
                {
                    Origem = txt_origem.Text,
                    Destino = txt_destino.Text,
                    Distancia = Convert.ToDouble(txt_distancia.Text),
                    Rendimento = Convert.ToDouble(txt_rendimento.Text),
                    Preco = Convert.ToDouble(txt_preco.Text),
                };
                await App.Db.Insert(v);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }

            double litro = double.Parse(txt_distancia.Text) / double.Parse(txt_rendimento.Text);
            double soma = lista_viagens.Sum(i => (litro * i.Preco));
            string msg = $"O total é {soma:C}";
            DisplayAlert("Viagem inserida", msg, "Fechar");
        }
    }

}
