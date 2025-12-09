using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TFLUZ.Core.Models;
using TFLUZ.Infrastructure.Interfaces;
using TFLUZ.Infrastructure.Models;

namespace TFLUZ.Infrastructure.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public MovimentacaoRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task AdicionarAsync(MovimentacaoEntity model)
        {
            var entity = _mapper.Map<MovimentacaoEntity>(model);
            _context.Movimentacoes.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<MovimentacaoEntity> BuscarPorIdAsync(int id)
        {
            return await _context.Movimentacoes
                .Include(x => x.Status)
                .Include(x => x.Descricao)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MovimentacaoEntity>> ListarAsync()
        {
            return await _context.Movimentacoes
                .Include(s => s.Status)
                .Include(x => x.Descricao)
                .ToListAsync();
        }
    }
}
