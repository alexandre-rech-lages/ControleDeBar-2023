using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public string numero;
        private bool ocupada;

        public Mesa(string numeroMesa)
        {
            numero = numeroMesa;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizada = (Mesa)registroAtualizado;

            this.numero = mesaAtualizada.numero;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();         

            if (string.IsNullOrEmpty(numero.Trim()))
            {
                erros.Add("O campo \"Número da Mesa\" é obrigatorio");
            }
            return erros;
        }

        internal void Desocupar()
        {
            ocupada = false;
        }

        internal void Ocupar()
        {
            ocupada = true;
        }
    }
}
