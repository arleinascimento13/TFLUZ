using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFLUZ.Core.Models;

namespace TFLUZ.Core.Interfaces
{
    public interface IMovimentacaoUseCase
    {
        //int contaId
        public Movimentacao RealizarMovimentacao(decimal valor, DateTime data, StatusMovimentacao pendente, string observacao, string descricao);
    }
}
