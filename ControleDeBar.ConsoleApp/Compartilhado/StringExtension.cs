namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public static class StringExtension
    {
        public static int ObterQuantidadeNumeros(this string texto)
        {
            int quantidade = 0;

            foreach (char c in texto)
            {
                if (char.IsNumber(c))
                {
                    quantidade++;
                }
            }

            return quantidade;
        }
    }
}
