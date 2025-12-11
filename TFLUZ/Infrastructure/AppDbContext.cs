using Microsoft.EntityFrameworkCore;
using TFLUZ.Components.Shared;
using TFLUZ.Infrastructure.Configuration;
using TFLUZ.Infrastructure.Models;

namespace TFLUZ.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<MovimentacaoEntity> Movimentacoes { get; set; }
        public DbSet<DescricaoMovimentacaoEntity> DescricoesMovimentacao { get; set; }
        public DbSet<StatusMovimentacaoEntity> StatusMovimentacoes { get; set; }
        public DbSet<ClassificacaoMovimentacaoEntity> ClassificacaoMovimentacao { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovimentacaoConfiguration());
            modelBuilder.ApplyConfiguration(new DescricaoMovimentacaoConfiguration());
            modelBuilder.ApplyConfiguration(new StatusMovimentacaoConfiguration());
            modelBuilder.ApplyConfiguration(new ClassificacaoMovimentacaoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}