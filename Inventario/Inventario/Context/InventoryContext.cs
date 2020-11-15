using Inventario.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Context
{
    public class InventoryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionBuilder.UseMySql(configuration["connectionString:inventoryDB"]);
        }
        
        public virtual DbSet<CategoryModel> Categories { get; set; }

        public virtual DbSet<VoucherModel> Vouchers { get; set; }

        public virtual DbSet<TypePaymentModel> TypePayments { get; set; }
        
        public virtual DbSet<TypeSaleModel> TypeSales { get; set; }
        
        public virtual DbSet<ProductModel> Products { get; set; }

    }
}
