using System;
using System.Collections.Generic;
using ProjetoProdutos.Interfaces;

namespace ProjetoProdutos.Classes
{
    public class Usuario : IUsuario
    {
         private int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<Usuario> ListaUsuarios = new List<Usuario>();

        public Usuario(){
            
        }

        public Usuario(int _codigo, string _nome, string _email, string _senha){
            this.Codigo = _codigo;
            this.Nome = _nome;
            this.Email = _email;
            this.Senha = _senha;
            DataCadastro = DateTime.Now;
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

        public List<Usuario> ListarUsuarios(){

             foreach (Usuario item in ListaUsuarios)
            {
               Console.WriteLine($"{item.Nome} = {item.Email} - {item.Codigo}");   
            } 
            return ListaUsuarios;
        }
         public Usuario AcharEmail(string email) {
            return ListaUsuarios.Find(x => x.Email == email);
        }
    }
}