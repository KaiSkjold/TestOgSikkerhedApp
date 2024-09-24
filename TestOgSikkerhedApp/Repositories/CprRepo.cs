using Microsoft.EntityFrameworkCore;
using TestOgSikkerhedApp.Data;
using TestOgSikkerhedApp.Interfaces;
using TestOgSikkerhedApp.Server;

namespace TestOgSikkerhedApp.Repositories
{
    public class CprRepo : ICpr
    {
        private TodoItemContext _todoItemContext;
        public CprRepo(TodoItemContext todoItemContext)
        {
            this._todoItemContext = todoItemContext;
        }
        public async Task<CprUser> CreateCprAsync(CprUser newUser)
        {
            _todoItemContext.Cprs.Add(newUser);
            await _todoItemContext.SaveChangesAsync();
            return newUser;
        }

        public Task<CprUser> DeleteCprAsync(CprUser deleteUser)
        {
            throw new NotImplementedException();
        }

        public TodoItemContext Get_todoItemContext()
        {
            return _todoItemContext;
        }

        public Task<List<CprUser>> GetAllCpr()
        {
            return _todoItemContext.Cprs.ToListAsync();
        }

        public Task<CprUser> UpdateCprAsync(CprUser updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
