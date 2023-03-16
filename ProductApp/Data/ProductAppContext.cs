using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductApp.Models;

namespace ProductApp.Data
{
    public class ProductAppContext : DbContext
    {
        public ProductAppContext (DbContextOptions<ProductAppContext> options)
            : base(options)
        {
        }

        public DbSet<ProductApp.Models.CProductInfo> CProductInfo { get; set; } = default!;

        public DbSet<ProductApp.Models.CCartInfo>? CCartInfo { get; set; }
    }
}
