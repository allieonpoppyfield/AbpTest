using AbpTest.Images;
using AbpTest.RoomCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AbpTest.RoomCategoryImages;

public class RoomCategoryImage : FullAuditedAggregateRoot<Guid>
{
    [Required]
    public Guid RoomCategoryId { get; set; }
    public RoomCategory RoomCategory { get; set; }

    [Required]
    [StringLength(ImageConsts.MaxNameLength)]
    public string Name { get; set; }
    [Required]
    [StringLength(ImageConsts.MaxExtensionLength)]
    public string Extension { get; set; }

    [Required]
    public byte[] Content { get; set; }
}
