using catalogoJogos.Entity;

namespace catalogoJogos.reporitory
{
    public interface IJogoRepository:IDisposable
    {
         
         Task<List<Jogo>> Obter(int pagina,int quantidade);
         Task<Jogo> Obter(Guid id);

         Task<List<Jogo>> Obter(string nome,string produtora);
         Task Inserir(Jogo jogo);
         Task Atualizar(Jogo jogo);
         Task Remover(Guid id);
    }
}