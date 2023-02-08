using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AbpTest.DTOs;

public class CreateHotelDto
{
    [Required]
    [StringLength(64)]
    public string Name { get; set; }
    [StringLength(64)]
    public string Link { get; set; }
    [Required]
    public float PriceFrom { get; set; }
    public List<long> HotelRoomCategoryIds { get; set; }
}
