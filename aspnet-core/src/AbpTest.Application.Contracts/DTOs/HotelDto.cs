using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpTest.DTOs;

public class HotelDto : EntityDto<long>
{
    public string Name { get; set; }
    public string Link { get; set; }
    public float PriceFrom { get; set; }
    public IEnumerable<HotelRoomCategoryDto> HotelRoomCategories { get; set; }
}
