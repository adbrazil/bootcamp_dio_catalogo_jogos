using catalogoJogos.InputModel;
using catalogoJogos.ViewModel;

namespace catalogoJogos.services
{
    public interface IUsuarioService:IDisposable
    {
         Task<List<UsuarioViewModel>> Obter(int pagina,int quantidade);
         Task<UsuarioViewModel> Obter(Guid id);
         Task<UsuarioViewModel> Inserir(UsuarioInputModel jogo);
         Task Atualizar(Guid id,UsuarioInputModel jogo);

         Task Atualizar(Guid id,string nome);

         Task Remover(Guid id);
         
    }
}