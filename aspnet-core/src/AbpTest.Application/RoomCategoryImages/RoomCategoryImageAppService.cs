using AbpTest.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpTest.RoomCategoryImages;

[Authorize(AbpTestPermissions.RoomCategories.Edit)]
public class RoomCategoryImageAppService : AbpTestAppService, IRoomCategoryImageAppService
{
    private IRoomCategoryImageRepository _roomCategoryImageRepository;

    public RoomCategoryImageAppService(IRoomCategoryImageRepository roomCategorImageyRepository)
    {
        _roomCategoryImageRepository = roomCategorImageyRepository;
    }
    
    public async Task<RoomCategoryImageDto> CreateAsync(CreateRoomCategoryImageDto input)
    {
        var roomCategoryImage = ObjectMapper.Map<CreateRoomCategoryImageDto, RoomCategoryImage>(input);
        await _roomCategoryImageRepository.InsertAsync(roomCategoryImage, true);
        return ObjectMapper.Map<RoomCategoryImage, RoomCategoryImageDto>(roomCategoryImage);
    }

    public async Task CreateListAsync(Guid roomCategoryId, List<RoomCategoryImageDto> input)
    {
        var images = ObjectMapper.Map<List<RoomCategoryImageDto>, List<RoomCategoryImage>>(input);
        images.ForEach(x => x.RoomCategoryId = roomCategoryId);
        await _roomCategoryImageRepository.InsertManyAsync(images, true);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _roomCategoryImageRepository.DeleteAsync(id);
    }

    public async Task DeleteByRoomCategoryIdAsync(Guid roomCategoryId)
    {
        var query = await _roomCategoryImageRepository.GetQueryableAsync();
        await _roomCategoryImageRepository.DeleteManyAsync(query.Where(x => x.RoomCategoryId == roomCategoryId));
    }

    public async Task DeleteManyAsync(IQueryable<Guid> ids)
    {
        await _roomCategoryImageRepository.DeleteManyAsync(ids, true);
    }
}
