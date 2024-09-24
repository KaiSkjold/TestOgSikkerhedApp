using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOgSikkerhedApp.Data
{
    public class ToDoItem 
    {
        [Key]
        public int itemId {  get; set; }
        public string itemName {  get; set; }
        public string userName { get; set; }

    }

}
