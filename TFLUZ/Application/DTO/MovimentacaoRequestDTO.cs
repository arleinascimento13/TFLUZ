using System.ComponentModel.DataAnnotations;

namespace TFLUZ.Application.DTO
{
    public class MovimentacaoRequestDTO
    {
        [Required]
        [Display(Name = "Valor da movimentação")]
        [Range(1, 999999)]
        public decimal Valor { get; set; }

        [Required]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Required]
        [Display(Name = "Pendente?")]
        public bool Pendente { get; set; }

        [Display(Name = "Observação")]
        [StringLength(500)]
        public string Observacao { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(200)]
        public string Descricao { get; set; }
    }
}