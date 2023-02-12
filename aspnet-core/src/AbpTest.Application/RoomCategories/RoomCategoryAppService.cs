using AbpTest.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpTest.RoomCategories;

public class RoomCategoryAppService : AbpTestAppService, IRoomCategoryAppService
{
    private readonly IRoomCategoryRepository _roomCategoryRepository;
    public RoomCategoryAppService(IRoomCategoryRepository roomCategoryRepository)
    {
        _roomCategoryRepository = roomCategoryRepository;
    }

    public async Task<RoomCategoryDto> CreateAsync(CreateRoomCategoryDto input)
    {
        RoomCategory roomCategory = ObjectMapper.Map<CreateRoomCategoryDto, RoomCategory>(input);
        await _roomCategoryRepository.in
    }

    public async Task<List<RoomCategoryDto>> GetListByHotelIdAsync(Guid hotelId, int skipCount, int maxResultCount, string sorting, string filter)
    {
        var cats = await _roomCategoryRepository.GetListByHotelIdAsync(hotelId, skipCount, maxResultCount, sorting, filter);
        return ObjectMapper.Map<List<RoomCategory>, List<RoomCategoryDto>>(cats);
    }
}
