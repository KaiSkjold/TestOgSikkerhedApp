using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOgSikkerhedApp.Data
{
    public class CprUser
    {
        [Key]
        public int cprId { get; set; }

        public int cprNum { get; set; }
        public string userName { get; set; }

        public List<ToDoItem> toDoItems { get; set; }
    }

}
