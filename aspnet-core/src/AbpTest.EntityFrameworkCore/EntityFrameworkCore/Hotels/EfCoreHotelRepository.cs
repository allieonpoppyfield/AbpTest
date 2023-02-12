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
            .Take(maxResultCount)
            .ToListAsync();
    }
}
