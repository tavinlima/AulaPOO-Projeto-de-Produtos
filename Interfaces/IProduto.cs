using ProjetoProdutos.Classes;

namespace ProjetoProdutos.Interfaces
{
    public interface IProduto
    {
       
        string Cadastrar(Produto produto);
        void Listar(); 
        string Deletar(Produto produto);  
    }
}