namespace TFLUZ.Core.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Observacao { get; set; }
        public StatusMovimentacao Status { get; set; }
        public TipoClassificacaoMovimentacao Classificacao { get; set; }
        public DescricaoMovimentacao Descricao { get; set; }
        public bool Ativo { get; set; } = true;

        public Movimentacao() { } // EF Constructor

        public Movimentacao(decimal valor, DateTime data, StatusMovimentacao pendente, string observacao, string descricao)
        {
            Valor = valor;
            Data = data;
            Observacao = observacao;
            Status = pendente;

            Classificacao = valor < 0 ? TipoClassificacaoMovimentacao.Despesa : TipoClassificacaoMovimentacao.Receita;
            Descricao = new DescricaoMovimentacao
            {
                Nome = descricao
            };
        }

        public static Movimentacao Criar(decimal valor, DateTime data, StatusMovimentacao pendente, string observacao, string descricao)
        {
            return new Movimentacao(valor, data, pendente, observacao, descricao);
        }
    }
}