using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace AbpTest.Hotels;

public class HotelAlreadyExistsException : BusinessException
{
	public HotelAlreadyExistsException(string name) : base(AbpTestDomainErrorCodes.HotelAlreadyExists)
	{
		WithData("name", name);
	}
}
