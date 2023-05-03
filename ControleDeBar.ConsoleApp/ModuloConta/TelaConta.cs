using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase
    {
        private RepositorioConta repositorioConta;

        private TelaProduto telaProduto;
        private TelaGarcom telaGarcom;
        private TelaMesa telaMesa;

        public TelaConta(RepositorioConta repositorioConta, TelaGarcom telaGarcom, TelaProduto telaProduto, TelaMesa telaMesa)
        {
            this.repositorioBase = repositorioConta;
            this.repositorioConta = repositorioConta;

            this.telaProduto = telaProduto;
            this.telaGarcom = telaGarcom;

            nomeEntidade = "Conta";
            this.telaMesa = telaMesa;
        }

        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Emprestimos \n");

            Console.WriteLine("Digite 1 para Abrir Nova Conta");
            Console.WriteLine("Digite 2 para Registrar Pedidos");
            Console.WriteLine("Digite 3 para Fechar Conta");
            Console.WriteLine("Digite 4 para Visualizar Contas Abertas");
            Console.WriteLine("Digite 5 para Faturamento do Dia");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }       

        public void FecharConta()
        {
            ArrayList contasEmAberto = repositorioConta.SelecionarContasEmAberto();

            if (contasEmAberto.Count == 0)
            {
                MostrarMensagem("Nenhuma conta cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine("Digite o id da conta");
            int id = Convert.ToInt32(Console.ReadLine());

            Conta conta = repositorioConta.SelecionarPorId(id);

            conta.Fechar();

            MostrarMensagem("Conta fechada com sucesso", ConsoleColor.Green);
        }


        public override void InserirNovoRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Inserindo um novo registro...");

            Conta conta = (Conta)ObterRegistro();

            if (TemErrosDeValidacao(conta))
            {
                InserirNovoRegistro(); //chamada recursiva

                return;
            }

            repositorioBase.Inserir(conta);

            MostrarMensagem("Registro inserido com sucesso!", ConsoleColor.Green);

            CadastrarPedido(conta);
        }

        public void RegistrarPedidos()
        {
            ArrayList contasEmAberto = repositorioConta.SelecionarContasEmAberto();

            if (contasEmAberto.Count == 0)
            {
                MostrarMensagem("Nenhuma conta cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine("Digite o id da conta");
            int id = Convert.ToInt32(Console.ReadLine());

            Conta conta = repositorioConta.SelecionarPorId(id);

            CadastrarPedido(conta);
        }

        private void CadastrarPedido(Conta conta)
        {
            Console.Write("Selecionar produtos? s/n");

            Console.Write("-> ");

            string opcao = Console.ReadLine();

            while (opcao == "s")
            {
                Produto produto = ObterProduto();

                Console.Write("Digite a quantidade: ");
                int qtd = Convert.ToInt32(Console.ReadLine());

                conta.RegistrarPedido(produto, qtd);

                MostrarMensagem("Produto selecionado", ConsoleColor.Green);

                Console.WriteLine("Selecionar mais produtos? s/n");

                Console.Write("-> ");

                opcao = Console.ReadLine();
            }
        }       

        protected override void MostrarTabela(ArrayList registros)
        {
            foreach (Conta conta in registros)
            {
                string status = conta.estaAberta ? "Aberto" : "Fechado";
                Console.WriteLine(conta.id);              
                Console.WriteLine(conta.garcom.nome);                
            }
        }

        public void VisualizarContasEmAberto()
        {
            ArrayList contasEmAberto = repositorioConta.SelecionarContasEmAberto();

            if (contasEmAberto.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            MostrarTabela(contasEmAberto);
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaMesa.VisualizarRegistros(false);

            Mesa mesa = (Mesa)telaMesa.EncontrarRegistro("Digite o id da mesa: ");

            telaGarcom.VisualizarRegistros(false);

            Garcom garcom = (Garcom)telaGarcom.EncontrarRegistro("Digite o id do garçom: ");

            Conta conta = new Conta(garcom, mesa);

            return conta;
        }

        private Produto ObterProduto()
        {
            telaProduto.VisualizarRegistros(false);

            Produto produto = (Produto)telaProduto.EncontrarRegistro("Digite o id do Produto: ");

            Console.WriteLine();

            return produto;
        }

        internal void VisualizarFaturamento()
        {
            throw new NotImplementedException();
        }
    }
}
