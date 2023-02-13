using AbpTest.HotelImages;
using AbpTest.RoomCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpTest.RoomCategoryImages;

public interface IRoomCategoryImageAppService : IApplicationService
{
    Task CreateListAsync(Guid roomCategoryId, List<RoomCategoryImageDto> input);
    Task<RoomCategoryImageDto> CreateAsync(CreateRoomCategoryImageDto input);
    Task DeleteAsync(Guid id);
    Task DeleteByRoomCategoryIdAsync(Guid roomCategoryId);
    Task DeleteManyAsync(IQueryable<Guid> ids);
}
