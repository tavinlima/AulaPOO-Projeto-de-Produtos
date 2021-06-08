using System;
using System.Collections.Generic;
using ProjetoProdutos.Interfaces;

namespace ProjetoProdutos.Classes
{
    public class Usuario : IUsuario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        List<Usuario> ListaUsuarios = new List<Usuario>();

        public Usuario(){  
        }

        public Usuario(int _codigo, string _nome, string _email, string _senha){
            this.Codigo = _codigo;
            this.Nome = _nome;
            this.Email = _email;
            this.Senha = _senha;
        }

        public string Cadastrar(Usuario usuario)
        {
            ListaUsuarios.Add(usuario);
            return $"O usuário {Nome} foi cadastrado";
        }

        public string Deletar(Usuario usuario)
        {
            ListaUsuarios.Remove(usuario);
            return $"O usuario {Nome} foi deletado";
        }

    }
}