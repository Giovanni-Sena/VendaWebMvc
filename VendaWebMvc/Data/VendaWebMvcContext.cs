using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendaWebMvc.Models;

namespace VendaWebMvc.Data
{
    public class VendaWebMvcContext : DbContext
    {
        public VendaWebMvcContext (DbContextOptions<VendaWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<VendaWebMvc.Models.Departamento> Departamento { get; set; }
    }
}
