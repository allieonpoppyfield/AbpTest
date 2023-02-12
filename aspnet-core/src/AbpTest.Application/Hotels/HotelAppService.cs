using AbpTest.Permissions;
using AbpTest.RoomCategories;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace AbpTest.Hotels;

//[Authorize(AbpTestPermissions.Hotels.Default)]
public class HotelAppService : AbpTestAppService, IHotelAppService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelAppService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    //[Authorize(AbpTestPermissions.Hotels.Create)]
    public async Task<HotelDto> CreateAsync(CreateHotelDto input)
    {
        Hotel hotel = new()
        {
            Name = input.Name,
            Link = input.Link,
            PriceFrom = input.PriceFrom
        };
        await _hotelRepository.InsertAsync(hotel, true);
        return ObjectMapper.Map<Hotel, HotelDto>(hotel);
    }

    [Authorize(AbpTestPermissions.Hotels.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _hotelRepository.DeleteAsync(id);
    }

    public async Task<HotelDto> GetAsync(Guid id)
    {
        var hotel = await _hotelRepository.GetAsync(id);
        return ObjectMapper.Map<Hotel, HotelDto>(hotel);
    }

    public async Task<PagedResultDto<HotelDto>> GetListAsync(GetHotelListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Hotel.Name);
        }
        var hotels = await _hotelRepository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter);
        var totalCount = input.Filter == null
            ? await _hotelRepository.CountAsync()
            : await _hotelRepository.CountAsync(author => author.Name.Contains(input.Filter));
        return new PagedResultDto<HotelDto>(totalCount, ObjectMapper.Map<List<Hotel>, List<HotelDto>>(hotels));
    }

    [Authorize(AbpTestPermissions.Hotels.Edit)]
    public async Task UpdateAsync(Guid id, UpdateHotelDto input)
    {
        var hotel = await _hotelRepository.GetAsync(id);
        hotel.Name = input.Name;
        hotel.Link = input.Link;
        hotel.PriceFrom = input.PriceFrom;
        await _hotelRepository.UpdateAsync(hotel);
    }
}
