using Treinaí.Models;

namespace Treinaí.Repositories.AlunoRepository
{
    public interface IAlunoRepository
    {
        Task AddAsync(Aluno aluno);
        Task UpdateAsync(Aluno aluno);
        Task<List<Aluno>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task<Aluno?> GetByIdAsync(int id);
    }
}
