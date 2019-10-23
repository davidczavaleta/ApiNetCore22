using APIPruebas.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPruebas.Data.Configuracion
{
    public class CfgContacto : IEntityTypeConfiguration<Contacto>
    {
        public void Configure(EntityTypeBuilder<Contacto> builder)
        {
            builder.ToTable("Contactos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(c => c.Puesto)
                .HasMaxLength(30);

            builder.Property(c => c.Correo)
                .HasMaxLength(30);

            builder.Property(c => c.Celular)
                .HasMaxLength(30);

            builder.Property(c => c.Telefono1)
                .HasMaxLength(30);

            builder.Property(c => c.Telefono2)
                .HasMaxLength(30);

            builder.Property(c => c.Observaciones)
                .HasMaxLength(30);
        }
    }
}
