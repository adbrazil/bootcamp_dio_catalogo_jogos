using System.ComponentModel.DataAnnotations;

namespace catalogoJogos.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100,MinimumLength =3, ErrorMessage = "O nome do jogo deve conter entre 3 e 100 caracteres")]
        public string Nome {get;set;}

        [StringLength(100,MinimumLength =1, ErrorMessage = "O nome da Produtora deve conter entre 1 e 100 caracteres")]
        public string Produtora {get;set;}

        
        [Range(1,1000,ErrorMessage = "O preço do jogo deve ser no mínimo 1 e no máximo 1000 reais")]
        public double Preco {get;set;}
    }
}