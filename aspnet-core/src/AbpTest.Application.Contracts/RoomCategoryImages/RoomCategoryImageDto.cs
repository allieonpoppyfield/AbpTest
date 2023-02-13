using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;

namespace AbpTest.RoomCategoryImages;

public class RoomCategoryImageDto 
{
    public string Name { get; set; }
    public string Extension { get; set; }
    public byte[] Content { get; set; }
}
