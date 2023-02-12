//using AbpTest.Entities;
using AbpTest.RoomCategories;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AbpTest.Hotels;

public class Hotel : FullAuditedAggregateRoot<Guid>
{
    [Required]
    [MaxLength(HotelConsts.MaxNameLength)]
    public string Name { get; set; }
    public string Link { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public decimal PriceFrom { get; set; }
    public List<RoomCategory> RoomCategories { get; set; }
}
