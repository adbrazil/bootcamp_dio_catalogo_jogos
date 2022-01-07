using catalogoJogos.Entity;

namespace catalogoJogos.ViewModel
{
    public class UsuarioViewModel
    {
        public Guid Id {get;set;}
        public string Nome {get;set;}

        public Biblioteca Biblioteca {get;set;}

    }
}