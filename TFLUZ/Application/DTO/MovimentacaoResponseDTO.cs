using TFLUZ.Core.Models;

namespace TFLUZ.Application.DTO
{
    public class MovimentacaoResponseDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public StatusMovimentacao StatusMovimentacao { get; set; }
        public TipoClassificacaoMovimentacao TipoClassificacao { get; set; }
    }
}