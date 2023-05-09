namespace ControleDeBar.ConsoleApp
{
    public class ProgramComExemploExtensionMethod
    {
        static void Main(string[] args)
        {
            string texto = 
                "B. Brusque, R. Mariluce Sutil dos Santos, nº 60, apto 32";

            int quantidadeDeNumeros = texto.ObterQuantidadeNumeros();
          

            int outroNumero = 9;

            outroNumero.EhPrimo();
        }      
    }

    
}
