using AutoMapper;
using WebApplication2.Database.Entities;
using WebApplication2.Models;

namespace WebApplication2.Mappings
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile() {

            AllowNullCollections = true;
/*
            CreateMap<MccCodesEntity, MccCSV>().ForMember(z=>z.code, opts=>opts.MapFrom(x=>x.Code))
                .ForMember(z => z.merchanttype, opts => opts.MapFrom(x => x.MerchantType));*/

            CreateMap<MccCSV, MccCodesEntity>().ForMember(z => z.Code, opts => opts.MapFrom(x => x.code))
                .ForMember(z => z.MerchantType, opts => opts.MapFrom(x => x.merchanttype));



            CreateMap<List<MccCSV>, List<MccCodesEntity>>().ReverseMap();



            //CreateMap<MccCodesEntity, MccCSV>().ForMember(z => z.merchanttype, opts => opts.MapFrom(x => x.MerchantType));


        }

        

    }
}