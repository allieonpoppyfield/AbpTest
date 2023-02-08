using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace AbpTest.Entities;

public class Hotel : BasicAggregateRoot<long>
{
    public string Name { get; set; }
    public string Link { get; set; }
    public float PriceFrom { get; set; }
    public List<HotelRoomCategory> HotelRoomCategories { get; set; }
}