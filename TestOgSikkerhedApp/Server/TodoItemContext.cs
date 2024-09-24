using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using TestOgSikkerhedApp.Data;

namespace TestOgSikkerhedApp.Server
{
    public class TodoItemContext : DbContext
    {
        public TodoItemContext(DbContextOptions<TodoItemContext> option) : base(option)
        {
            
        }
        public DbSet<ToDoItem> ToDos { get; set; }
        public DbSet<CprUser> Cprs { get; set; }
    }
}
