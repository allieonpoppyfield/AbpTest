using AbpTest.Hotels;
using AbpTest.RoomCategories;
using AutoMapper;

namespace AbpTest;

public class AbpTestApplicationAutoMapperProfile : Profile
{
    public AbpTestApplicationAutoMapperProfile()
    {
        CreateMap<RoomCategory, RoomCategoryDto>();
        CreateMap<RoomCategoryDto, RoomCategory>();
        CreateMap<Hotel, HotelDto>();
        //CreateMap<CreateHotelDto, Hotel>();
    }
}
