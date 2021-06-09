using System.Collections.Generic;
using ProjetoProdutos.Classes;

namespace ProjetoProdutos.Interfaces
{
    public interface IMarca
    {
        string Cadastrar(Marca marca);
        List<Marca> ListarMarca(); 
        string Deletar(Marca marca);
        
    }
}