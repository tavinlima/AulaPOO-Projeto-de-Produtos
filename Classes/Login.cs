using System;
using System.Collections.Generic;
using ProjetoProdutos.Interfaces;

namespace ProjetoProdutos.Classes
{
    public class Login : ILogin
    {
        public bool Logado = false;
        public bool opcaoValida = false;
        string EmailUsuario;
        string SenhaUsuario;
        Usuario usuario = new Usuario();
       
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
            do
            {

            Console.WriteLine("Digite o e-mail: ");
            EmailUsuario = Console.ReadLine();  
            Console.WriteLine("Digite a senha: ");
            SenhaUsuario = Console.ReadLine();

            if (SenhaUsuario == usuario.Senha && EmailUsuario == usuario.Email)
            {
              Logado = true;
            }
              return "O usuario logou";

            } while (Logado == false);
        }
        public Login(int ab){
            
        }
        public Login()
        {
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

                        DateTime DataCadastro = DateTime.Now;
                
                        Usuario usuario1 = new Usuario(123456, NomeUsuario, EmailUsuario, SenhaUsuario);
                        usuario.Cadastrar(usuario1);

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
4 - Deletar produto

5 - Cadastrar Marcas
6 - Deletar marcas

7 - Deslogar

X - Deletar Usuário
                        
                        ");
                        string opcaoMenu = Console.ReadLine();

                        switch (opcaoMenu)
                        {
                            case "3":
                                 Marca marca1 = new Marca();
                                 if (marca1.Cadastrar(marca1) == null)
                                 {
                                     Console.WriteLine("É preciso existir uma marca cadastrada para cadastrar um produto!");
                                 }else {
                                    Console.WriteLine("Insira o código do produto: ");
                                    int CodigoProduto = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Insira o nome do produto: ");
                                    string NomeProduto = Console.ReadLine();

                                    Console.WriteLine("Insira o preço do produto: ");
                                    float PrecoProduto = float.Parse(Console.ReadLine());

                                    Produto produto1 = new Produto(CodigoProduto, NomeProduto, PrecoProduto);

                                    produto1.Cadastrar(produto1);
                                    produto1.Listar();
                                 }
                                break;

                            case "4":
                                Produto deletarProduto = new Produto();

                                Console.WriteLine("Qual o nome do produto que deseja deletar? ");
                                deletarProduto.Nome = Console.ReadLine().ToUpper();

                                deletarProduto.Deletar(deletarProduto);
                                break;

                            case "5":

                                Console.WriteLine("Insira o código da marca: ");
                                int Codigo = int.Parse(Console.ReadLine());

                                Console.WriteLine("Insira o nome da marca: ");
                                string NomeMarca = Console.ReadLine();
                                Marca marca = new Marca(NomeMarca, Codigo);

                                marca.Cadastrar(marca);
                                marca.ListarMarca();
                                break;

                            case "6":

                                 Marca deletarMarca = new Marca();
                                 deletarMarca.Deletar(deletarMarca);
                                break;

                            case "7":
                                Deslogar(usuario);
                                break;

                            case "X":
                                usuario.Deletar(usuario);
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