using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
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
                       
            Conta conta = new Conta(mesa01, garcom01);

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

            Conta conta = new Conta(mesa02, garcom01);

            conta.RegistrarPedido(produto01, 1);
            conta.RegistrarPedido(produto03, 3);

            conta.Fechar();
            
            return conta;
        }

        #endregion
        static void Main(string[] args)
        {
            RepositorioMesa repositorioMesa = new RepositorioMesa(new ArrayList());
            RepositorioProduto repoositorioProduto = new RepositorioProduto(new ArrayList());
            RepositorioGarcom repositorioGarcom = new RepositorioGarcom(new ArrayList());

            PopularAplicacao(repositorioMesa, repoositorioProduto, repositorioGarcom);

            RepositorioConta repositorioConta = new RepositorioConta(new ArrayList());  

            TelaMesa telaMesa = new TelaMesa(repositorioMesa);
            TelaProduto telaProduto = new TelaProduto(repoositorioProduto);
            TelaGarcom telaGarcom = new TelaGarcom(repositorioGarcom);

            TelaConta telaConta = new TelaConta(repositorioConta, telaMesa, telaGarcom, telaProduto);

            TelaPrincipal principal = new TelaPrincipal();

            while (true)
            {
                string opcao = principal.ApresentarMenu();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    string subMenu = telaMesa.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaMesa.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaMesa.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaMesa.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaMesa.ExcluirRegistro();
                    }
                }

                if (opcao == "2")
                {
                    string subMenu = telaProduto.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaProduto.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaProduto.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaProduto.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaProduto.ExcluirRegistro();
                    }
                }
                if (opcao == "3")
                {
                    string subMenu = telaGarcom.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaGarcom.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaGarcom.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaGarcom.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaGarcom.ExcluirRegistro();
                    }
                }

                if (opcao == "4")
                {
                    string subMenu = telaConta.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaConta.AbrirNovaConta();
                    }
                    else if (subMenu == "2")
                    {
                        telaConta.RegistrarPedidos();
                    }
                    else if (subMenu == "4")
                    {
                        telaConta.VisualizarContasAbertas();
                        Console.ReadLine();
                    }                    
                }
            }
        }

        private static void PopularAplicacao(RepositorioMesa repositorioMesa,
            RepositorioProduto repoositorioProduto, RepositorioGarcom repositorioGarcom)
        {
            Produto produto01 = new Produto("Batata Frita", 30);
            Produto produto03 = new Produto("Cerveja", 10);
            Produto produto02 = new Produto("Poleta Frita", 25);
            Produto produto04 = new Produto("Água", 4);

            Garcom garcom01 = new Garcom("Giordian Arrascaeta");
            Garcom garcom02 = new Garcom("Gersom Rubro Negro");

            Mesa mesa01 = new Mesa("01");
            Mesa mesa02 = new Mesa("02");

            repoositorioProduto.Inserir(produto01);
            repoositorioProduto.Inserir(produto02);
            repoositorioProduto.Inserir(produto03);
            repoositorioProduto.Inserir(produto04);

            repositorioMesa.Inserir(mesa01);
            repositorioMesa.Inserir(mesa02);

            repositorioGarcom.Inserir(garcom01);
            repositorioGarcom.Inserir(garcom02);
        }
    }
}