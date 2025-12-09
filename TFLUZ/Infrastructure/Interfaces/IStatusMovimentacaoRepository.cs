using TFLUZ.Infrastructure.Models;

namespace TFLUZ.Infrastructure.Interfaces
{
    public interface IStatusMovimentacaoRepository
    {
        public Task<List<StatusMovimentacaoEntity>> ListarAsync();
        public Task<StatusMovimentacaoEntity> BuscarPorIdAsync(int id);
        public Task AdicionarAsync(StatusMovimentacaoEntity model);
    }
}
