using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Servicos.Models;
using Projeto.Entidades;
using Projeto.DAL.Repositories;

namespace Projeto.Servicos.Controllers
{
    [RoutePrefix("api/aluno")]
    public class AlunoController : ApiController
    {
       [HttpPost]
       [Route("cadastrar")]
       public HttpResponseMessage Cadastrar(AlunoCadastroModel model)
        {
            try
            {
                Aluno a = new Aluno();
                a.Nome = model.Nome;
                a.Matricula = model.Matricula;
                a.DataNascimento = model.DataNascimento;

                AlunoRepositorio rep = new AlunoRepositorio();
                rep.Insert(a);

                return Request.CreateResponse(HttpStatusCode.OK, "Aluno Cadastrado");
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage Atualizar(AlunoEdicaoModel model)
        {
            try
            {
                Aluno a = new Aluno();
                a.IdAluno = model.IdAluno;
                a.Nome = model.Nome;
                a.Matricula = model.Matricula;
                a.DataNascimento = model.DataNascimento;

                AlunoRepositorio rep = new AlunoRepositorio();
                rep.Update(a);

                return Request.CreateResponse(HttpStatusCode.OK, "Aluno Atualizado");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpDelete]
        [Route("excluir")]
        public HttpResponseMessage Excluir(int id)
        {
            try
            {
                AlunoRepositorio rep = new AlunoRepositorio();
                Aluno a = rep.FindByID(id);
                rep.Delete(a);

                return Request.CreateErrorResponse(HttpStatusCode.OK, "Aluno Excluído");
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        [Route("listartodos")]
        public HttpResponseMessage ListarTodos()
        {
            try
            {
                List<AlunoConsultaModel> lista = new List<AlunoConsultaModel>();
                AlunoRepositorio rep = new AlunoRepositorio();
                foreach (Aluno a in rep.FindAll())
                {
                    AlunoConsultaModel model = new AlunoConsultaModel();
                    model.IdAluno = a.IdAluno;
                    model.Nome = a.Nome;
                    model.Matricula = a.Matricula;
                    model.DataNascimento = a.DataNascimento;
                    model.Idade = DateTime.Now.Year - a.DataNascimento.Year;
                    lista.Add(model);                    
                }
                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        [Route("obterporid")]
        public HttpResponseMessage ObterPorID(int id)
        {
            try
            {
                AlunoRepositorio rep = new AlunoRepositorio();
                Aluno a = rep.FindByID(id);
                AlunoConsultaModel model = new AlunoConsultaModel();
                model.IdAluno = a.IdAluno;
                model.Nome = a.Nome;
                model.Matricula = a.Matricula;
                model.DataNascimento = a.DataNascimento;
                model.Idade = DateTime.Now.Year - a.DataNascimento.Year;
                //retornar status de sucesso HTTP 200
                return Request.CreateResponse(HttpStatusCode.OK, model);                
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }

        }
    }
}
