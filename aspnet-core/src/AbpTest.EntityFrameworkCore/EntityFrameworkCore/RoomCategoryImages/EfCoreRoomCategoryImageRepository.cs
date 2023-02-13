using AbpTest.Hotels;
using AbpTest.RoomCategoryImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpTest.EntityFrameworkCore.RoomCategoryImages;

public class EfCoreRoomCategoryImageRepository : EfCoreRepository<AbpTestDbContext, RoomCategoryImage, Guid>, IRoomCategoryImageRepository
{
    public EfCoreRoomCategoryImageRepository(IDbContextProvider<AbpTestDbContext> dbContextProvider) : base(dbContextProvider)
    { }
}
