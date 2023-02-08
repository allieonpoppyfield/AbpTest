using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpTest.DTOs;
public class HotelRoomCategoryDto : EntityDto<long>
{
    public string Name { get; set; }
    public int AreaFrom { get; set; }
}
