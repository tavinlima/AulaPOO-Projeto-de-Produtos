using ProjetoProdutos.Classes;

namespace ProjetoProdutos.Interfaces
{
    public interface IUsuario
    {
        string Cadastrar(Usuario usuario);
        string Deletar(Usuario usuario);
    }
}