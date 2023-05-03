using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta : RepositorioBase
    {
        public RepositorioConta(ArrayList listaContas)
        {
            listaRegistros = listaContas;
        }

        public ArrayList SelecionarContasEmAberto()
        {
            ArrayList contasEmAberto = new ArrayList();

            foreach (Conta conta in listaRegistros)
            {
                if (conta.estaAberta)
                    contasEmAberto.Add(conta);
            }

            return contasEmAberto;
        }
    }
}
