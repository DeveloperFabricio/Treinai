using Microsoft.EntityFrameworkCore;
using Treinaí.Data;
using Treinaí.Models;

namespace Treinaí.Repositories.ProfessorRepository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfessorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Professor professor)
        {
            _context.Professores.Add(professor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var aluno = await GetByIdAsync(id);
            _context.Professores.Remove(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Professor>> GetAllAsync()
        {
            return await _context.Professores.AsNoTracking().ToListAsync();
        }

        public async Task<Professor?> GetByIdAsync(int id)
        {
            return await _context.Professores.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Professor professor)
        {
            _context.Update(professor);
            await _context.SaveChangesAsync();
        }
    }
}
