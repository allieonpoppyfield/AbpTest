using AbpTest.HotelImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpTest.EntityFrameworkCore.HotelImages;

public class EfCoreHotelImageRepository : EfCoreRepository<AbpTestDbContext, HotelImage, Guid>, IHotelImageRepository
{
	public EfCoreHotelImageRepository(IDbContextProvider<AbpTestDbContext> dbContextProvider) : base(dbContextProvider)
    {
	}
}
