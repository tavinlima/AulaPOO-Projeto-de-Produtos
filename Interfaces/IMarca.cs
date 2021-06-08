using System.Collections.Generic;
using AulaPOO_Projeto_de_Produtos.Classes;
using ProjetoProdutos.Classes;

namespace ProjetoProdutos.Interfaces
{
    public interface IMarca
    {
        void Cadastrar(InformacoesMarca InformacoesMarca);
        void ListarMarca(); 
        void Deletar(InformacoesMarca InformacoesMarca);
        
    }
}