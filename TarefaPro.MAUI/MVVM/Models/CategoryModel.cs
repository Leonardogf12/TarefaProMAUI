using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarefaPro.MAUI.MVVM.Models
{
    public class CategoryModel : BaseModelPropertChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }       
        public string Color { get; set; }
        public string IconName { get; set; }
              
        [NotMapped]
        private int _countTaskies;
        public int CountTaskies
        {
            get => _countTaskies;
            set => SetProperty(ref _countTaskies, value);
        }
    }
}
