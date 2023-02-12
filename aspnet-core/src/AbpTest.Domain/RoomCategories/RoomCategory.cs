using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AbpTest.RoomCategories;

public class RoomCategory : FullAuditedAggregateRoot<Guid>
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
