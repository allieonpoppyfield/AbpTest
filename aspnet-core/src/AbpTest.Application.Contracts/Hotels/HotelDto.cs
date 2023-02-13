using AbpTest.HotelImages;
using AbpTest.RoomCategories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace AbpTest.Hotels;

public class HotelDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string Link { get; set; }
    public decimal PriceFrom { get; set; }

    public List<RoomCategoryDto> RoomCategories { get; set; }
    public List<HotelImageDto> HotelImages { get; set; }
}
