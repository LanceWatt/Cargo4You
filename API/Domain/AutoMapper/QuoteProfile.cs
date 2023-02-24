using AutoMapper;
using Domain.Dtos;
using Domain.Models;

public class QuoteProfile : Profile
{
    public QuoteProfile()
    {
        CreateMap<ReceiveQuoteEnquiryDto, QuoteSubmissionDataDto>()
            .ForMember(dest => dest.ParcelWidth, opt => opt.MapFrom(src => src.WidthInCm))
            .ForMember(dest => dest.ParcelHeight, opt => opt.MapFrom(src => src.HeightInCm))
            .ForMember(dest => dest.ParcelLength, opt => opt.MapFrom(src => src.LengthInCm))
            .ForMember(dest => dest.ParcelWeight, opt => opt.MapFrom(src => src.WeightinKg));

        CreateMap<QuoteResponseData, QuoteSubmissionDataDto>()
            .ForMember(dest => dest.CompanySupplier, opt => opt.MapFrom(src => src.CompanySupplier))
            .ForMember(dest => dest.MostCompetitiveRate, opt => opt.MapFrom(src => src.MostCompetitiveRate))
            .ForMember(dest => dest.CompanyFound, opt => opt.MapFrom(src => src.Found));

        CreateMap<QuoteSubmissionDataDto, QuoteSubmissionData>();


    }
}