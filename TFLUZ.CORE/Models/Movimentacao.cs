using System.ComponentModel.DataAnnotations;

namespace TFLUZ.Core.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }

        [Required] [Display(Name = "Data")] public DateTime Data { get; set; }

        [Required] [Display(Name = "Valor da movimentação")] [Range(1, 999999)] public decimal Valor { get; set; }
        [Display(Name = "Observação")] [StringLength(500)] public string Observacao { get; set; }
        public StatusMovimentacao Status { get; set; }
        public ClassificacaoMovimentacao Classificacao { get; set; }
        public DescricaoMovimentacao Descricao { get; set; }
        public bool Ativo { get; set; } = true;

        public Movimentacao() { } // EF Constructor
    }
}