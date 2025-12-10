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

            // armazenamos Classificacao como int
            builder.Property(m => m.Classificacao)
                   .HasColumnName("Classificacao")
                   .IsRequired();

            // relacionamento Movimentacao -> Status (N:1)
            builder.HasOne(m => m.Status)
                   .WithMany()
                   .HasForeignKey(m => m.StatusId)
                   .OnDelete(DeleteBehavior.Restrict);

            // relacionamento Movimentacao -> Descricao (N:1)
            builder.HasOne(m => m.Descricao)
                   .WithMany()
                   .HasForeignKey(m => m.DescricaoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Ativo)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.HasIndex(m => m.Data);
        }
    }
}