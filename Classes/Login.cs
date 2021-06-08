using System;
using ProjetoProdutos.Interfaces;

namespace ProjetoProdutos.Classes
{
    public class Login : ILogin
    {
        public bool Logado { get; set; }
        public bool opcaoValida { get; set; }
        public string Deslogar(Usuario usuario)
        {
            if (Logado)
            {
                Logado = false;
                Console.WriteLine("Obrigado por utilizar em nosso sistema, até breve!");
            }
            return "O usuario deslogou";
        }

        public string Logar(Usuario usuario)
        {
            if (!Logado)
            {
                Console.WriteLine("Obrigado por utilizar em nosso sistema, para entrar");
            }
            return "O usuario logou";
        }

        void ILogin.Login()
        {
            do
            {

                Console.WriteLine($@"
O que deseja fazer?

1 - Cadastrar usuário
2 - Cadastrar produtos
3 - Cadastrar Marcas
            ");

                string opcao = Console.ReadLine();
                Marca marca = new Marca();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Insira o nome de usuário: ");
                        string NomeUsuario = Console.ReadLine();

                        Console.WriteLine("Insira o e-mail de usuário: ");
                        string EmailUsuario = Console.ReadLine();

                        Console.WriteLine("Insira a senha de usuário: ");
                        string SenhaUsuario = Console.ReadLine();

                        Usuario usuario = new Usuario(123456, NomeUsuario, EmailUsuario, SenhaUsuario);
                        usuario.Cadastrar(usuario);

                        break;

                    case "2":
                        if (marca.Cadastrar(marca) == null)
                        {
                          Console.WriteLine("É preciso existir uma marca cadastrada para cadastrar um produto!");   
                        }else
                        {
                        Console.WriteLine("Insira o código do produto: ");
                        int CodigoProduto = int.Parse(Console.ReadLine());

                        Console.WriteLine("Insira o nome do produto: ");
                        string NomeProduto = Console.ReadLine();

                        Console.WriteLine("Insira o preço do produto: ");
                        float PrecoProduto = float.Parse(Console.ReadLine());

                        Produto produto = new Produto();

                        produto.Cadastrar(produto);
                        produto.Listar();
                        }
                        break;

                    case "3":
                    Console.WriteLine("Insira o código da marca: ");
                    int Codigo = int.Parse(Console.ReadLine());

                    Console.WriteLine("Insira o nome da marca: ");
                    string NomeMarca = Console.ReadLine();

                    marca.Cadastrar(marca);
                    marca.ListarMarca();

                    break;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("OPÇÃO INVÁLIDA!!!");
                        Console.ResetColor();
                        opcaoValida = false;
                        break;
                }
            } while (!opcaoValida);

        }
    }
}