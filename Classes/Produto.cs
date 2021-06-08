using System;
using System.Collections.Generic;
using ProjetoProdutos.Interfaces;

namespace ProjetoProdutos.Classes
{
    public class Produto : Usuario, IProduto
    {
        public int CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public float Preco { get; set; }
        public DateTime DataCadastroProduto { get; set; } 

        Usuario n = new Usuario();
        Marca mc = new Marca();
        List<Produto> produtos = new List<Produto>();
        Produto novoProduto = new Produto();
        
         public string Cadastrar(Produto produto)
        {
            produtos.Add(produto);
            return "O produto foi cadastrado";
        }
        
         public string Deletar(Produto produto)
        {
            produtos.Remove(produto);
            return "O produto foi deletado";
        }

        public void Listar()
        {
           foreach (Produto item in produtos)
            {
               Console.WriteLine($"{item.CodigoProduto} - {item.NomeProduto} - {item.DataCadastroProduto}");   
            } 
        }

    }
}