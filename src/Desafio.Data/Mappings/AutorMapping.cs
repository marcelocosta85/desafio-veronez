using Desafio.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Data.Mappings
{
    public class AutorMapping : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");
            builder.Property(a => a.DataNascimento)
                .IsRequired();
            builder.Property(a => a.PaisOrigem)
                .IsRequired()
                .HasColumnType("varchar(50)");
            builder.Property(a => a.CPF)
                .HasColumnType("varchar(11)");

            // 1 : N => Autor : Obras
            builder.HasMany(a => a.Obras)
                .WithOne(o => o.Autor)
                .HasForeignKey(o => o.AutorId);

            builder.ToTable("Autores");
        }
    }
}
