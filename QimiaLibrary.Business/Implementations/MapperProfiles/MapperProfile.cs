using AutoMapper;
using QimiaLibrary.Business.Implementations.Queries.Books.BookDtos;
using QimiaLibrary.Business.Implementations.Queries.Reservations.ReservationDtos;
using QimiaLibrary.Business.Implementations.Queries.Workers.WorkerDtos;
using QimiaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.MapperProfiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Workers, WorkerDto>();

        CreateMap<Books, BookDto>();

        CreateMap<Reservations, ReservationDto>()
            .ForMember(dest => dest.RStatusID, opt => opt.MapFrom(src => src.RStatusID))
            .ForMember(dest => dest.WorkerID, opt => opt.MapFrom(src => src.WorkerID))
            .ForMember(dest => dest.BookID, opt => opt.MapFrom(src => src.BookID));
    }
}