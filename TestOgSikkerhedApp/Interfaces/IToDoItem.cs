using TestOgSikkerhedApp.Data;

namespace TestOgSikkerhedApp.Interfaces
{
    public interface IToDoItem
    {
        Task<ToDoItem> CreateCprAsync(ToDoItem newItem);
        Task<ToDoItem> UpdateCprAsync(ToDoItem updateItem);
        Task<ToDoItem> DeleteCprAsync(ToDoItem deleteItem);
        Task<List<ToDoItem>> GetAll();
    }
}
