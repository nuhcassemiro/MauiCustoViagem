using MauiCustoViagem.Models;
using static System.Net.Mime.MediaTypeNames;

namespace MauiCustoViagem.View;

public partial class NovoPedagio : ContentPage
{
	public NovoPedagio()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        /*double litro = double.Parse(txt_distancia.Text) / double.Parse(txt_rendimento.Text);
          double soma = lista_viagens.Sum(i => (litro * i.Preco));
          double pedagio = double.Parse(txt_pedagio.Text) + (soma);
          string msg = $"O total é {soma:C}";

          await DisplayAlert("Viagem inserida", msg, "Fechar");*/
    }

    private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            PedagioModel p = new PedagioModel
            {
                Local = txt_local.Text,
                Valor = Convert.ToDouble(txt_valor.Text)
            };

            await App.DbPedagio.Insert(p);

            await DisplayAlert("Tudo Certo", "Pedágio Inserido", "Fechar");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}