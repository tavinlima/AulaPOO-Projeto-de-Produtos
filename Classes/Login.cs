using System;
using System.Collections.Generic;
using ProjetoProdutos.Interfaces;

namespace ProjetoProdutos.Classes
{
    public class Login : ILogin
    {
        public string marcaName;
        public bool Logado = false;
        public bool opcaoValida = false;
        public bool opcaoValidaMenu = false;
        string EmailUsuario;
        string SenhaUsuario;
        // Usuario usuarioencontrar;
        Usuario usuario = new Usuario();
        public string Deslogar(Usuario usuario)
        {
            if (Logado)
            {
                Logado = false;
                Console.WriteLine("Obrigado por utilizar nosso sistema, até breve!");
            }
            return "O usuario deslogou, adeus!";
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
        public Login()
        {
            Marca marcaR = new Marca();
            Produto produtoR = new Produto();
            int MarcaAd = 0;
            int codProduto = 0;
            bool BoolDelete;
            do
            {
                Console.WriteLine($@"
|========================|
|  O que deseja fazer?   |
|________________________|
|                        |
| 1 - Cadastrar usuário  |
| 2 - Fazer Login        |
|                        |
| 0 - Sair do Sistema    |
|________________________|
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
                        if (usuario.ListaUsuarios.Count != 0)
                        {

                            Console.WriteLine("Digite seu e-mail: ");
                            EmailUsuario = Console.ReadLine();

                            Console.WriteLine("Digite sua senha: ");
                            SenhaUsuario = Console.ReadLine();

                            List<Usuario> usuarios = usuario.ListarUsuarios();

                            if (usuarios.Find(cadaLinha => cadaLinha.Email == EmailUsuario).Senha == this.EmailUsuario)
                            {
                                Logar(usuario);
                            }

                            do
                            {
                                Console.WriteLine($@"
|=============================|
| Escolha o que deseja fazer: |
|_____________________________| 
| 3 - Cadastrar produtos      |
| 4 - Deletar produto         |
|                             |
| 5 - Cadastrar Marcas        |
| 6 - Deletar marcas          |
|                             |
|  7 - Listar marcas          |
|  8 - Listar Produtos        |
|                             |
|  9 - Deslogar               |
|                             |
| X - Deletar Usuário         |
|=============================|
                        ");
                                string opcaoMenu = Console.ReadLine().ToUpper();
                                opcaoValida = true;

                                switch (opcaoMenu)
                                {

                                    case "3":

                                        int cont = 0;
                                        bool CadastroP;
                                        string continuar = "s";
                                        float precoProd;

                                        Console.WriteLine("Insira o nome do produto: ");
                                        string nomeProd = Console.ReadLine().ToUpper().Trim();

                                        do
                                        {
                                            Console.WriteLine("Insira o preço do produto: ");
                                            string precoUs = Console.ReadLine();
                                            CadastroP = float.TryParse(precoUs, out precoProd);
                                            if (CadastroP)
                                            {
                                                precoProd = float.Parse(precoUs);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Inválido, Insira apenas números!");
                                            }
                                        } while (!CadastroP);
                                        opcaoValidaMenu = true;
                                        opcaoValida = false;

                                        do
                                        {
                                            Console.WriteLine("Insira a marca do produto: ");
                                            string marcaProduto = Console.ReadLine().ToUpper();

                                            foreach (Marca marca in marcaR.ListarMarca())
                                            {
                                                if (marca.NomeMarca == marcaProduto)
                                                {
                                                    codProduto += 1;
                                                    Marca marcaProd = marcaR.AcharMarca(marcaProduto);
                                                    Usuario usuarioProd = usuario.AcharEmail(EmailUsuario);
                                                    Produto novoProduto = new Produto(codProduto, nomeProd, precoProd, marcaProd, usuarioProd);

                                                    Console.WriteLine(produtoR.Cadastrar(novoProduto));
                                                    cont += 1;
                                                }

                                            }
                                            if (cont == 0)
                                            {
                                                Console.WriteLine($"Não existe nenhuma marca com o nome {marcaProduto} registrado no sistema!");
                                                Console.Write("Continuar no cadastro de produtos? (s/n)");
                                                continuar = Console.ReadLine().ToLower();
                                            }
                                            else
                                            {
                                                continuar = "n";
                                            }
                                        } while (continuar != "n");
                                        break;

                                        case "4":
                                        if (marcaR.ListarMarca().Count != 0)
                                        {
                                            Console.Write("Qual o código do produto que você quer deletar? ");
                                            string codigoUs = Console.ReadLine();
                                            int codigoPr;
                                            BoolDelete = int.TryParse(codigoUs, out codigoPr);

                                            if (BoolDelete)
                                            {
                                                codigoPr = int.Parse(codigoUs);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Inválido, Insira apenas números!");
                                            }
                                            if (codigoPr == 0)
                                            {
                                                Console.WriteLine("Você não removeu nenhum dos produtos!");
                                            }
                                            else
                                            {
                                                if (codigoPr > codProduto || codigoPr < 0)
                                                {
                                                    Console.WriteLine("\nCodigo Inválido!");
                                                }
                                                else
                                                {
                                                    Console.WriteLine(produtoR.Deletar(produtoR.AcharProduto(codigoPr)));
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Você não possui produtos cadastrados para poder deletar");
                                        }
                                        break;

                                    case "5":

                                        Console.WriteLine("Qual marca queres cadastrar?");
                                        marcaName = Console.ReadLine().ToUpper();
                                        MarcaAd += 1;

                                        Console.WriteLine(marcaR.Cadastrar(new Marca(marcaName, MarcaAd)));
                                        opcaoValidaMenu = true;
                                        opcaoValida = false;
                                        break;

                                    case "6":

                                        Console.WriteLine("Qual o código da marca que você quer deletar? ");
                                        string marcaCodigoS = Console.ReadLine();

                                        int marcaDeletar;
                                        BoolDelete = int.TryParse(marcaCodigoS, out marcaDeletar);

                                        if (BoolDelete)
                                        {
                                            marcaDeletar = int.Parse(marcaCodigoS);
                                            if (marcaDeletar == 0)
                                            {
                                                Console.WriteLine("Você não removeu nenhuma das marcas!");
                                            }
                                            else
                                            {
                                                if (marcaDeletar > MarcaAd || marcaDeletar < 0)
                                                {
                                                    Console.WriteLine("\nCódigo Inválido!");
                                                }
                                                else
                                                {
                                                    Console.WriteLine(marcaR.Deletar(marcaR.ListarMarca().Find(x => x.ListarCodigoM() == marcaDeletar)));
                                                }
                                            }
                                        }
                                        else
                                        {

                                            Console.WriteLine("Você não possui marcas cadastradas para poder deletar");
                                        }

                                        opcaoValidaMenu = true;
                                        opcaoValida = false;
                                        break;

                                    case "7":
                                        Console.WriteLine(@"
== Código ===== Nome Marca ==   
");
                                        foreach (Marca item in marcaR.ListarMarca())
                                        {
                                            Console.WriteLine($@"                              
{item.Codigo}       -       {item.NomeMarca}");
                                        }
                                        break;

                                    case "8":
                                        Console.WriteLine(@"
== Codigo ==== Nome ===== Marca ==== Preço ==   
");
                                        foreach (Produto produto in produtoR.Listar())
                                        {
                                            Console.WriteLine($@"
{produto.ListarOCodigoP()}      {produto.ListarONomeP()}  -   {produto.ListarAMarcaP()}   -    {produto.ListarOPrecoP():C2} (Cadastrado por: {produto.ListarEmailP()})");
                                        }
                                        break;

                                    case "9":
                                        Console.WriteLine(Deslogar(usuario));
                                        opcaoValidaMenu = false;
                                        break;

                                    case "X":
                                        Console.WriteLine("Tem certeza que deseja deletar o usuário? (s/n)");
                                        string escolha = Console.ReadLine();
                                        if (escolha == "s")
                                        {
                                            Console.WriteLine(usuario.Deletar(usuario));
                                            opcaoValidaMenu = false;
                                        }
                                        else if (escolha == "n")
                                        {
                                            opcaoValidaMenu = true;
                                            opcaoValida = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Opção inválida");
                                            opcaoValidaMenu = true;
                                            opcaoValida = false;
                                        }
                                        break;

                                    default:
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("OPÇÃO INVÁLIDA!!!");
                                        Console.ResetColor();
                                        opcaoValida = false;
                                        break;
                                }
                            } while (opcaoValidaMenu);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("ERRO!!! USUARIO NÃO ENCONTRADO - PRECISA SE CADASTRAR PARA FAZER LOGIN");
                            Console.ResetColor();
                            opcaoValida = false;
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