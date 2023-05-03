namespace ControleDeBar.ConsoleApp
{
    public class TelaPrincipal
    {
        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Controle de Bar\n");

            Console.WriteLine("Digite 1 para Cadastrar Mesas");
            Console.WriteLine("Digite 2 para Cadastrar Produtos");
            Console.WriteLine("Digite 3 para Cadastrar Garçons");
            Console.WriteLine("Digite 4 para Cadastrar Contas");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}