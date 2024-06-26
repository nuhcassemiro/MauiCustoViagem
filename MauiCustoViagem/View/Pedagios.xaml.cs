using MauiCustoViagem.Models;
using System.Collections.ObjectModel;

namespace MauiCustoViagem.View;

public partial class Pedagios : ContentPage
{
    ObservableCollection<Models.Viagem> lista_viagens = new ObservableCollection<Models.Viagem>();
    public Pedagios()
	{
		InitializeComponent();
        lst_viagens.ItemsSource = lista_viagens;
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        double litro = lista_pedagios.Sum(i => (i.Distancia / i.Rendimento));
        double soma = lista_pedagios.Sum(i => (litro * i.Preco));
        string msg = $"O total � {soma:C}";
        DisplayAlert("Somat�ria", msg, "Fechar");
    }

    protected async override void OnAppearing()
    {
        if (lista_pedagios.Count == 0)
        {
            List<Pedagio> tmp = await App.Db.GetAll();
            foreach (Pedagio p in tmp)
            {
                lista_pedagios.Add(p);
            }
        } // Fecha if
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
            Pedagio p = selecionado.BindingContext as Pedagio;

            bool confirm = await DisplayAlert("Tem certeza?", "Remover Pedagios", "Sim", "Cancelar");
            if (confirm)
            {
                await App.Db.Delete(p.Id);
                await DisplayAlert("Sucesso!", "Pedagio Removido", "OK");
                lista_pedagios.Remove(p);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}