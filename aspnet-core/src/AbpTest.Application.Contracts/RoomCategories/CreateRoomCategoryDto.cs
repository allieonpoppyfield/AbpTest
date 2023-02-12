using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbpTest.RoomCategories;

public class CreateRoomCategoryDto
{
    [Required]
    public Guid HotelId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int AreaFrom { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public decimal PriceForSinglePlacement { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public decimal PriceForDoublePlacement { get; set; }
}
