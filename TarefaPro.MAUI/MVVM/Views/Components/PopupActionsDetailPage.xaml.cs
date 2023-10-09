using CommunityToolkit.Maui.Views;
using TarefaPro.MAUI.MVVM.ViewModels;

namespace TarefaPro.MAUI.MVVM.Views.Components;

public partial class PopupActionsDetailPage : Popup
{
	public PopupActionsDetailPage(PopupActionsDetailViewModel popup)
    {
        InitializeComponent();

        BindingContext = popup;
    }
}