using System;
using System.Collections.Generic;
using AulaPOO_Projeto_de_Produtos.Classes;
using ProjetoProdutos.Interfaces;

namespace ProjetoProdutos.Classes
{
    public class Marca : IMarca
    {
        
        List<InformacoesMarca> marca = new List<InformacoesMarca>();
        
        public void Cadastrar(InformacoesMarca InformacoesMarca)
        {
            marca.Add(InformacoesMarca);

        }

        public void Deletar(InformacoesMarca InformacoesMarca)
        {
           marca.Remove(InformacoesMarca);
        }

        public void ListarMarca()
        {
           foreach (InformacoesMarca item in marca)
            {
               Console.WriteLine($"{item.Codigo} - {item.NomeMarca} - {item.DataCadastro}");   
            } 
        }
    }
}