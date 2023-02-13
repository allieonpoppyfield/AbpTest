using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpTest.RoomCategories;

public interface IRoomCategoryRepository : IRepository<RoomCategory, Guid>
{
    Task<List<RoomCategory>> GetListByHotelIdAsync(Guid hotelId, int skipCount, int maxResultCount, string sorting, string filter);
}
