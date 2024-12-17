using System.ComponentModel.DataAnnotations;

// Gabriel Martins Alves da Silva - CB3021521

namespace TP04SWII6.Models
{
    public class Jogo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título do jogo é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "A plataforma é obrigatória.")]
        public string Plataforma { get; set; }

        [Required(ErrorMessage = "A data de lançamento é obrigatória.")]
        public DateTime DataLancamento { get; set; }
    }


}
