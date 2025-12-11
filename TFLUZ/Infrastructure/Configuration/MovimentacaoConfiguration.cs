using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFLUZ.Infrastructure.Models;

namespace TFLUZ.Infrastructure.Configuration
{
    public class MovimentacaoConfiguration : IEntityTypeConfiguration<MovimentacaoEntity>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoEntity> builder)
        {
            builder.ToTable("Movimentacoes");

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.Data).IsRequired();

            builder.Property(m => m.Valor)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(m => m.Observacao)
                   .HasMaxLength(500)
                   .IsRequired(false);

            // armazenamos  como int
            // relacionamento Movimentacao -> Classificacao(1:1)
            builder.HasOne(m => m.Classificacao)
                   .WithOne()
                   .HasForeignKey<ClassificacaoMovimentacaoEntity>(c => c.Id)
                   .OnDelete(DeleteBehavior.Restrict);


            // relacionamento Movimentacao -> Status (1:1)
            builder.HasOne(m => m.Status)
                   .WithOne()
                   .HasForeignKey<StatusMovimentacaoEntity>(s => s.Id)
                   .OnDelete(DeleteBehavior.Restrict);

            // relacionamento Movimentacao -> Descricao (1:1)
            builder.HasOne(m => m.Descricao)
                   .WithOne()
                   .HasForeignKey<DescricaoMovimentacaoEntity>(d => d.Id)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Ativo)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.HasIndex(m => m.Data);
        }
    }
}