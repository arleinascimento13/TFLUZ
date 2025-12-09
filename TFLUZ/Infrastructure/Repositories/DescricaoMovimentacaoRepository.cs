using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TFLUZ.Core.Models;
using TFLUZ.Infrastructure.Interfaces;
using TFLUZ.Infrastructure.Models;

namespace TFLUZ.Infrastructure.Repositories
{
    public class DescricaoMovimentacaoRepository : IDescricaoMovimentacaoRepository
    {
        private readonly AppDbContext _context;
        public DescricaoMovimentacaoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AdicionarAsync(DescricaoMovimentacaoEntity model)
        {
            _context.DescricoesMovimentacao.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<DescricaoMovimentacaoEntity> BuscarPorIdAsync(int id)
        {
            return await _context.DescricoesMovimentacao.FindAsync(id);
        }

        public async Task<List<DescricaoMovimentacaoEntity>> ListarAsync()
        {
            return await _context.DescricoesMovimentacao.ToListAsync();
        }
    }
}
