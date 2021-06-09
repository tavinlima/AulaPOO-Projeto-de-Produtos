using ProjetoProdutos.Classes;

namespace ProjetoProdutos.Interfaces
{
    public interface ILogin
    {
        string Logar(Usuario usuario);
        string Deslogar(Usuario usuario);
    }
}