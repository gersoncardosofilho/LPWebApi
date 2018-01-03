using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using LPWebApi.Models;

namespace LPWebApi.DbContext
{
    public class PublicacoesContext : System.Data.Entity.DbContext
    {
        public PublicacoesContext() : base("azureConnectionString")
        {
            
        }

        public DbSet<Publicacao> Publicacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}