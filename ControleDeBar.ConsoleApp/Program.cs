using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloPrincipal;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System.Collections;

namespace ControleDeBar.ConsoleApp
{
    internal class Program
    {
        #region exemplos
        static void Main2(string[] args)
        {
            RepositorioConta repositorioConta = new RepositorioConta(new ArrayList());

            Garcom garcom01 = new Garcom("Giordian Arrascaeta");
            Mesa mesa01 = new Mesa("01");

            Conta conta01 = CadastrarConta01(garcom01, mesa01);

            Mesa mesa02 = new Mesa("02");

            Conta conta02 = CadastrarConta02(garcom01, mesa02);

            repositorioConta.Inserir(conta01);

            repositorioConta.Inserir(conta02);

            ArrayList contas = repositorioConta.SelecionarTodos();
        }

        private static Conta CadastrarConta01(Garcom garcom01, Mesa mesa01)
        {
            Produto produto02 = new Produto("Poleta Frita", 25);
            Produto produto04 = new Produto("Água", 4);

            Conta conta = new Conta(mesa01, garcom01, new DateTime(2023, 5, 3));

            conta.RegistrarPedido(produto02, 1);
            conta.RegistrarPedido(produto04, 2);

            conta.Fechar();

            Console.WriteLine("Valor da conta R$:  " +
                conta.CalcularValorTotal() + " da mesa " + conta.mesa.numero);

            return conta;
        }

        private static Conta CadastrarConta02(Garcom garcom01, Mesa mesa02)
        {
            Produto produto01 = new Produto("Batata Frita", 30);
            Produto produto03 = new Produto("Cerveja", 10);

            Conta conta = new Conta(mesa02, garcom01, new DateTime(2023, 5, 4));

            conta.RegistrarPedido(produto01, 1);
            conta.RegistrarPedido(produto03, 3);

            conta.Fechar();

            return conta;
        }

        #endregion
        static void Main(string[] args)
        {            
            TelaPrincipal telaPrincipal = new TelaPrincipal();

            while (true)
            {
                TelaBase tela = telaPrincipal.SelecionarTela();

                if (tela == null)
                    break;
                
                if (tela is TelaConta)                
                    CadastrarContas(tela);                                    
                else  
                    ExecutarCadastros(tela);
            }
        }

        private static void ExecutarCadastros(TelaBase tela)
        {
            string subMenu = tela.ApresentarMenu();

            if (subMenu == "1")
            {
                tela.InserirNovoRegistro();
            }
            else if (subMenu == "2")
            {
                tela.VisualizarRegistros(true);
                Console.ReadLine();
            }
            else if (subMenu == "3")
            {
                tela.EditarRegistro();
            }
            else if (subMenu == "4")
            {
                tela.ExcluirRegistro();
            }
        }

        private static void CadastrarContas(TelaBase tela)
        {
            string subMenu = tela.ApresentarMenu();

            TelaConta telaConta = (TelaConta)tela;

            if (subMenu == "1")
            {
                telaConta.AbrirNovaConta();
            }
            else if (subMenu == "2")
            {
                telaConta.RegistrarPedidos();
            }
            else if (subMenu == "3")
            {
                telaConta.FecharConta();
            }
            else if (subMenu == "4")
            {
                telaConta.VisualizarContasAbertas();
                Console.ReadLine();
            }
            else if (subMenu == "5")
            {
                telaConta.VisualizarFaturamentoDoDia();
                Console.ReadLine();
            }
        }

    }
}