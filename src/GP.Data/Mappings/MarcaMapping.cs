using GP.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GP.Data.Mappings
{
    class MarcaMapping : IEntityTypeConfiguration<Marca>
    {
        public void Configure (EntityTypeBuilder<Marca> builder)
        {
            builder.HasKey( p => p.Id );

            builder.Property( p => p.Nome )
                .IsRequired()
                .HasColumnType( "varchar(300)" );

            // 1 : N => Marca : Patrimonios
            builder.HasMany( m => m.Patrimonios )
                .WithOne( p => p.Marca)
                .HasForeignKey( p => p.MarcaId );

            builder.ToTable( "Marcas" );
        }
    }
}
