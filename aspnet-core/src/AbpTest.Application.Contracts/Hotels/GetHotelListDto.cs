using Volo.Abp.Application.Dtos;

namespace AbpTest.Hotels;

public class GetHotelListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
