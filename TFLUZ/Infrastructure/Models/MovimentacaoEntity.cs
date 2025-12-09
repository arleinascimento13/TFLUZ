namespace TFLUZ.Infrastructure.Models
{
    public class MovimentacaoEntity
    {
        public int Id { get; set; }

        // Armazenamos a data normalmente
        public DateTime Data { get; set; }

        // Armazenamos valor como decimal
        public decimal Valor { get; set; }

        // Observação opcional
        public string Observacao { get; set; }

        // Guardamos a classificação como int (não referenciamos o enum do Core aqui)
        public int Classificacao { get; set; }

        // Relacionamento com Status
        public int? StatusId { get; set; }
        public StatusMovimentacaoEntity Status { get; set; }

        // Relacionamento com Descricao
        public int? DescricaoId { get; set; }
        public DescricaoMovimentacaoEntity Descricao { get; set; }

        // Construtor vazio para EF
        public MovimentacaoEntity() { }
    }
}
