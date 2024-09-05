using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jogoAnimaisAPI.Models
{
    public class Personagens
    {
        [Key]
        public int personagemId { get; set; }
        [Column ("personagemNome")]
        public string personagemNome { get; set; }
        public string posicaoPersonagem { get; set; }
    }
}
