using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Infra.Data.Features.Clientes;
using Pizzaria.Domain.Features.Produtos;
using Pizzaria.Infra.Data.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("PizzariaBD_Apollo")
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteConfiguracao());
            modelBuilder.Configurations.Add(new ProdutoConfiguracao());
        }
    }
}
