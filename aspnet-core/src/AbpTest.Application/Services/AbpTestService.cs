using AbpTest.DTOs;
using AbpTest.Entities;
using AbpTest.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectMapping;

namespace AbpTest.Services;

public class AbpTestService : ApplicationService, IAbpTestService
{
    private readonly IRepository<Hotel, long> _hotelRepository;
    private readonly IRepository<HotelRoomCategory, long> _hotelRoomCategoryRepository;

    public AbpTestService(IRepository<Hotel, long> hotelRepository, IRepository<HotelRoomCategory, long> hotelRoomCategoryRepository)
    {
        _hotelRepository = hotelRepository;
        _hotelRoomCategoryRepository = hotelRoomCategoryRepository;
    }

    public async Task<HotelRoomCategoryDto> CreateHotelRoomCategoryAsync(CreateHotelRoomCategoryDto createHotelRoomCategoryDto)
    {
        var category = await _hotelRoomCategoryRepository.InsertAsync(new()
        {
            AreaFrom = createHotelRoomCategoryDto.AreaFrom,
            Name = createHotelRoomCategoryDto.Name,
        }, true);
        return ObjectMapper.Map<HotelRoomCategory, HotelRoomCategoryDto>(category);
    }

    public async Task DeleteHotel(long hotelID)
    {
        await _hotelRepository.DeleteAsync(hotelID);
    }

    public async Task<HotelDto> CreateHotelAsync(CreateHotelDto createHotelDto)
    {
        var hotel = ObjectMapper.Map<CreateHotelDto, Hotel>(createHotelDto);
        var categories = await GetHotelRoomCategoriesByIdList(createHotelDto.HotelRoomCategoryIds);
        hotel.HotelRoomCategories = new List<HotelRoomCategory>();
        hotel.HotelRoomCategories.AddRange(categories);
        await _hotelRepository.InsertAsync(hotel, true);
        return ObjectMapper.Map<Hotel, HotelDto>(hotel);
    }

    public async Task<IEnumerable<HotelRoomCategoryDto>> GetHotelRoomCategoriesByHotelId(long hotelID)
    {
        var hotel = (await _hotelRepository.WithDetailsAsync(x => x.HotelRoomCategories)).FirstOrDefault(x => x.Id == hotelID);
        if (hotel == null)
            return null;
        return ObjectMapper.Map<List<HotelRoomCategory>, List<HotelRoomCategoryDto>>(hotel.HotelRoomCategories);
    }

    public async Task<IEnumerable<HotelRoomCategoryDto>> GetHotelRoomCategories()
    {
        var list = await _hotelRoomCategoryRepository.ToListAsync();
        return ObjectMapper.Map<List<HotelRoomCategory>, List<HotelRoomCategoryDto>>(list);
    }

    public async Task<IEnumerable<HotelDto>> GetHotelsAsync()
    {
        var hotels = await _hotelRepository.WithDetailsAsync(x => x.HotelRoomCategories);
        var hotelList = hotels.ToList();
        return ObjectMapper.Map<List<Hotel>, List<HotelDto>>(hotelList);
    }

    private async Task<List<HotelRoomCategory>> GetHotelRoomCategoriesByIdList(List<long> ids)
    {
        var categories = await _hotelRoomCategoryRepository.GetQueryableAsync();
        return categories.Where(x => ids.Contains(x.Id)).ToList();
    }
}
