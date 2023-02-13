using AbpTest.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;


namespace AbpTest.EntityFrameworkCore.Hotels;

public class EfCoreHotelRepository : EfCoreRepository<AbpTestDbContext, Hotel, Guid>, IHotelRepository
{
	public EfCoreHotelRepository(IDbContextProvider<AbpTestDbContext> dbContextProvider) : base(dbContextProvider)
	{}

    public async Task<Hotel> FindByNameAsync(string name)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(hotel => hotel.Name == name);
    }

    public async Task<List<Hotel>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(!filter.IsNullOrWhiteSpace(), hotel => hotel.Name.Contains(filter)).OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount).Include(x => x.RoomCategories).ThenInclude(x => x.RoomCategoryImages) //Здесь вопрос, нужно ли их сразу тащить, либо подгружать по "Активному действию из ТЗ", в любом случае, метод для отдельной подгрузки тоже реализован
            .Include(x => x.HotelImages)
            .ToListAsync();
    }

    public async Task<Hotel> GetHotelAsync(Guid id)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.Include(x => x.RoomCategories).ThenInclude(x => x.RoomCategoryImages).Include(x => x.HotelImages).FirstOrDefaultAsync(hotel => hotel.Id == id);
    }
}
