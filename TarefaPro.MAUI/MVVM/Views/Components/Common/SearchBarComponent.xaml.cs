using Microsoft.Maui.Controls.Internals;
using TarefaPro.MAUI.MVVM.ViewModels;

namespace TarefaPro.MAUI.MVVM.Views.Components.Common;

public partial class SearchBarComponent : ContentView
{
    public string Contexto { get; }

    public SearchBarComponent(string Contexto)
	{
		InitializeComponent();
	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var currentPage = Contexto;        
    }
}