using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpTest.Hotels;

public interface IHotelRepository : IRepository<Hotel, Guid>
{
    Task<Hotel> FindByNameAsync(string name);
    Task<List<Hotel>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter);
}
