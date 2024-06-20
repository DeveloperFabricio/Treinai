using Treinaí.Models;

namespace Treinaí.Repositories.ProfessorRepository
{
    public interface IProfessorRepository
    {
        Task AddAsync(Professor professor);
        Task UpdateAsync(Professor professor);
        Task<List<Professor>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task<Professor?> GetByIdAsync(int id);
    }
}
