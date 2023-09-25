using System.Collections.ObjectModel;
using TarefaPro.MAUI.MVVM.Models;

namespace TarefaPro.MAUI.MVVM.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        private ObservableCollection<CategoryModel> _categoriesCollection = new();
        public ObservableCollection<CategoryModel> CategoriesCollection
        {
            get=>_categoriesCollection;
            set => SetProperty(ref _categoriesCollection, value);
        }


        public CategoriesViewModel()
        {
            PreencheList();
        }

        private void PreencheList()
        {
           var list = new List<CategoryModel>
           {
               new CategoryModel
               {
                   Id = 1,
                   Name = "Foo",
                   Description =  "Bar",
               },
               new CategoryModel
               {
                   Id = 2,
                   Name = "Too",
                   Description =  "Ber",
               },
               new CategoryModel
               {
                   Id = 2,
                   Name = "Too",
                   Description =  "Ber",
               },
               new CategoryModel
               {
                   Id = 2,
                   Name = "Too",
                   Description =  "Ber",
               },
               new CategoryModel
               {
                   Id = 2,
                   Name = "Too",
                   Description =  "Ber",
               },
               new CategoryModel
               {
                   Id = 2,
                   Name = "Too",
                   Description =  "Ber",
               },
               new CategoryModel
               {
                   Id = 2,
                   Name = "Too",
                   Description =  "Ber",
               },
               new CategoryModel
               {
                   Id = 2,
                   Name = "Too",
                   Description =  "Ber",
               },
               new CategoryModel
               {
                   Id = 2,
                   Name = "Too",
                   Description =  "Ber",
               },
               new CategoryModel
               {
                   Id = 2,
                   Name = "Too",
                   Description =  "Ber",
               },
               new CategoryModel
               {
                   Id = 2,
                   Name = "Too",
                   Description =  "Ber",
               },
               new CategoryModel
               {
                   Id = 2,
                   Name = "Too",
                   Description =  "Ber",
               },
               new CategoryModel
               {
                   Id = 2,
                   Name = "Too",
                   Description =  "Ber",
               },
           };

            list.ForEach(x =>
            {
                CategoriesCollection.Add(x);
            });
        }
    }
}
