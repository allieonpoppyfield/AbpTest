using AbpTest.Permissions;
using AbpTest.RoomCategoryImages;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpTest.HotelImages;

[Authorize(AbpTestPermissions.Hotels.Edit)]
public class HotelImageAppService : AbpTestAppService, IHotelImageAppService
{
    private IHotelImageRepository _hotelImageRepository;

    public HotelImageAppService(IHotelImageRepository hotelImageRepository)
    {
        _hotelImageRepository = hotelImageRepository;
    }

    public async Task<HotelImageDto> CreateAsync(CreateHotelImageDto input)
    {
        var hotelImage = ObjectMapper.Map<CreateHotelImageDto, HotelImage>(input);
        await _hotelImageRepository.InsertAsync(hotelImage, true);
        return ObjectMapper.Map<HotelImage, HotelImageDto>(hotelImage);
    }

    public async Task CreateListForHotelAsync(Guid hotelId, List<HotelImageDto> input)
    {
        var images = ObjectMapper.Map<List<HotelImageDto>, List<HotelImage>>(input);
        images.ForEach(image => image.HotelId = hotelId);
        await _hotelImageRepository.InsertManyAsync(images, true);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _hotelImageRepository.DeleteAsync(id);
    }

    public async Task DeleteByHotelIdAsync(Guid hotelId)
    {
        var query = await _hotelImageRepository.GetQueryableAsync();
        await _hotelImageRepository.DeleteManyAsync(query.Where(x => x.HotelId == hotelId));
    }
}
