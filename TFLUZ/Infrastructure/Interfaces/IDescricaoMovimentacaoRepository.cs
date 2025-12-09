using TFLUZ.Infrastructure.Models;

namespace TFLUZ.Infrastructure.Interfaces
{
    public interface IDescricaoMovimentacaoRepository
    {
        public Task<List<DescricaoMovimentacaoEntity>> ListarAsync();
        public Task<DescricaoMovimentacaoEntity> BuscarPorIdAsync(int id);
        public Task AdicionarAsync(DescricaoMovimentacaoEntity model);
    }
}
