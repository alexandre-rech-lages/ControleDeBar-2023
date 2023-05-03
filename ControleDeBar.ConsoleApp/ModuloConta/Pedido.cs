using ControleDeBar.ConsoleApp.ModuloProduto;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Pedido
    {
        public Produto produto;
        public int qtd;

        public Pedido(Produto produto, int qtd)
        {
            this.produto = produto;
            this.qtd = qtd;
        }

        public decimal CalcularValorParcial()
        {
            return qtd * produto.preco;
        }
    }
}
