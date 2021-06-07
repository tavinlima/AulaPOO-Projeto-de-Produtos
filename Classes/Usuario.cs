using System;
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

        public string Cadastrar(Usuario usuario)
        {
            Usuario u = new Usuario();
            
            Console.WriteLine("Insira o código de usuário: ");
            u.Codigo = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o nome de usuário: ");
            u.Nome = Console.ReadLine();

            Console.WriteLine("Insira o e-mail de usuario: ");
            u.Email = Console.ReadLine();

            Console.WriteLine("Insira a senha de usuário: ");
            u.Senha = Console.ReadLine();
            

            return $"O usuário {u.Nome} foi cadastrado";
        }

        public string Deletar(Usuario usuario)
        {
            return $"O usuario {Nome} foi deletado";
        }
    }
}