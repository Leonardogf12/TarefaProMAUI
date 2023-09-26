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

        [NotMapped]
        public Color ColorName { get; set; }
    }
}
