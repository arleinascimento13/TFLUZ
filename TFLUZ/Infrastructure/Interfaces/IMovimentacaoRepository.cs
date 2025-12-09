using TFLUZ.Core.Models;
using TFLUZ.Infrastructure.Models;

namespace TFLUZ.Infrastructure.Interfaces
{
    public interface IMovimentacaoRepository
    {
        public Task<List<MovimentacaoEntity>> ListarAsync();
        public Task<MovimentacaoEntity> BuscarPorIdAsync(int id);
        public Task AdicionarAsync(MovimentacaoEntity model);
    }
}
