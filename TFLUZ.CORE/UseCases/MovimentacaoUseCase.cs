using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFLUZ.Core.Interfaces;
using TFLUZ.Core.Models;

namespace TFLUZ.Core.UseCases
{
    public class MovimentacaoUseCase : IMovimentacaoUseCase
    {
        public Movimentacao RealizarMovimentacao(decimal valor, DateTime data, StatusMovimentacao pendente, string observacao, string descricao)
        {
            return Movimentacao.Criar(valor, data, pendente, observacao, descricao);
        }
    }
}
