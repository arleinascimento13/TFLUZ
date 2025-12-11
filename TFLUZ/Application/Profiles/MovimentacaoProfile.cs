using AutoMapper;
using TFLUZ.Core.Models;
using TFLUZ.Infrastructure.Models;

namespace TFLUZ.Application.Profiles
{
    public class MovimentacaoProfile : Profile
    {
        public MovimentacaoProfile()
        {
            //
            // ENTITY → DOMAIN (CORE)
            //
            CreateMap<MovimentacaoEntity, Movimentacao>()
                .ForMember(dest => dest.Classificacao,
                    opt => opt.MapFrom(src => src.Classificacao))
                .ForMember(dest => dest.Descricao,
                    opt => opt.MapFrom(src => src.Descricao == null ? null : src.Descricao))
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status == null ? null : src.Status));

            //
            // DOMAIN (CORE) → ENTITY
            //
            CreateMap<Movimentacao, MovimentacaoEntity>()
                .ForMember(dest => dest.Classificacao, opt => opt.Ignore())
                .ForMember(dest => dest.ClassificacaoId,
                    opt => opt.MapFrom(src => src.Classificacao != null ? src.Classificacao.Id : (int?)null))

                // evita loop e protege nulos
                .ForMember(dest => dest.Descricao, opt => opt.Ignore())
                .ForMember(dest => dest.DescricaoId,
                    opt => opt.MapFrom(src => src.Descricao != null ? src.Descricao.Id : (int?)null))

                // evita loop e protege nulos
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.StatusId,
                    opt => opt.MapFrom(src => src.Status != null ? src.Status.Id : (int?)null));

            //
            // Descricao <-> DescricaoEntity
            //
            CreateMap<DescricaoMovimentacaoEntity, DescricaoMovimentacao>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            //
            // Status <-> StatusEntity
            //
            CreateMap<StatusMovimentacaoEntity, StatusMovimentacao>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<ClassificacaoMovimentacaoEntity, ClassificacaoMovimentacao>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}