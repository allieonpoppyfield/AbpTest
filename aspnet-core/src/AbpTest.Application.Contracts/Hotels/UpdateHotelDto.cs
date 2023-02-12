using AbpTest.Hotels;
using AbpTest.RoomCategories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class UpdateHotelDto
{
    [Required]
    [MaxLength(HotelConsts.MaxNameLength)]
    public string Name { get; set; }
    public string Link { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public decimal PriceFrom { get; set; }

    [Required]
    public List<RoomCategoryDto> RoomCategories { get; set; }
}