using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarefaPro.MAUI.MVVM.Models
{
    public class CategoryModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }       
        public string Color { get; set; }
        public string IconName { get; set; }

        [NotMapped]
        public int CountTaskies { get; set; }
    }
}
