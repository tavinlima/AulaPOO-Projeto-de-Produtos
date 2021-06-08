using System;
using System.Collections.Generic;
using ProjetoProdutos.Interfaces;

namespace ProjetoProdutos.Classes
{
    public class Login : ILogin
    {
        public bool Logado { get; set; }
        public bool opcaoValida { get; set; }
        string EmailUsuario;
        string SenhaUsuario;
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
                Console.WriteLine("Bem vindo!");
            }
            return "O usuario logou";
        }

        void ILogin.Login()
        {
            throw new NotImplementedException();
        }

        public Login()
        {
            Marca marca = new Marca();
            Usuario usuario = new Usuario();
            do
            {

                Console.WriteLine($@"
O que deseja fazer?

1 - Cadastrar usuário
2 - Fazer Login

0 - Sair do Sistema
            ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Insira o nome de usuário: ");
                        string NomeUsuario = Console.ReadLine();

                        Console.WriteLine("Insira o e-mail de usuário: ");
                        string EmailUsuario = Console.ReadLine();

                        Console.WriteLine("Insira a senha de usuário: ");
                        string SenhaUsuario = Console.ReadLine();

                        Usuario usuario1 = new Usuario(123456, NomeUsuario, EmailUsuario, SenhaUsuario);
                        usuario.Cadastrar(usuario1);
                        opcaoValida = false;
                        break;

                    case "2":
                        Console.WriteLine("Digite seu e-mail: ");
                        EmailUsuario = Console.ReadLine();

                        Console.WriteLine("Digite sua senha: ");
                        SenhaUsuario = Console.ReadLine();

                        List<Usuario> usuarios = usuario.ListarUsuarios();
                        if (usuarios.Find(cadaLinha => cadaLinha.Email == usuario.Email).Senha == this.SenhaUsuario)
                        {
                            Logar(usuario);
                        }
                        Console.WriteLine($@"
                        Escolha o que deseja fazer:
3 - Cadastrar produtos
4 - Cadastrar Marcas
5 - Deslogar
                        
                        ");
                        string opcaoMenu = Console.ReadLine();
                        switch (opcaoMenu)
                        {
                            case "3":
                                if (marca.Cadastrar(marca) == null)
                                {
                                    Console.WriteLine("É preciso existir uma marca cadastrada para cadastrar um produto!");
                                }
                                else
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
                                opcaoValida = false;
                                break;

                            case "4":
                                Console.WriteLine("Insira o código da marca: ");
                                int Codigo = int.Parse(Console.ReadLine());

                                Console.WriteLine("Insira o nome da marca: ");
                                string NomeMarca = Console.ReadLine();

                                marca.Cadastrar(marca);
                                marca.ListarMarca();
                                opcaoValida = false;

                                break;

                            case "5":
                                Deslogar(usuario);

                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("OPÇÃO INVÁLIDA!!!");
                                Console.ResetColor();
                                opcaoValida = false;
                                break;
                        }
                        break;

                    case "0":
                        Console.WriteLine("Obrigado por utilizar nosso sistema, volte sempre!");
                        opcaoValida = true;
                        Deslogar(usuario);
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