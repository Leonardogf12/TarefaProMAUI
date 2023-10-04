using System.Text.RegularExpressions;
using TarefaPro.MAUI.MVVM.ViewModels.Tasks;

namespace TarefaPro.MAUI.MVVM.Views.Tasks;

public partial class TaskiesPage : ContentPage
{
	public TaskiesPage(TaskiesViewModel model)
	{
		InitializeComponent();

		BindingContext = model;
	}

        
    private void PopupActions_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void RemoveAllTaskies_Clicked(object sender, EventArgs e)
    {

    }

    private async void AddTaskie_Clicked(object sender, EventArgs e)
    {
      var vm = BindingContext as TaskiesViewModel;

        vm.GotoAddTaskPage();
    }
   

    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as TaskiesViewModel;

        vm.OnAppearing();
    }
}