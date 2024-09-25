using Microsoft.EntityFrameworkCore;
using TestOgSikkerhedApp.Data;
using TestOgSikkerhedApp.Interfaces;
using TestOgSikkerhedApp.Server;

namespace TestOgSikkerhedApp.Repositories
{
    public class ToDoItemRepo : IToDoItem
    {
        private TodoItemContext _todoItemContext;
        public ToDoItemRepo(TodoItemContext todoItemContext)
        {
            this._todoItemContext = todoItemContext;
        }
        public async Task<ToDoItem> CreateTodoAsync(ToDoItem newItem)
        {
            try
            {
                _todoItemContext.ToDos.Add(newItem);
                await _todoItemContext.SaveChangesAsync();
                return newItem;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

        }

        public Task<ToDoItem> DeleteTodoAsync(ToDoItem deleteItem)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoItem>> GetAllTodo()
        {
            return _todoItemContext.ToDos.ToListAsync();
        }

        public Task<ToDoItem> UpdateTodoAsync(ToDoItem updateItem)
        {
            throw new NotImplementedException();
        }
    }
}
