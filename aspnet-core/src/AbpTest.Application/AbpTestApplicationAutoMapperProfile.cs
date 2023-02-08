using AbpTest.DTOs;
using AbpTest.Entities;
using AutoMapper;

namespace AbpTest;

public class AbpTestApplicationAutoMapperProfile : Profile
{
    public AbpTestApplicationAutoMapperProfile()
    {
        CreateMap<HotelRoomCategory, HotelRoomCategoryDto>();
        CreateMap<Hotel, HotelDto>();
        CreateMap<CreateHotelDto, Hotel>();
    }
}
