using APIPruebas.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPruebas.Data.Configuracion
{
    public class CfgSucursal : IEntityTypeConfiguration<Sucursal>
    {
        public void Configure(EntityTypeBuilder<Sucursal> builder)
        {
            builder.ToTable("Sucursales");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Numero)
                .IsRequired();

            builder.Property(s => s.Nombre)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
