namespace ControleDeBar.ConsoleApp
{
    internal class ProgramComExemploDeDelegates2
    {
        static void Main2(string[] args)
        {
            ContaCorrente contaCorrente = new ContaCorrente();
            contaCorrente.conta = "33.688-2";

            contaCorrente.OcorreuAlteracao += MostrarAlteracaoEmConsole;
            contaCorrente.OcorreuAlteracao += MostrarAlteracaoEmArquivo;

            contaCorrente.Depositar(100);
            contaCorrente.Sacar(30);

            contaCorrente.Depositar(200);
            contaCorrente.Sacar(150);
        }

        static void MostrarAlteracaoEmConsole(string numeroConta, decimal saldo)
        {
            Console.WriteLine("Conta: " + numeroConta + ", Saldo Atualizado: " + saldo);
        }

        static void MostrarAlteracaoEmArquivo(string numeroConta, decimal saldo)
        {
            string conteudoArquivo = File.ReadAllText("Extrato.txt");

            conteudoArquivo += "Conta: " + numeroConta + ", Saldo Atualizado: " + saldo + "\n";

            File.WriteAllText("Extrato.txt", conteudoArquivo);
        }
    }

    public delegate void onAlteracaoEmSaldoEventHandler(string conta, decimal saldo); //definição

    public class ContaCorrente
    {        
        private decimal saldo;
        public string conta;
        
        public event onAlteracaoEmSaldoEventHandler OcorreuAlteracao; //declaração

        public void Sacar(decimal quantia)
        {
            if (quantia < saldo)
            {
                saldo -= quantia;
            }

            OcorreuAlteracao(conta, saldo); //invocação, chamada
        }        

        public void Depositar(decimal quantia) 
        {            
            saldo += quantia;

            OcorreuAlteracao(conta, saldo); //invocação, chamada
        }
    }
}
