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
        public Task<ToDoItem> CreateCprAsync(ToDoItem newItem)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItem> DeleteCprAsync(ToDoItem deleteItem)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoItem>> GetAll()
        {
            return _todoItemContext.ToDos.ToListAsync();
        }

        public Task<ToDoItem> UpdateCprAsync(ToDoItem updateItem)
        {
            throw new NotImplementedException();
        }
    }
}
