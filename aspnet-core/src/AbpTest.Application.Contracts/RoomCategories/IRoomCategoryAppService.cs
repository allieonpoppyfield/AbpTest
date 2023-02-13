using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpTest.RoomCategories;

public interface IRoomCategoryAppService : IApplicationService
{
    Task<List<RoomCategoryDto>> GetListByHotelIdAsync(Guid hotelId, int skipCount, int maxResultCount, string sorting, string filter);
    Task<RoomCategoryDto> CreateAsync(CreateRoomCategoryDto input);
    Task CreateListForHotelAsync(Guid hotelId, List<RoomCategoryDto> input);
    Task DeleteAsync(Guid id);
    Task DeleteByHotelIdAsync(Guid hotelId);
    Task<RoomCategoryDto> UpdateAsync(UpdateRoomCategoryDto input);
}
