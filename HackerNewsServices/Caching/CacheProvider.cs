using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Stories;
using Stories.Repository;

namespace HackerNewsServices.Caching
{
	public class CacheProvider : ICacheProvider
	{
		private static readonly SemaphoreSlim GetUsersSemaphore = new SemaphoreSlim(1, 1);

		private readonly IMemoryCache _cache;

		public CacheProvider(IMemoryCache memoryCache)
		{
			_cache = memoryCache;
		}

		public async Task<Dictionary<int, Story>> GetCachedResponse()
		{
			try
			{
				return await GetCachedResponse(CacheKeys.BestStoriesFromAPI, GetUsersSemaphore);
			}
			catch
			{
				throw;
			}			
		}

		private async Task<Dictionary<int, Story>> GetCachedResponse(string cacheKey, SemaphoreSlim semaphore)
		{
			bool isAvaiable = _cache.TryGetValue(cacheKey, out Dictionary<int, Story> bestStoriesCache);

			if (isAvaiable)
				return bestStoriesCache;

			try
			{
				await semaphore.WaitAsync();

				isAvaiable = _cache.TryGetValue(cacheKey, out bestStoriesCache);

				if (isAvaiable)
					return bestStoriesCache;

				StoryRepo objStoryRepo = new StoryRepo();
				objStoryRepo.GetTopNBestStories(ref bestStoriesCache);

				var cacheEntryOptions = new MemoryCacheEntryOptions
				{
					AbsoluteExpiration = DateTime.Now.AddMinutes(5),
					SlidingExpiration = TimeSpan.FromMinutes(2),
					Size = 1024,
				};

				_cache.Set(cacheKey, bestStoriesCache, cacheEntryOptions);
			}
			catch
			{
				throw;
			}
			finally
			{
				semaphore.Release();
			}

			return bestStoriesCache;
		}
	}
}
