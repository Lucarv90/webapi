using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL.Mappings;
using System.Configuration;
using System.Data.Entity;
using Projeto.Entidades;

namespace Projeto.DAL.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["estudo"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlunoMap());
        }

        public DbSet<Aluno> Aluno {get; set;}
    }
}
