namespace ControleDeBar.ConsoleApp
{
    public class ProgramComExemploDeDelegates1
    {
        delegate int OperacaoMatematica(int numero01, int numero02);

        static void Main1(string[] args)
        {
            //Delegates - ponteiro para métodos

            OperacaoMatematica operacao = Somar; //atribuindo o endereço de um método a uma variável

            int resultadoDaSoma = (int)operacao(10, 10); //invocar o método e o retorno atribuindo a uma variável

            operacao = Subtrair;

            int resutaldoDaSubtracao = (int)operacao(50, 10);

            operacao = Dividir;

            int resultadoDaDivisao = (int)operacao(50, 10);

            Console.WriteLine(resultadoDaSoma);

            Console.WriteLine(resutaldoDaSubtracao);
        }

        static int Somar(int x, int y)
        {
            return x + y;
        }

        static int Subtrair(int x, int y)
        {
            return x - y;
        }

        static int Dividir(int x, int y)
        {
            return x / y;
        }
    }
}
