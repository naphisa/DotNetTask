using static System.Runtime.InteropServices.JavaScript.JSType;
using DotNetTask.Models.DTO;
using AutoMapper;

namespace DotNetTask.Models.Profiles
{
    public class ProgramInformationMapper: Profile
    {
        public ProgramInformationMapper()
        {
            CreateMap<ProgramInformationDTO, ProgramInformation>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.firstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.lastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
                ////.ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.phone))
                ////.ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.nationality))
                ////.ForMember(dest => dest.CurrentResidence, opt => opt.MapFrom(src => src.currentResidence))
                ////.ForMember(dest => dest.IDNumber, opt => opt.MapFrom(src => src.IDNumber))
                ////.ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                ////.ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.gender))
                .ForMember(dest => dest.NumericQuestions, opt => opt.MapFrom(src => src.NumericQuestions))
                .ForMember(dest => dest.ParagraghQuestions, opt => opt.MapFrom(src => src.ParagraghQuestions))
                .ForMember(dest => dest.MChoiceQuestions, opt => opt.MapFrom(src => src.MChoiceQuestions))
                .ForMember(dest => dest.YesOrNoQuestion, opt => opt.MapFrom(src => src.YesOrNoQuestion))
                .ForMember(dest => dest.DateQuestion, opt => opt.MapFrom(src => src.DateQuestion));

            CreateMap<NumericQuestionDTO, NumericQuestion>();
                
                
            CreateMap<ParagraghQuestionDTO, ParagraghQuestion>();
            CreateMap<MultipleChoiceQuestionDTO, MultipleChoiceQuestion>();
            CreateMap<YesOrNoQuestionDTO, YesOrNoQuestion>();
            CreateMap<DateQuestionDTO, DateQuestion>();

            CreateMap<ProgramInformation, ProgramInformationDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.firstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.lastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.NumericQuestions, opt => opt.MapFrom(src => src.NumericQuestions))
                .ForMember(dest => dest.ParagraghQuestions, opt => opt.MapFrom(src => src.ParagraghQuestions))
                .ForMember(dest => dest.MChoiceQuestions, opt => opt.MapFrom(src => src.MChoiceQuestions))
                .ForMember(dest => dest.YesOrNoQuestion, opt => opt.MapFrom(src => src.YesOrNoQuestion))
                .ForMember(dest => dest.DateQuestion, opt => opt.MapFrom(src => src.DateQuestion));

            CreateMap<NumericQuestion, NumericQuestionDTO>();
            CreateMap<ParagraghQuestion, ParagraghQuestionDTO>();
            CreateMap<MultipleChoiceQuestion, MultipleChoiceQuestionDTO>();
            CreateMap<YesOrNoQuestion, YesOrNoQuestionDTO>();
            CreateMap<DateQuestion, DateQuestionDTO>();
        }
    }

}
