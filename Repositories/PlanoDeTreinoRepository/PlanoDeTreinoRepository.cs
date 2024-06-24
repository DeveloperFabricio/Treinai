using Microsoft.EntityFrameworkCore;
using Treinaí.Data;
using Treinaí.Models;

namespace Treinaí.Repositories.PlanoDeTreinoRepository
{
    public class PlanoDeTreinoRepository : IPlanoDeTreinoRepository
    {
        private readonly ApplicationDbContext _context;

        public PlanoDeTreinoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PlanoDeTreino planoDeTreino)
        {
            _context.PlanosDeTreino.Add(planoDeTreino);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var planoTreino = await GetByIdAsync(id);
            _context.PlanosDeTreino.Remove(planoTreino);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PlanoDeTreino>> GetAllAsync()
        {
            return await _context.PlanosDeTreino.Include(x => x.Aluno)
                .Include(x => x.Professor).AsNoTracking().ToListAsync();
        }

        public async Task<PlanoDeTreino> GetByIdAsync(int id)
        {
            return await _context.PlanosDeTreino.Include(x => x.Aluno)
                .Include(x => x.Professor).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PlanoDeTreinoAnuais>?> GetReportAsync()
        {
            var result = _context.Database.SqlQuery<PlanoDeTreinoAnuais>(
           ($"SELECT MONTH(DataTreino) AS Mes, COUNT(*) AS QuantidadePlanos FROM PlanosdeTreino WHERE YEAR(DataTreino) = {DateTime.Today.Year.ToString()} GROUP BY MONTH(DataTreino) ORDER BY Mes;"));
            return await Task.FromResult(result.ToList());
        }
    }
}
