using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFLUZ.Infrastructure.Models;

namespace TFLUZ.Infrastructure.Configuration
{
    public class DescricaoMovimentacaoConfiguration : IEntityTypeConfiguration<DescricaoMovimentacaoEntity>
    {
        public void Configure(EntityTypeBuilder<DescricaoMovimentacaoEntity> builder)
        {
            builder.ToTable("DescricoesMovimentacao");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedOnAdd();

            builder.Property(d => d.Nome)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.HasIndex(d => d.Nome).IsUnique();
        }
    }
}
