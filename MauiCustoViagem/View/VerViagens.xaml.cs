using MauiCustoViagem.Models;
using System.Collections.ObjectModel;
using System.Reflection.PortableExecutable;

namespace MauiCustoViagem.View;

public partial class VerViagens : ContentPage
{
    ObservableCollection<Models.Viagem> lista_viagens = new ObservableCollection<Models.Viagem>();
    public VerViagens()
	{
		InitializeComponent();
        lst_viagens.ItemsSource = lista_viagens;
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        double litro = lista_viagens.Sum(i => (i.Distancia / i.Rendimento));
        double soma = lista_viagens.Sum(i => (litro * i.Preco));
        string msg = $"O total é {soma:C}";
        DisplayAlert("Somatória", msg, "Fechar");
    }
    protected async override void OnAppearing()
    {
        if (lista_viagens.Count == 0)
        {
            List<Viagem> tmp = await App.Db.GetAll();
            foreach (Viagem p in tmp)
            {
                lista_viagens.Add(p);
            }
        } 
    }

    private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            MenuItem selecionado = (MenuItem)sender;
            Viagem v = selecionado.BindingContext as Viagem;

            bool confirm = await DisplayAlert("Tem certeza?", "Remover Pedagios", "Sim", "Cancelar");
            if (confirm)
            {
                await App.Db.Delete(v.Id);
                await DisplayAlert("Sucesso!", "Viagem removida", "OK");
                lista_viagens.Remove(v);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}