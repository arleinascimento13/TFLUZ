using AutoMapper;
using TFLUZ.Application.Interfaces;
using TFLUZ.Core.Models;
using TFLUZ.Infrastructure.Interfaces;

namespace TFLUZ.Application.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        public readonly IMovimentacaoRepository _repository;
        public readonly IStatusMovimentacaoRepository _statusRepository;
        public readonly IDescricaoMovimentacaoRepository _descricaoRepository;
        public readonly IMapper _mapper;
        public MovimentacaoService(
            IMovimentacaoRepository repository,
            IStatusMovimentacaoRepository statusRepository,
            IDescricaoMovimentacaoRepository descricaoRepository,
            IMapper mapper)
        {
            _repository = repository;
            _statusRepository = statusRepository;
            _descricaoRepository = descricaoRepository;
            _mapper = mapper;
        }
        public Task AdicionarAsync(Movimentacao model)
        {
            throw new NotImplementedException();
        }

        public Task<Movimentacao> BuscarPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movimentacao>> ListarAsync()
        {
            var _mov = await _repository.ListarAsync();
            return _mapper.Map<List<Movimentacao>>(_mov);
        }
    }
}
