using LivrosApp.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrosApp.Infra.DATA.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("LIVRO");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(l => l.Titulo)
                .HasColumnName("TITULO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(l => l.Autor)
                .HasColumnName("AUTOR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(l => l.Genero)
                .HasColumnName("GENERO")
                .HasConversion<int>()
                .IsRequired();

            builder.Property(l => l.AnoDePublicacao)
                .HasColumnName("ANODEPUBLICACAO")
                .IsRequired();

            builder.Property(l => l.Disponibilidade)
                .HasColumnName("DISPONIBILIDADE")
                .IsRequired();

            builder.Property(l => l.Ativo)
                .HasColumnName("ATIVO")
                .IsRequired();

            builder.Property(l => l.DataInclusao)
               .HasColumnName("DATAINCLUSAO")
               .IsRequired(false);

            builder.Property(l => l.DataRetirada)
                .HasColumnName("DATARETIRADA")
                .IsRequired(false);
        }
    }
}
