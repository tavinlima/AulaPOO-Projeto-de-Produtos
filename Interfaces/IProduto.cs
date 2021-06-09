using System.Collections.Generic;
using ProjetoProdutos.Classes;

namespace ProjetoProdutos.Interfaces
{
    public interface IProduto
    {
       
        string Cadastrar(Produto produto);
        List<Produto> Listar(); 
        string Deletar(Produto produto);  
    }
}