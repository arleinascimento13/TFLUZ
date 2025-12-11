using TFLUZ.Core.Models;

namespace TFLUZ.Application.Interfaces
{
    public interface IDescricaoMovimentacaoService
    {
        public Task AdicionarAsync(DescricaoMovimentacao model);
        public Task<DescricaoMovimentacao> BuscarPorIdAsync(int id);
        public Task<List<DescricaoMovimentacao>> ListarAsync();
    }
}
