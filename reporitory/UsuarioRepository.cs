
using catalogoJogos.Entity;
using catalogoJogos.reporitory;

namespace catalogoJogos.reporitory
{
    public class UsuarioRepository :  IUsuarioRepository
    {
        private static Dictionary<Guid, Usuario> usuarios = new Dictionary<Guid, Usuario>()
        {
            {Guid.Parse("0ca314a5-9252-45d8-9282-2985f2a9fd04"), new Usuario{ Id = Guid.Parse("0ca314a5-9252-45d8-9282-2985f2a9fd04"), Nome = "Carlos Alberto", Biblioteca= new Biblioteca{ Id = Guid.Parse("0ca314a5-9252-45d8-9282-2985f2a9fd04"), jogos = new List<Jogo>(){
                new Jogo{ Id = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), Nome = "Grand Theft Auto V", Produtora = "Rockstar", Preco = 190},
                new Jogo{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Nome = "Street Fighter V", Produtora = "Capcom", Preco = 80}
            }
            }} },
            // {Guid.Parse("0ca314a5-1752-45d8-9282-2985f2g9fd04"), new Usuario{ Id = Guid.Parse("0ca314a5-1752-45d8-9282-2985f2g9fd04"), Nome = "Joao Carlos", Biblioteca= new Biblioteca{ Id = Guid.Parse("0ca314a5-1752-45d8-9282-2985f2g9fd04"), jogos = new List<Jogo>(){
            //     new Jogo{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Nome = "Fifa 20", Produtora = "EA", Preco = 190},
            //     new Jogo{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Nome = "Street Fighter V", Produtora = "Capcom", Preco = 80}
            // }
            // }} },
            
        };

        public Task<List<Usuario>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(usuarios.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Usuario> Obter(Guid id)
        {
            if (!usuarios.ContainsKey(id))
                return Task.FromResult<Usuario>(null);

            return Task.FromResult(usuarios[id]);
        }

        public Task<List<Usuario>> Obter(string nome)
        {
            return Task.FromResult(usuarios.Values.Where(jogo => jogo.Nome.Equals(nome)).ToList());
        }

        public Task<List<Usuario>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Usuario>();

            foreach(var usuario in usuarios.Values)
            {
                if (usuario.Nome.Equals(nome))
                    retorno.Add(usuario);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Usuario usuario)
        {
            usuarios.Add(usuario.Id, usuario);
            return Task.CompletedTask;
        }

        public Task Atualizar(Usuario usuario)
        {
            usuarios[usuario.Id] = usuario;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            usuarios.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    }
}
