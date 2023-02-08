using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace AbpTest.Entities;

public class HotelRoomCategory : BasicAggregateRoot<long>
{
    public string Name { get; set; }
    public int AreaFrom { get; set; }
    public List<Hotel> Hotels { get; set; }
}
