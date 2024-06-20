using Treinaí.Models;

namespace Treinaí.Repositories.PlanoDeTreinoRepository
{
    public interface IPlanoDeTreinoRepository
    {
        Task<List<PlanoDeTreino>> GetAllAsync();
        Task AddAsync(PlanoDeTreino planoDeTreino);
        Task DeleteByIdAsync(int id);
        Task<PlanoDeTreino> GetByIdAsync(int id);
        Task<List<PlanoDeTreinoAnuais>?> GetReportAsync();
    }
}
