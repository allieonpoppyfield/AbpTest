using AbpTest.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace AbpTest.HotelImages;

public class CreateHotelImageDto
{
    [Required]
    public Guid HotelId { get; set; }

    [Required]
    [StringLength(ImageConsts.MaxNameLength)]
    public string Name { get; set; }
    [Required]
    [StringLength(ImageConsts.MaxExtensionLength)]
    public string Extension { get; set; }

    [Required]
    public byte[] Content { get; set; }

}
