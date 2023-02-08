using AbpTest.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpTest.Interfaces;

public interface IAbpTestService : IApplicationService
{
    public Task<HotelRoomCategoryDto> CreateHotelRoomCategoryAsync(CreateHotelRoomCategoryDto hotelDto);


    Task<IEnumerable<HotelRoomCategoryDto>> GetHotelRoomCategoriesByHotelId(long hotelID);
    Task<IEnumerable<HotelDto>> GetHotelsAsync();
    
    public Task<HotelDto> CreateHotelAsync(CreateHotelDto hotelDto);
    
    public Task DeleteHotel(long hotelID);  
}
