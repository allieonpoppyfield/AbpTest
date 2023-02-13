using AbpTest.RoomCategoryImages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace AbpTest.RoomCategories;

public class RoomCategoryDto
{
    public string Name { get; set; }
    public int AreaFrom { get; set; }
    public decimal PriceForSinglePlacement { get; set; }
    public decimal PriceForDoublePlacement { get; set; }

    public List<RoomCategoryImageDto> RoomCategoryImages { get; set; }
}
