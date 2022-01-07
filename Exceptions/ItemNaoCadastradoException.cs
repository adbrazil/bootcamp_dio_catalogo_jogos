namespace catalogoJogos.Exceptions
{
    public class ItemNaoCadastradoException: Exception
    {

        public ItemNaoCadastradoException(string tipo)
          :base("Este "+tipo+" não está cadastrado"){

          }
        
    }
}