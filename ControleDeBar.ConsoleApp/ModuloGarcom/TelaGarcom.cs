using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class TelaGarcom : TelaBase
    {
        public TelaGarcom(RepositorioGarcom repositorioGarcom)
        {
            this.repositorioBase = repositorioGarcom;
            nomeEntidade = "Garçom";
            sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            foreach (Garcom garcom in registros)
            {
                Console.WriteLine(garcom.id);
                Console.WriteLine(garcom.nome);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite o nome do garçom: ");
            string nomeGarcom = Console.ReadLine();

            return new Garcom(nomeGarcom);
        }
    }
}
