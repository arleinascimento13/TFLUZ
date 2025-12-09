using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFLUZ.Infrastructure.Models;

namespace TFLUZ.Infrastructure.Configuration
{
    public class StatusMovimentacaoConfiguration : IEntityTypeConfiguration<StatusMovimentacaoEntity>
    {
        public void Configure(EntityTypeBuilder<StatusMovimentacaoEntity> builder)
        {
            builder.ToTable("StatusMovimentacoes");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.Nome)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.HasIndex(s => s.Nome).IsUnique();
        }
    }
}