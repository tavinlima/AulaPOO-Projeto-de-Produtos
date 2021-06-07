using ProjetoProdutos.Interfaces;

namespace ProjetoProdutos.Classes
{
    public class Login : ILogin
    {
        public bool Logado = true;
        public string Deslogar(Usuario usuario)
        {
            return "O usuario deslogou";
        }

        public string Logar(Usuario usuario)
        {
            return "O usuario logou";
        }

        void ILogin.Login()
        {
            throw new System.NotImplementedException();
        }
    }
}