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

        private string modalTitle = "";
        private bool somenteLeitura = false;

        [Inject] private IMovimentacaoService _service { get; set; }

        public string Title { get; set; } = "Movimentações";

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

            await _service.AdicionarAsync(dto); 

            await grid.RefreshDataAsync();
            await modal.HideAsync();
            StateHasChanged();
        }

        private async Task OpenModal()
        {
            modalTitle = "Nova movimentação";
            somenteLeitura = false;
            await modal.ShowAsync();
            modalComponent?.Limpar();
        }

        private async Task Visualizar(int id)
        {
            var data = await _service.BuscarPorIdAsync(id);

            modalTitle = "Visualizar movimentação";
            somenteLeitura = true;

            await modal.ShowAsync();

            modalComponent.Limpar();
            await modalComponent.PreencherDados(data);
        }

        private async Task Inativar(int id)
        {
            //var data = await _service.BuscarPorIdAsync(id);
            //modalTitle = "Editar movimentação";
            //somenteLeitura = false;
            //await modal.ShowAsync();
            //modalComponent.Limpar();
            //await modalComponent.PreencherDados(data);
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
