using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using TFLUZ.Application.Interfaces;
using TFLUZ.Components.Shared;
using TFLUZ.Core.Models;

namespace TFLUZ.Components.Pages
{
    public partial class Movimentacoes : ComponentBase
    {
        private MovimentacaoModal modalComponent;
        private Modal modal;
        private Grid<Movimentacao> grid;

        [Inject] private IMovimentacaoService _service { get; set; }

        public string Title { get; set; } = "Movimentações";

        //public List<Movimentacao> MovimentacoesList { get; set; } = new List<Movimentacao>(); // alterar para chamar serviço de listagem

        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
        }

        private async Task<GridDataProviderResult<Movimentacao>> MovimentacoesDataProvider(GridDataProviderRequest<Movimentacao> request)
        {
            var _mov = await _service.ListarAsync();
            return await Task.FromResult(request.ApplyTo(_mov));
        }

        public async Task ReceberMovimentacao(Movimentacao dto)
        {
            //var novaMov = new Movimentacao
            //{
            //    Valor = dto.Valor,
            //    Data = dto.Data,
            //    Observacao = dto.Observacao,
            //    Status = dto.Status,
            //    Descricao = dto.Descricao,
            //    Classificacao = dto.Classificacao
            //};

            await _service.AdicionarAsync(dto); //alterar para chamar serviço de adicionar

            await grid.RefreshDataAsync();
            await modal.HideAsync();
            StateHasChanged();
        }

        private async Task OpenModal()
        {
            await modal.ShowAsync();
        }

        private async Task CloseModal()
        {
            await modal.HideAsync();
        }

        private string DefinirCorLinha(Movimentacao mov)
        {
            return (int)mov.Classificacao == 1
                ? "linha-receita"
                : "linha-despesa";
        }
    }
}
