using GP.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.Data.Mappings
{
    class PatrimonioMapping : IEntityTypeConfiguration<Patrimonio>
    {
        public void Configure (EntityTypeBuilder<Patrimonio> builder)
        {
            builder.HasKey( p => p.Id );

            builder.Property( p => p.Nome )
                .IsRequired()
                .HasColumnType( "varchar(200)" );

            builder.Property( p => p.Descricao )
                .HasColumnType( "varchar(1000)" );

            builder.ToTable( "Patrimonios" );
        }
    }
}
