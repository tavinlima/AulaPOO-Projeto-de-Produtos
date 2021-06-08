using System.Collections.Generic;
using ProjetoProdutos.Classes;

namespace ProjetoProdutos.Interfaces
{
    public interface IMarca
    {
        string Cadastrar(Marca marca);
        void ListarMarca(); 
        string Deletar(Marca marca);
        
    }
}