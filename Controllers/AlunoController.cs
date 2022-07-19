using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoCWebAPI.Models;

namespace PoCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        private DbEscola dbEscola = new DbEscola();

        [HttpGet]
        public List<Aluno> AcessarAlunos()
        {
            return dbEscola.Alunos.ToList();
        }

        [HttpGet("{Id}")]
        public Aluno AcessarAlunoPelaId(int Id)
        {
            Aluno Resultado = new Aluno();
            foreach (Aluno aluno in dbEscola.Alunos)
            {
                if (aluno.Id == Id)
                {
                    Resultado = aluno;
                }
            }
            return Resultado;
        }

        [HttpPost]
        public virtual Aluno CadastrarAluno(Aluno novoAluno)
        {
            dbEscola.Alunos.Add(novoAluno);
            dbEscola.SaveChanges();
            
            return novoAluno;
        }

        [HttpDelete("{Id}")]
        public Aluno DeletarAluno(int Id)
        {
            Aluno AlunoDeletado = new Aluno();
            foreach (Aluno aluno in dbEscola.Alunos)
            {
                if (aluno.Id == Id)
                {
                    AlunoDeletado = aluno;
                    dbEscola.Alunos.Remove(AlunoDeletado);
                    dbEscola.SaveChanges();
                }
            }
            return AlunoDeletado;
           
        } 

    }
}
