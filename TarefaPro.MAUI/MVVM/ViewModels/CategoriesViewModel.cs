using System.Collections.ObjectModel;
using TarefaPro.MAUI.MVVM.Models;

namespace TarefaPro.MAUI.MVVM.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        private ObservableCollection<CategoryModel> _categoriesCollection = new();
        public ObservableCollection<CategoryModel> CategoriesCollection
        {
            get => _categoriesCollection;
            set => SetProperty(ref _categoriesCollection, value);
        }


        private bool _hasCategories = false;
        public bool HasCategories
        {
            get => _hasCategories;
            set
            {
                SetProperty(ref _hasCategories, value);
                HasNotCategories = !value;
            }

        }


        private bool _hasNotCategories = false;
        public bool HasNotCategories
        {
            get => _hasNotCategories;
            set => SetProperty(ref _hasNotCategories, value);

        }
    


        public CategoriesViewModel()
        {
            PreencheList();
            CheckIfHasCategories();
        }


        private void PreencheList()
        {
           // Application.Current.Resources.TryGetValue("PrimarySalmon", out var labelStyle);

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

        private void CheckIfHasCategories()
        {
            HasCategories = CategoriesCollection.Count > 0 ? true : false;
        }
    }
}
