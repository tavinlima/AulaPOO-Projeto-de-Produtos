using ProjetoProdutos.Classes;

namespace ProjetoProdutos.Interfaces
{
    public interface ILogin
    {
        void Login();
        string Logar(Usuario usuario);
        string Deslogar(Usuario usuario);
    }
}