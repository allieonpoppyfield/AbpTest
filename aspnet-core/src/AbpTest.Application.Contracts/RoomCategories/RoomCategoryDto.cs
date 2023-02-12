using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace AbpTest.RoomCategories;

public class RoomCategoryDto
{
    public string Name { get; set; }
    public int AreaFrom { get; set; }
    public decimal PriceForSinglePlacement { get; set; }
    public decimal PriceForDoublePlacement { get; set; }
}
