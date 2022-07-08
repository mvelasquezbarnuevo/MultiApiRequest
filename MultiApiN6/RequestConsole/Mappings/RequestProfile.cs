using AutoMapper;
using RequestConsole.Models;

namespace RequestConsole.Mappings
{
    internal class RequestProfile: Profile
    {
        public RequestProfile()
        {
            CreateMap<Request, XmlRequest>()
                .ForMember(dest =>
                        dest.Source,
                    opt => opt.MapFrom(src => src.SourceAddress))
                .ForMember(dest =>
                        dest.Destination,
                    opt => opt.MapFrom(src => src.DestinationAddress))

                .ForMember(dest =>
                    dest.Packages,
                opt => opt.MapFrom(src => src.CartonDimensions));


            CreateMap<Dimension, Package>();


            CreateMap<Request,JsonThreeRequest>()
                .ForMember(dest =>
                        dest.Consignee,
                    opt => opt.MapFrom(src => src.SourceAddress))
                .ForMember(dest =>
                        dest.Consignor,
                    opt => opt.MapFrom(src => src.DestinationAddress))

                .ForMember(dest =>
                        dest.Cartons,
                    opt => opt.MapFrom(src => src.CartonDimensions));


            CreateMap<Dimension, Carton>();
        }
    }
}
