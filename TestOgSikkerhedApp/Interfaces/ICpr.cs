using TestOgSikkerhedApp.Data;

namespace TestOgSikkerhedApp.Interfaces
{
    public interface ICpr
    {
        Task<CprUser> CreateCprAsync(CprUser newUser);
        Task<CprUser> UpdateCprAsync(CprUser updateUser);
        Task<CprUser> DeleteCprAsync(CprUser deleteUser);
        Task<List<CprUser>> GetAll();
    }
}
