using AbpTest.RoomCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbpTest.Hotels;

public class CreateHotelDto
{
    [Required]
    [MaxLength(HotelConsts.MaxNameLength)]
    public string Name { get; set; }
    public string Link { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public decimal PriceFrom { get; set; }
}
