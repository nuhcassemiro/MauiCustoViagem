using System.Collections.ObjectModel;

namespace MauiCustoViagem.View;

public partial class Pedagios : ContentPage
{
    ObservableCollection<Models.Pedagio> lista_pedagios = new ObservableCollection<Models.Pedagio>();
    public Pedagios()
	{
		InitializeComponent();
        lst_pedagios.ItemsSource = lista_pedagios;
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        double soma = lista_pedagios.Sum(i => (i.Distancia * i.Rendimento * i.Preco));
        string msg = $"O total é {soma:C}";
        DisplayAlert("Somatória", msg, "Fechar");
    }

    private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    /*protected async override void OnAppearing()
    {
        if (lista_pedagios.Count == 0)
        {
            List<Models.Pedagio> tmp = await App.Db.GetAll();
            foreach (Models.Pedagio p in tmp)
            {
                lista_pedagios.Add(p);
            }
        }
    }*/
}