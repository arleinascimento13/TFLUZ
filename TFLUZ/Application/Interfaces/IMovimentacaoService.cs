using TFLUZ.Core.Models;

namespace TFLUZ.Application.Interfaces
{
    public interface IMovimentacaoService
    {
        public Task AdicionarAsync(Movimentacao model);
        public Task<Movimentacao> BuscarPorIdAsync(int id);
        public Task<List<Movimentacao>> ListarAsync();
    }
}
