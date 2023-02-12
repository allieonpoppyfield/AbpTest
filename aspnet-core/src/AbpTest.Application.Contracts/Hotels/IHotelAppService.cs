using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpTest.Hotels;

public interface IHotelAppService : IApplicationService
{
    Task<HotelDto> GetAsync(Guid id);
    Task<PagedResultDto<HotelDto>> GetListAsync(GetHotelListDto input);
    Task<HotelDto> CreateAsync(CreateHotelDto input);
    Task UpdateAsync(Guid id, UpdateHotelDto input);
    Task DeleteAsync(Guid id);
}
