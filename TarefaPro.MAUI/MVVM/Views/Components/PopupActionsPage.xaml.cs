using CommunityToolkit.Maui.Views;
using TarefaPro.MAUI.Helpers.Components;
using TarefaPro.MAUI.MVVM.ViewModels;

namespace TarefaPro.MAUI.MVVM.Views.Components;

public partial class PopupActionsPage : Popup
{
    //ScaleUpScaleDownHelper scaleUpScaleDownHelper = new();

    public PopupActionsPage(PopupActionsViewModel popup)
	{
		InitializeComponent();

		BindingContext = popup;
	}

    //public async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    //{
    //    var vm = BindingContext as PopupActionsViewModel;

    //    var element = sender as Border;

    //    await scaleUpScaleDownHelper.SetScaleOnElement(element: element, scale: 0.8);

    //    vm.FirstExecuted = true;

    //   vm.SetSelectedCommand(e.Parameter);  
    //}

    //private async void TapGestureRecognizer_Tapped2(object sender, TappedEventArgs e)
    //{
    //    var vm = BindingContext as PopupActionsViewModel;

    //    var element = sender as Border;

    //    await scaleUpScaleDownHelper.SetScaleOnElement(element: element, scale: 0.8);

    //    vm.SecondExecuted = true;

    //    vm.SetSelectedCommand(e.Parameter);
    //}

    //private async void TapGestureRecognizer_Tapped3(object sender, TappedEventArgs e)
    //{
    //    var vm = BindingContext as PopupActionsViewModel;

    //    var element = sender as Border;

    //    await scaleUpScaleDownHelper.SetScaleOnElement(element: element, scale: 0.8);

    //    vm.ThirdExecuted = true;

    //    vm.SetSelectedCommand(e.Parameter);
    //}
}