using System.Linq;
using jogoAnimaisAPI.Data;
using jogoAnimaisAPI.Models;

namespace jogoAnimaisAPI.Services
{
    public class Validacoes
    {
        private readonly ApplicationDbContext _db;

        public Validacoes(ApplicationDbContext db)
        {
            _db = db;
        }

        // só faz a mudanã se o valor recebido for 'direita' ou 'esquerda'
        public bool VerificarJogada(string mudanca)
        {
            return mudanca == "direita" || mudanca == "esquerda";
        }

        public validacaoJogadas VerificarJogada(Personagens personagem, string novaPosicao)
        {
            //obtem os personagens do db
            var personagens = _db.personagens.ToList();
            var zebra = personagens.FirstOrDefault(p => p.personagemNome == "zebra");
            var leao = personagens.FirstOrDefault(p => p.personagemNome == "leão");
            var hipopotamo = personagens.FirstOrDefault(p => p.personagemNome == "hipopótamo");
            var guarda = personagens.FirstOrDefault(p => p.personagemNome == "guarda");

            // verifica se o guarda esta do mesmo lado que o personagem que vai se mover
            if (personagem.posicaoPersonagem != guarda.posicaoPersonagem)
            {
                return new validacaoJogadas
                {
                    Validacao = false,
                    Mensagem = "A jogada não é possível, o guarda não está do mesmo lado que o " + personagem.personagemNome
                };
            }
            // atualiza as posições armazenando numa nova string
            personagem.posicaoPersonagem = novaPosicao;
            guarda.posicaoPersonagem = novaPosicao;

            var zebraPos = zebra.posicaoPersonagem;
            var leaoPos = leao.posicaoPersonagem;
            var hipopotamoPos = hipopotamo.posicaoPersonagem;
            var guardaPos = guarda.posicaoPersonagem;

            // faz as vericações das regras do jogo
            if (zebraPos == leaoPos && zebraPos != guardaPos)
            {
                return new validacaoJogadas
                {
                    Validacao = false,
                    Mensagem = "Game over! Você deixou a zebra sozinha com o leão sem o guarda."
                };
            }
            if (leaoPos == hipopotamoPos && leaoPos != guardaPos)
            {
                return new validacaoJogadas
                {
                    Validacao = false,
                    Mensagem = "Game over! Você deixou o leão sozinho com o hipopótamo sem o guarda."
                };
            }
            if ((zebraPos == leaoPos && zebraPos == guardaPos) || (leaoPos == hipopotamoPos && leaoPos == guardaPos))
            {
                return new validacaoJogadas
                {
                    Validacao = true,
                    Mensagem = "Jogada válida! Você passou para próxima fase."
                };
            }
            if ((zebraPos == novaPosicao && zebraPos != guardaPos) || (leaoPos == novaPosicao && leaoPos != guardaPos))
            {
                return new validacaoJogadas
                {
                    Validacao = false,
                    Mensagem = "A jogada não é possível o guarda não está do mesmo lado."
                };
            }
            return new validacaoJogadas
            {
                Validacao = true,
                Mensagem = "A jogada é válida."
            };
        }

        //se todos os personagens estão na esquerda o jogo acaba
        public bool JogoVencido()
        {
            var personagens = _db.personagens.ToList();
            return personagens.All(p => p.posicaoPersonagem == "esquerda");
        }

        public Personagens PersonagemEscolhido(string nome)
        {
            //busca no banco o primeiro personagem cujo o nome fornecido pelo usuario
            return _db.personagens.FirstOrDefault(p => p.personagemNome == nome);
        }


        public class validacaoJogadas
        {
            public bool Validacao { get; set; }
            public string Mensagem { get; set; }
        }
        public string ReiniciarJogo(string confirmacao)
        {
            if (string.IsNullOrEmpty(confirmacao))
            {
                return "Resposta não fornecida, digite 'sim' ou 'não'.";
            }

            if (confirmacao == "sim")
            {
                var personagens = _db.personagens.ToList();
                foreach (var personagem in personagens)
                {
                    personagem.posicaoPersonagem = "direita";
                }

                _db.SaveChanges();

                return "O jogo foi reiniciado, os personagens estão na posição inicial (direita).";
            }
            else if (confirmacao == "nao")
            {
                return "Operação cancelada.";
            }
            else
            {
                return "Resposta inválida, digite 'sim' ou 'não'.";
            }
        }
    }
}


