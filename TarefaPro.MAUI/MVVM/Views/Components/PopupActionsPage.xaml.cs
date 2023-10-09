using CommunityToolkit.Maui.Views;
using TarefaPro.MAUI.MVVM.ViewModels;

namespace TarefaPro.MAUI.MVVM.Views.Components;

public partial class PopupActionsPage : Popup
{ 
    public PopupActionsPage(PopupActionsViewModel popup)
	{
		InitializeComponent();

		BindingContext = popup;
	}

}