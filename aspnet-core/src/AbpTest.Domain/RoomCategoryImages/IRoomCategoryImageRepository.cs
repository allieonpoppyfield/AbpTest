using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpTest.RoomCategoryImages;

public interface IRoomCategoryImageRepository : IRepository<RoomCategoryImage, Guid>
{
}
