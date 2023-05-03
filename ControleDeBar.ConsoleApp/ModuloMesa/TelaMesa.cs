using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class TelaMesa : TelaBase
    {
        public TelaMesa(RepositorioMesa repositorioMesa)
        {
            this.repositorioBase = repositorioMesa;
            nomeEntidade = "Mesa";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            foreach (Mesa mesa in registros)
            {
                Console.WriteLine(mesa.numero);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite o numero da mesa: ");
            string numeroMesa = Console.ReadLine();

            return new Mesa(numeroMesa);
        }
    }
}
