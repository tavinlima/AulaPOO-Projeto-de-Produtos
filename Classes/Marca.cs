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
            return $"A Marca {NomeMarca} foi cadastrada";
        }

        public string Deletar(Marca marca)
        {
            ListaMarcas.Remove(marca);
            return $"A marca {NomeMarca} foi deletada";
        }

        public List<Marca> ListarMarca()
        {
            
        return ListaMarcas;     
        }

        // chamar no login lista
        public int ListarCodigoM() {
            return Codigo;
        }
        public Marca AcharMarca(string _nomeMarca) {
            return ListaMarcas.Find(x => x.NomeMarca == _nomeMarca);

        }
    }
}