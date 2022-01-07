using catalogoJogos.Entity;

namespace catalogoJogos.reporitory
{
    public interface IUsuarioRepository:IDisposable
    {
         
         Task<List<Usuario>> Obter(int pagina,int quantidade);
         Task<Usuario> Obter(Guid id);

         Task<List<Usuario>> Obter(string nome);
         Task Inserir(Usuario usuario);
         Task Atualizar(Usuario usuario);
         Task Remover(Guid id);
    }
}