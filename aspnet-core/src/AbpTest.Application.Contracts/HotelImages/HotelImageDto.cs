using AbpTest.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;

namespace AbpTest.HotelImages;

public class HotelImageDto 
{
    public string Name { get; set; }
    public string Extension { get; set; }
    public byte[] Content { get; set; }
}
