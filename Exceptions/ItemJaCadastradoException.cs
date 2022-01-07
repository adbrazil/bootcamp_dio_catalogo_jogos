namespace catalogoJogos.Exceptions
{
    public class ItemJaCadastradoException: Exception
    {

        public ItemJaCadastradoException(string  tipo)
          :base("Este " +tipo+" já está cadastrado"){

          }
        
    }
}