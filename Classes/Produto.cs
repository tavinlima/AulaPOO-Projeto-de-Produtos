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
        public List<Produto> ListaProdutos = new List<Produto>();
     
        public Produto()
        {
        }
        public Produto(int _codigo, string _nome, float _preco)
        {
            this.CodigoProduto = _codigo;
            this.NomeProduto = _nome;
            this.Preco = _preco;
            DataCadastroProduto = DateTime.Now;
        }

        public string Cadastrar(Produto produto)
        {
            ListaProdutos.Add(produto);
            return "O produto foi cadastrado";
        }

        public string Deletar(Produto produto)
        {
            ListaProdutos.Remove(produto);
            return "O produto foi deletado";
        }

        public List<Produto> Listar()
        {
            foreach (Produto item in ListaProdutos)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($@"
Código:         {item.CodigoProduto}  
Nome:           {item.NomeProduto} 
Preço:          {item.Preco :C2}

Data de compra: {item.DataCadastroProduto}");
                Console.ResetColor();
            }
            return ListaProdutos;
        }

    }
}