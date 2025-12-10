using AutoMapper;
using TFLUZ.Application.Interfaces;
using TFLUZ.Core.Models;
using TFLUZ.Infrastructure.Interfaces;
using TFLUZ.Infrastructure.Models;

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
        public async Task AdicionarAsync(Movimentacao model)
        {
            var _entity = _mapper.Map<MovimentacaoEntity>(model);
            await _repository.AdicionarAsync(_entity);
        }

        public async Task<Movimentacao> BuscarPorIdAsync(int id)
        {
            var _mov = await _repository.BuscarPorIdAsync(id);
            return _mapper.Map<Movimentacao>(_mov);
        }

        public async Task<List<Movimentacao>> ListarAsync()
        {
            var _mov = await _repository.ListarAsync();
            return _mapper.Map<List<Movimentacao>>(_mov);
        }
    }
}
