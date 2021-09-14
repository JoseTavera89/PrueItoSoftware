using Entidades.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Data
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext() { }
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
            : base(options)
        { }

        DbSet<Empresa> Empresa { get; set; }
        DbSet<Empleado> Empleado { get; set; }
    }
}
