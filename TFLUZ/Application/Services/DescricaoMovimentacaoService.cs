using AutoMapper;
using NuGet.Protocol.Core.Types;
using TFLUZ.Application.Interfaces;
using TFLUZ.Core.Models;
using TFLUZ.Infrastructure.Interfaces;
using TFLUZ.Infrastructure.Models;

namespace TFLUZ.Application.Services
{
    public class DescricaoMovimentacaoService : IDescricaoMovimentacaoService
    {
        private readonly IDescricaoMovimentacaoRepository _repository;
        private readonly IMapper _mapper;
        public DescricaoMovimentacaoService(IDescricaoMovimentacaoRepository descricaoMovimentacaoRepository, IMapper mapper) {
            _repository = descricaoMovimentacaoRepository;
            _mapper = mapper;
        }

        public async Task AdicionarAsync(DescricaoMovimentacao model)
        {
            var desc = _mapper.Map<DescricaoMovimentacaoEntity>(model);
            await _repository.AdicionarAsync(desc);
        }

        public async Task<DescricaoMovimentacao> BuscarPorIdAsync(int id)
        {
            var desc = await _repository.BuscarPorIdAsync(id);
            return _mapper.Map<DescricaoMovimentacao>(desc);
        }

        public async Task<List<DescricaoMovimentacao>> ListarAsync()
        {
            var desc = await _repository.ListarAsync();
            return _mapper.Map<List<DescricaoMovimentacao>>(desc);
        }
    }
}
