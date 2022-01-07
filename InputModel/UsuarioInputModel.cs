using System.ComponentModel.DataAnnotations;
using catalogoJogos.Entity;

namespace catalogoJogos.InputModel
{
    public class UsuarioInputModel
    {
        [Required]
        [StringLength(100,MinimumLength =3, ErrorMessage = "O nome do usuário deve conter entre 3 e 100 caracteres")]
        public string Nome {get;set;}

        [Required]
        public Biblioteca Biblioteca {get;set;}

    }
}