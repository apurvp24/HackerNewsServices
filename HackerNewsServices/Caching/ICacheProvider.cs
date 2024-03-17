using System.Collections.Generic;
using System.Threading.Tasks;
using Stories;

namespace HackerNewsServices.Caching
{
	public interface ICacheProvider
	{
		Task<Dictionary<int, Story>> GetCachedResponse();
	}
}
