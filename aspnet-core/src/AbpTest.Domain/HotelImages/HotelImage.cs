using AbpTest.Hotels;
using AbpTest.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AbpTest.HotelImages;

public class HotelImage : FullAuditedAggregateRoot<Guid>
{
    [Required]
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; }

    [Required]
    [StringLength(ImageConsts.MaxNameLength)]
    public string Name { get; set; }
    [Required]
    [StringLength(ImageConsts.MaxExtensionLength)]
    public string Extension { get; set; }
    
    [Required]
    public byte[] Content { get; set; }
}
