using TestOgSikkerhedApp.Data;

namespace TestOgSikkerhedApp.Interfaces
{
    public interface IToDoItem
    {
        Task<ToDoItem> CreateTodoAsync(ToDoItem newItem);
        Task<ToDoItem> UpdateTodoAsync(ToDoItem updateItem);
        Task<ToDoItem> DeleteTodoAsync(ToDoItem deleteItem);
        Task<List<ToDoItem>> GetAllTodo();
    }
}
