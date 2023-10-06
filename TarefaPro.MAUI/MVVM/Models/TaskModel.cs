using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;

namespace TarefaPro.MAUI.MVVM.Models
{
    public class TaskModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsReminder { get; set; }
        public string Color { get; set; }
        public DateTime DateEvent { get; set; }
        public DateTime DateTask { get; set; }
        public TimeSpan HourTask { get; set; }

        [ForeignKey(typeof(CategoryModel))]
        public int CategoryId { get; set; }                    
    }
}
