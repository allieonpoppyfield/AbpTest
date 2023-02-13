using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpTest.HotelImages;

public interface IHotelImageAppService : IApplicationService
{
    Task CreateListForHotelAsync(Guid hotelId, List<HotelImageDto> input);
    Task<HotelImageDto> CreateAsync(CreateHotelImageDto input);
    Task DeleteAsync(Guid id);
    Task DeleteByHotelIdAsync(Guid hotelId);
}
