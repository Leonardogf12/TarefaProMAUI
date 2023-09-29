using CommunityToolkit.Maui.Views;
using TarefaPro.MAUI.MVVM.ViewModels.Components.Common;

namespace TarefaPro.MAUI.MVVM.Views.Components.Common;

public partial class PopupCategoriesPage : Popup
{
	public PopupCategoriesPage(PopupCategoriesViewModel popup)
	{
		InitializeComponent();

		BindingContext = popup;
	}
}