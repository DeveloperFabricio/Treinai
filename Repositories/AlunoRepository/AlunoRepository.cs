using Microsoft.EntityFrameworkCore;
using Treinaí.Data;
using Treinaí.Models;

namespace Treinaí.Repositories.AlunoRepository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly ApplicationDbContext _context;

        public AlunoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var aluno = await GetByIdAsync(id);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Aluno>> GetAllAsync()
        {
            return await _context.Alunos.AsNoTracking().ToListAsync();
        }

        public async Task<Aluno?> GetByIdAsync(int id)
        {
            return await _context.Alunos.SingleOrDefaultAsync(x => x.Id == id);            
        }

        public async Task UpdateAsync(Aluno aluno)
        {
            _context.Update(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
