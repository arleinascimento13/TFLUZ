using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TFLUZ.Core.Models;
using TFLUZ.Infrastructure.Interfaces;
using TFLUZ.Infrastructure.Models;

namespace TFLUZ.Infrastructure.Repositories
{
    public class StatusMovimentacaoRepository : IStatusMovimentacaoRepository
    {
        private readonly AppDbContext _context;
        public StatusMovimentacaoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AdicionarAsync(StatusMovimentacaoEntity model)
        {
            _context.StatusMovimentacoes.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<StatusMovimentacaoEntity> BuscarPorIdAsync(int id)
        {
            return await _context.StatusMovimentacoes.FindAsync(id);
        }

        public async Task<List<StatusMovimentacaoEntity>> ListarAsync()
        {
            return await _context.StatusMovimentacoes.ToListAsync();
        }
    }
}
