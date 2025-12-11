using System.ComponentModel.DataAnnotations;

namespace TFLUZ.Core.Models
{
    public class ClassificacaoMovimentacao
    {
        public int Id { get; set; }
        [Display(Name = "Descrição")][StringLength(200)] public string Nome { get; set; }
    }
}