using TFLUZ.Core.Models;

namespace TFLUZ.Utils
{
    public static class GridUtils
    {
        private static readonly Dictionary<string, string> ClassificaoCssMap = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase)
        {
            { "Receita", "linha-receita" },
            { "Despesa", "linha-despesa" },
        };
        public static string DefinirCorLinhaGrid(object mov)
        {
            if (mov is Movimentacao movimentacao)
            {
                ClassificaoCssMap.TryGetValue(movimentacao.Classificacao.Nome, out var cssClass);
                return cssClass!;
            }

            if (mov is DescricaoMovimentacao descricaoMovimentacao)
            {
                return string.Empty;
                //return (int)descricaoMovimentacao. == 1 ? "linha-receita" : "linha-despesa";
            }

            return string.Empty;
        }
    }
}
