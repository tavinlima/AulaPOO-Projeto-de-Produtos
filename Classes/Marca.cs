using System;
using System.Collections.Generic;
using ProjetoProdutos.Interfaces;

namespace ProjetoProdutos.Classes
{
    public class Marca : IMarca
    {
        public int Codigo;
        public string NomeMarca;
        public DateTime DataCadastro;
        public List<Marca> ListaMarcas = new List<Marca>();
        public Marca()
        {

        }
        public Marca(string _nomeMarca, int _codigo)
        {
            NomeMarca = _nomeMarca;
            Codigo = _codigo;
            DataCadastro = DateTime.Now;
        }
        public string Cadastrar(Marca marca)
        {
            ListaMarcas.Add(marca);
            return "Marca cadastrada";
        }

        public string Deletar(Marca marca)
        {
            ListaMarcas.Remove(marca);
            return $"A marca foi deletada";
        }

        public List<Marca> ListarMarca()
        {
            foreach (Marca item in ListaMarcas)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($@"
Código:         {item.Codigo} 
Nome:           {item.NomeMarca} 
                
Data da compra: {item.DataCadastro}");
                Console.ResetColor();
            }
            return ListaMarcas;
        }
    }
}