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
        public Usuario CadastradoPor { get; set; }
        public Marca Marca { get; set; }
        public List<Produto> ListaProdutos = new List<Produto>();

        public Produto()
        {
        }
        public Produto(int _codigo, string _nome, float _preco, Marca _marca, Usuario _cadastradoPor)
        {
            this.CodigoProduto = _codigo;
            this.NomeProduto = _nome;
            this.Preco = _preco;
            this.Marca = _marca;
            this.CadastradoPor = _cadastradoPor;
            DataCadastroProduto = DateTime.Now;
        }

        public string Cadastrar(Produto produto)
        {
            ListaProdutos.Add(produto);
            return $"O produto {NomeProduto} foi cadastrado";
        }
         public string Deletar(Produto produto)
        {
            ListaProdutos.Remove(produto);
            return $"O produto {NomeProduto} foi deletado";
        }
        public Produto AcharProduto(int _codigo) {
            return ListaProdutos.Find(x => x.CodigoProduto == _codigo);
        }
        public List<Produto> Listar()
        {  
            return ListaProdutos;
        }


        // chamar no login lista
        public int ListarOCodigoP () {
        return CodigoProduto;
        }
        public string ListarONomeP () {
            return NomeProduto;
        }
        public float ListarOPrecoP() {
            return Preco;
        }
        public string ListarAMarcaP() {
            return Marca.NomeMarca;
        }
        public string ListarEmailP(){
            return CadastradoPor.Email;
        }

       
    }
}