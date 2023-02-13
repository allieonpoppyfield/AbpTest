using AbpTest.Hotels;
using AbpTest.Permissions;
using AbpTest.RoomCategoryImages;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpTest.RoomCategories;

[Authorize(AbpTestPermissions.RoomCategories.Default)]
public class RoomCategoryAppService : AbpTestAppService, IRoomCategoryAppService
{
    private readonly IRoomCategoryRepository _roomCategoryRepository;
    private readonly IRoomCategoryImageAppService _roomCategoryImageAppService;

    public RoomCategoryAppService(IRoomCategoryRepository roomCategoryRepository, IRoomCategoryImageAppService roomCategoryImageAppService)
    {
        _roomCategoryRepository = roomCategoryRepository;
        _roomCategoryImageAppService = roomCategoryImageAppService;
    }

    [Authorize(AbpTestPermissions.RoomCategories.Create)]
    public async Task<RoomCategoryDto> CreateAsync(CreateRoomCategoryDto input)
    {
        RoomCategory roomCategory = ObjectMapper.Map<CreateRoomCategoryDto, RoomCategory>(input);
        await _roomCategoryRepository.InsertAsync(roomCategory, true);
        return ObjectMapper.Map<RoomCategory, RoomCategoryDto>(roomCategory);
    }

    [Authorize(AbpTestPermissions.RoomCategories.Create)]
    public async Task CreateListForHotelAsync(Guid hotelId, List<RoomCategoryDto> input)
    {
        var categories = ObjectMapper.Map<List<RoomCategoryDto>, List<RoomCategory>>(input);
        categories.ForEach(x => x.HotelId = hotelId);
        await _roomCategoryRepository.InsertManyAsync(categories, true);
    }

    [Authorize(AbpTestPermissions.RoomCategories.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _roomCategoryRepository.DeleteAsync(id);
        await _roomCategoryImageAppService.DeleteByRoomCategoryIdAsync(id);
    }

    [Authorize(AbpTestPermissions.RoomCategories.Delete)]
    public async Task DeleteByHotelIdAsync(Guid hotelId)
    {
        var query = await _roomCategoryRepository.GetQueryableAsync();
        var filtered = query.Where(x => x.HotelId == hotelId);
        await _roomCategoryRepository.DeleteManyAsync(filtered);
        var roomCategoryImageIds = filtered.Select(x => x.RoomCategoryImages).SelectMany(x => x).Select(x => x.Id);
        await _roomCategoryImageAppService.DeleteManyAsync(roomCategoryImageIds);
    }

    public async Task<List<RoomCategoryDto>> GetListByHotelIdAsync(Guid hotelId, int skipCount, int maxResultCount, string sorting, string filter)
    {
        var cats = await _roomCategoryRepository.GetListByHotelIdAsync(hotelId, skipCount, maxResultCount, sorting, filter);
        return ObjectMapper.Map<List<RoomCategory>, List<RoomCategoryDto>>(cats);
    }

    [Authorize(AbpTestPermissions.RoomCategories.Edit)]
    public async Task<RoomCategoryDto> UpdateAsync(UpdateRoomCategoryDto input)
    {
        var roomCategory = await _roomCategoryRepository.GetAsync(input.Id);
        roomCategory.Name = input.Name;
        roomCategory.AreaFrom = input.AreaFrom;
        roomCategory.PriceForSinglePlacement = input.PriceForSinglePlacement;
        roomCategory.PriceForDoublePlacement = input.PriceForDoublePlacement;
        await _roomCategoryRepository.UpdateAsync(roomCategory);
        return ObjectMapper.Map<RoomCategory, RoomCategoryDto>(roomCategory);
    }
}
