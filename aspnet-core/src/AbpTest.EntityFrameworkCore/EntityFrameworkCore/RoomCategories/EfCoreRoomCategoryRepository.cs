using AbpTest.EntityFrameworkCore;
using AbpTest.RoomCategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpTest.EntityFrameworkCore.RoomCategories;

public class EfCoreRoomCategoryRepository : EfCoreRepository<AbpTestDbContext, RoomCategory, Guid>, IRoomCategoryRepository
{
    public EfCoreRoomCategoryRepository(IDbContextProvider<AbpTestDbContext> dbContextProvider) : base(dbContextProvider)
    { }


    public async Task<List<RoomCategory>> GetListByHotelIdAsync(Guid hotelId, int skipCount, int maxResultCount, string sorting, string filter)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.Where(x => x.HotelId == hotelId).ToListAsync();
    }

    public async Task<RoomCategory> CreateAsync(CreateRoomca)
}
