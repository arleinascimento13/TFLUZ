using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using TFLUZ.Application.Interfaces;
using TFLUZ.Components.Shared;
using TFLUZ.Core.Models;
using TFLUZ.Utils;

namespace TFLUZ.Components.Pages
{
    public partial class Movimentacoes : ComponentBase
    {
        private MovimentacaoModal modalComponent;
        private Modal modal;
        private Grid<Movimentacao> grid;

        private string modalTitle = "";
        private bool somenteLeitura = false;
        private List<DescricaoMovimentacao> Descricoes { get; set; } 

        [Inject] private IMovimentacaoService _service { get; set; }
        [Inject] private IDescricaoMovimentacaoService _serviceDescricao { get; set; }

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
            // 1) Carrega as descrições (fora do modal, como você deseja)
            Descricoes = await _serviceDescricao.ListarAsync();

            // 2) Configura estado do modal
            modalTitle = "Nova movimentação";
            somenteLeitura = false;

            // 3) Limpa o estado do componente filho (se já renderizado)
            modalComponent?.Limpar();

            // 4) Garante que os parâmetros sejam propagados ao child antes de abrir
            await InvokeAsync(StateHasChanged);

            // 5) Agora abre o modal
            await modal.ShowAsync();
        }

        private async Task Visualizar(int id)
        {
            var data = await _service.BuscarPorIdAsync(id);

            modalTitle = "Visualizar movimentação";
            somenteLeitura = true;

            // Prepara child com dados
            modalComponent?.Limpar();
            if (modalComponent is not null)
                await modalComponent.PreencherDados(data);

            await InvokeAsync(StateHasChanged);
            await modal.ShowAsync();
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
            return GridUtils.DefinirCorLinhaGrid(mov);
        }
    }
}
