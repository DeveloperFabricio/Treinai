using Microsoft.EntityFrameworkCore;
using Treinaí.Data;
using Treinaí.Models;

namespace Treinaí.Repositories.TipoDeExercicioRepository
{
    public class TipoDeExercicioRepository : ITipoDeExercicioRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoDeExercicioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TipoDeExercicio>> GetAllAsync()
        {
            return await _context.TiposDeExercicio.AsNoTracking().ToListAsync();
        }
    }
}
