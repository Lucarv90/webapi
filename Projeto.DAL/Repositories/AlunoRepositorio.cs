using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL.Context;
using Projeto.Entidades;
using System.Data.Entity;

namespace Projeto.DAL.Repositories
{
    public class AlunoRepositorio
    {
        public void Insert(Aluno a)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(a).State = EntityState.Added;
                d.SaveChanges();
            }
        }

        public void Update(Aluno a)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(a).State = EntityState.Modified;
                d.SaveChanges();
            }
        }

        public void Delete(Aluno a)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(a).State = EntityState.Deleted;
                d.SaveChanges();
            }
        }

        public List<Aluno> FindAll()
        {
            using (DataContext d = new DataContext())
            {
                return d.Aluno.ToList();
            }
        }
        public Aluno FindByID(int idAluno)
        {
            using (DataContext d = new DataContext())
            {
                return d.Aluno.Find(idAluno);
            }
        }
    }
}
