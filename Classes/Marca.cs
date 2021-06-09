using System;
using System.Collections.Generic;
using ProjetoProdutos.Interfaces;

namespace ProjetoProdutos.Classes
{
    public class Marca : IMarca
    {
       public int Codigo { get; set; }        
       public string NomeMarca { get; set; }
       public DateTime DataCadastro { get; set; } 
        List<Marca> marcas = new List<Marca>();

        // public Marca()
        // {

        // }
        public Marca()
        {
            
        }
        public Marca(string _nomeMarca, int _codigo){
            NomeMarca = _nomeMarca;
            Codigo = _codigo;
            DataCadastro = DateTime.Now;
        }
        public string Cadastrar(Marca marca)
        {
            marcas.Add(marca);
            return "Marca cadastrada";
        }

        public string Deletar(Marca marca)
        {
           marcas.Remove(marca);
           return $"A marca foi deletada";
        }

        public void ListarMarca()
        {
           foreach (Marca item in marcas)
            {
               Console.WriteLine($"{item.Codigo} - {item.NomeMarca} - {item.DataCadastro}");   
            } 
        }
    }
}