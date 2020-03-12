using Desafio.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Data.Mappings
{
    public class ObraMapping : IEntityTypeConfiguration<Obra>
    {
        public void Configure(EntityTypeBuilder<Obra> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");
            builder.Property(o => o.Descricao)
                .IsRequired()
                .HasColumnType("varchar(240)");

            builder.ToTable("Obras");
        }
    }
}
