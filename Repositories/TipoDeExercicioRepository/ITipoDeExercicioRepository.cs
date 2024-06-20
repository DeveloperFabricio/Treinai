using Treinaí.Models;

namespace Treinaí.Repositories.TipoDeExercicioRepository
{
    public interface ITipoDeExercicioRepository
    {
        Task<List<TipoDeExercicio>> GetAllAsync();
    }
}
