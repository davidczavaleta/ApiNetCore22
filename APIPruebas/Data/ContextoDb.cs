using APIPruebas.Entidades;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPruebas.Data
{
    public class ContextoDb : DbContext
    {
        public ContextoDb(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Sucursal> Sucursales { get; set; }
    }
}
