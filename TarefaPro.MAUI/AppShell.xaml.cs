using TarefaPro.MAUI.MVVM.Views.Category;
using TarefaPro.MAUI.MVVM.Views.Tasks;

namespace TarefaPro.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute(nameof(EditCategoryPage), typeof(EditCategoryPage));
            Routing.RegisterRoute(nameof(TaskiesPage), typeof(TaskiesPage));
            Routing.RegisterRoute(nameof(AddTaskPage), typeof(AddTaskPage));
            Routing.RegisterRoute(nameof(EditTaskPage), typeof(EditTaskPage));
        }
    }
}