using Microsoft.AspNetCore.Mvc;
using jogoAnimaisAPI.Services;
using jogoAnimaisAPI.Models;
using jogoAnimaisAPI.Data;
using System.Globalization;

namespace jogoAnimaisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogoController : ControllerBase
    {
        private readonly Validacoes _validacoes;
        private readonly ApplicationDbContext _db;

        public JogoController(Validacoes validacoes, ApplicationDbContext db)
        {
            _validacoes = validacoes;
            _db = db;
        }

        [HttpGet("IniciarJogo")]
        public ActionResult<string> IniciarJogo(string nome, string jogada)
        {
            if (!_validacoes.VerificarJogada(jogada))
            {
                return BadRequest("Jogada inválida, digite 'esquerda' ou 'direita'.");
            }

            var entity = _validacoes.PersonagemEscolhido(nome);
            if (entity == null)
            {
                return NotFound($"Personagem com o nome {nome} não encontrado.");
            }

            var resultado = _validacoes.VerificarJogada(entity, jogada);
            if (!resultado.Validacao)
            {
                return BadRequest(resultado.Mensagem);
            }
            _db.SaveChanges();

            if (_validacoes.JogoVencido())
            {
                return Ok("Parabéns você venceu o jogo! Todos os personagens chegaram a salvo no lado esquerdo do rio.");
            }

            return Ok($"Boa jogada! Você moveu o {entity.personagemNome} para {jogada}.");
        }

        [HttpGet("VerEstadoDosPersonagens")]
        public ActionResult<IEnumerable<object>> VerEstadoDosPersonagens()
        {
            return _db.personagens.Select(p => new { Nome = p.personagemNome, Posicao = p.posicaoPersonagem }).ToList();
        }


        [HttpGet("ReiniciarJogo")]
        public ActionResult<string> ReiniciarJogo(string confirmacao)
        {
            return Ok(_validacoes.ReiniciarJogo(confirmacao));
        }

        [HttpGet("Regras")]
        public string Regras()
        {
                   return"Seja bem-vindo ao jogo dos animais!\n" +
                         "Objetivo: atravessar o rio com todos os animais vivos.\n" +
                         "Regras: Atravessar o rio com um animal de cada vez.\n" +
                         "Os animais começam no lado direito e trocam de lado se movimentando com guarda no barco. Se o barco estiver no mesmo lado do rio, os animais ainda estão a salvo.\n" +
                         "Se o hipopótamo for deixado sozinho com o leão, o leão morre.\n" +
                         "Se o leão for deixado sozinho com a zebra, a zebra morre.";
        }
    }
}
