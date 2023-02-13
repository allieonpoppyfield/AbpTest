using AbpTest.HotelImages;
using AbpTest.Hotels;
using AbpTest.RoomCategories;
using AbpTest.RoomCategoryImages;
using AutoMapper;
using System;

namespace AbpTest;

public class AbpTestApplicationAutoMapperProfile : Profile
{
    public AbpTestApplicationAutoMapperProfile()
    {
        CreateMap<RoomCategory, RoomCategoryDto>().ReverseMap();
        CreateMap<CreateRoomCategoryDto, RoomCategory>();
        CreateMap<Hotel, HotelDto>().ReverseMap();
        CreateMap<Hotel, CreateHotelDto>().ReverseMap();
        CreateMap<Hotel, UpdateHotelDto>().ReverseMap();
        CreateMap<CreateHotelImageDto, HotelImage>().ReverseMap();
        CreateMap<HotelImageDto, HotelImage>().ReverseMap();
        CreateMap<RoomCategoryImageDto, RoomCategoryImage>().ReverseMap();
        CreateMap<CreateRoomCategoryImageDto, RoomCategoryImage>().ReverseMap();
        CreateMap<UpdateRoomCategoryDto, RoomCategoryDto>().ReverseMap();
    }
}
