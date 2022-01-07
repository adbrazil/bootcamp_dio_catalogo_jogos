using catalogoJogos.Entity;
using catalogoJogos.Exceptions;
using catalogoJogos.InputModel;
using catalogoJogos.reporitory;
using catalogoJogos.ViewModel;

namespace catalogoJogos.services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository  usuarioRepository){
            _usuarioRepository= usuarioRepository;
        }


        public async Task<List<UsuarioViewModel>> Obter(int pagina, int quantidade)
        {
            var usuarios = await _usuarioRepository.Obter(pagina,quantidade);

            return  usuarios.Select(usuario => new UsuarioViewModel
            {
                Id= usuario.Id,
                Nome=usuario.Nome,
                Biblioteca=usuario.Biblioteca
            })
            .ToList();

            
        }

        public async Task<UsuarioViewModel> Obter(Guid id)
        {
            var usuario= await _usuarioRepository.Obter(id);

            if(usuario==null){
                return null;
            }
            return new UsuarioViewModel
            {
                Id= usuario.Id,
                Nome=usuario.Nome,
                Biblioteca=usuario.Biblioteca
               
            };
        }


        public async Task<UsuarioViewModel> Inserir(UsuarioInputModel usuario)
        {
            var entidadeUsuario = await  _usuarioRepository.Obter(usuario.Nome);

            if(entidadeUsuario.Count > 0)
                throw new  ItemJaCadastradoException("usuario");
            
            var  usuarioInsert = new Usuario{
                Id= Guid.NewGuid(),
                Nome=usuario.Nome,
                Biblioteca=usuario.Biblioteca
            };

            await  _usuarioRepository.Inserir(usuarioInsert);

            return new UsuarioViewModel
            {
                Id= usuarioInsert.Id,
                Nome=usuarioInsert.Nome,
                Biblioteca = usuarioInsert.Biblioteca
            };


            throw new NotImplementedException();
        }

        public async Task Atualizar(Guid id, UsuarioInputModel usuario)
        {
            var entidadeUsuario = await  _usuarioRepository.Obter(id);

            if(entidadeUsuario == null)
              throw new ItemNaoCadastradoException("usuario");
            
            entidadeUsuario.Nome= usuario.Nome;
            entidadeUsuario.Biblioteca= usuario.Biblioteca;
       

            await _usuarioRepository.Atualizar(entidadeUsuario);
        }

        public async Task Atualizar(Guid id, string nome)
        {
            var entidadeUsuario = await  _usuarioRepository.Obter(id);

            if(entidadeUsuario == null)
              throw new ItemNaoCadastradoException("usuario");
            
            entidadeUsuario.Nome= nome;

            await _usuarioRepository.Atualizar(entidadeUsuario);
        }


        public async Task Remover(Guid id)
        {
            var usuario = await  _usuarioRepository.Obter(id);

            if(usuario == null)
              throw new ItemNaoCadastradoException("usuario");
            await _usuarioRepository.Remover(id);
        }

        public void Dispose(){
            _usuarioRepository?.Dispose();
        }
    }
}