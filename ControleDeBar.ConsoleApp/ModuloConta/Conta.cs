using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public Garcom garcom;
        public Mesa mesa;
        public ArrayList pedidos;

        public bool estaAberta;

        public Conta(Garcom garcom, Mesa mesa)
        {
            this.garcom = garcom;
            this.mesa = mesa;

            Abrir();
        }

        private void Abrir()
        {
            mesa.Ocupar();
            estaAberta = true;
        }

        public void RegistrarPedido(Produto produto, int qtd)
        {
            pedidos.Add(new Pedido(produto, qtd));
        }

        public decimal CalcularValorTotal()
        {
            decimal valorTotal = 0;

            foreach (Pedido pedido in pedidos)
            {
                valorTotal += pedido.CalcularValorParcial();
            }

            return valorTotal;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Conta contaAtualizada = (Conta)registroAtualizado;

            this.mesa = contaAtualizada.mesa;
            this.garcom = contaAtualizada.garcom;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            //if (string.IsNullOrEmpty(Total))
            //    erros.Add("O campo \"Garcom\" é obrigatório");

            return erros;
        }

        public void Fechar()
        {
            if (estaAberta)
            {
                estaAberta = false;
                mesa.Desocupar();
            }
        }    
    }
}
