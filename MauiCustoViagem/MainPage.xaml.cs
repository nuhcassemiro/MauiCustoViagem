using System.Collections.ObjectModel;
using MauiCustoViagem.Models;

namespace MauiCustoViagem
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.Pedagios());
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                Pedagio p = new Pedagio
                {
                    Origem = txt_origem.Text,
                    Destino = txt_destino.Text,
                    Distancia = Convert.ToDouble(txt_distancia.Text),
                    Rendimento = Convert.ToDouble(txt_rendimento.Text),
                    Preco = Convert.ToDouble(txt_preco.Text),
                };
                await App.Db.Insert(p);
                await DisplayAlert("Sucesso!", "Produto inserido", "OK");
                await Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }

}
