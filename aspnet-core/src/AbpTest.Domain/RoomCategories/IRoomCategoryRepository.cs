using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbpTest.RoomCategories;

public interface IRoomCategoryRepository
{
    Task<List<RoomCategory>> GetListByHotelIdAsync(Guid hotelId, int skipCount, int maxResultCount, string sorting, string filter);
}
