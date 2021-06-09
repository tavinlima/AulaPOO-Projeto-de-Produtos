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
        public List<Marca> ListaMarcas = new List<Marca>();
        Marca novaMarca = new Marca();

        public Marca() { }
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
                Console.WriteLine($"{item.Codigo} - {item.NomeMarca} - {item.DataCadastro}");
            }
            return ListaMarcas;
        }
    }
}