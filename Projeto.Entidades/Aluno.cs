using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Aluno
    {
        public int IdAluno { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public Aluno()
        {

        }

        public Aluno(int idAluno, string matricula, string nome, DateTime dataNascimento)
        {
            IdAluno = idAluno;
            Matricula = matricula;
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", IdAluno, Nome, Matricula, DataNascimento);
        }
    }
}
