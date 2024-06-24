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
            try
            {
                _context.Professores.Add(professor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Tratar exceção de concorrência (opcional)
                _context.ChangeTracker.Clear();
                throw new Exception("Ocorreu um erro de concorrência ao salvar o professor.", ex);
            }
            catch (DbUpdateException ex)
            {
                // Tratar exceção de falha no update
                _context.ChangeTracker.Clear();
                throw new Exception("Ocorreu um erro ao atualizar o banco de dados ao salvar o professor.", ex);
            }
            catch (Exception ex)
            {
                // Limpar o ChangeTracker e relançar exceção geral
                _context.ChangeTracker.Clear();
                throw new Exception("Ocorreu um erro ao salvar o professor.", ex);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var aluno = await GetByIdAsync(id);
            _context.Professores.Remove(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Professor>> GetAllAsync()
        {
            return await _context.Professores.Include(x => x.TipoDeExercicio).AsNoTracking().ToListAsync();
        }

        public async Task<Professor?> GetByIdAsync(int id)
        {
            return await _context.Professores.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Professor professor)
        {
            try
            {
                _context.Update(professor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                throw ex;
            }
        }
    }
}
