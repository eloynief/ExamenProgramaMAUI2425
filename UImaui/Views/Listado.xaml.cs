namespace UImaui.Views;

public partial class Listado : ContentPage
{
	public Listado()
	{
		InitializeComponent();
    }
    private async void IrPaginaEditar(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Views//EditarPersona");
    }

}