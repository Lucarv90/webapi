using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Servicos.Models
{
    public class AlunoConsultaModel
    {
        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public string  Matricula { get; set; }
        public DateTime DataNascimento { get; set; }

        public int Idade { get; set; }
    }
}