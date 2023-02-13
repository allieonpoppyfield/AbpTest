using System;
using Volo.Abp.Domain.Repositories;

namespace AbpTest.HotelImages;

public interface IHotelImageRepository : IRepository<HotelImage, Guid>
{
}
