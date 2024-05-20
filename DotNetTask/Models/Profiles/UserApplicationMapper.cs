using AutoMapper;
using DotNetTask.Models.DTO;
using DotNetTask.Models;

namespace TestWebAPIProj.Models.Profiles
{
    public class UserApplicationMapper:Profile
    {
        public UserApplicationMapper()
        {
            // Mapping for UserApplication to UserApplicationDTO
            CreateMap<UserApplication, UserApplicationDTO>()
                .ForMember(dest => dest.FormID, opt => opt.MapFrom(src => src.formID))
                .ForMember(dest => dest.NumericResponses, opt => opt.MapFrom(src => src.NumericResponse))
                .ForMember(dest => dest.ParagraphResponses, opt => opt.MapFrom(src => src.ParagraghResponse))
                .ForMember(dest => dest.MultipleChoiceResponses, opt => opt.MapFrom(src => src.MultipleChoiceResponse))
                .ForMember(dest => dest.YesOrNoResponses, opt => opt.MapFrom(src => src.YesOrNoResponse))
                .ForMember(dest => dest.DateResponses, opt => opt.MapFrom(src => src.DateResponse));

            // Mapping for Response subclasses
            CreateMap<NumericResponse, NumericResponseDTO>();
            CreateMap<ParagraphResponse, ParagraphResponseDTO>();
            CreateMap<MultipleChoiceResponse, MultipleChoiceResponseDTO>();
            CreateMap<YesOrNoResponse, YesOrNoResponseDTO>();
            CreateMap<DateResponse, DateResponseDTO>();


            // Mapping for UserApplication to UserApplicationDTO
            CreateMap<UserApplicationDTO, UserApplication>()
                .ForMember(dest => dest.formID, opt => opt.MapFrom(src => src.FormID))
                .ForMember(dest => dest.NumericResponse, opt => opt.MapFrom(src => src.NumericResponses))
                .ForMember(dest => dest.ParagraghResponse, opt => opt.MapFrom(src => src.ParagraphResponses))
                .ForMember(dest => dest.MultipleChoiceResponse, opt => opt.MapFrom(src => src.MultipleChoiceResponses))
                .ForMember(dest => dest.YesOrNoResponse, opt => opt.MapFrom(src => src.YesOrNoResponses))
                .ForMember(dest => dest.DateResponse, opt => opt.MapFrom(src => src.DateResponses));

            // Mapping for Response subclasses
            CreateMap<NumericResponse, NumericResponseDTO>();
            CreateMap<ParagraphResponse, ParagraphResponseDTO>();
            CreateMap<MultipleChoiceResponse, MultipleChoiceResponseDTO>();
            CreateMap<YesOrNoResponse, YesOrNoResponseDTO>();
            CreateMap<DateResponse, DateResponseDTO>();
        }
    }

}
