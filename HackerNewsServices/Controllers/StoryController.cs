using HackerNewsServices.Caching;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stories.Interface;
using Stories.Repository;
using System;


namespace HackerNewsServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryController : ControllerBase
    {
        private IStory story = new StoryRepo();
        private ICacheProvider _cacheProvider;
        private readonly ILogger<StoryController> _logger;
        
        public StoryController(ILogger<StoryController> logger, ICacheProvider cacheProvider)
        {
            _logger = logger;
            _cacheProvider = cacheProvider;
        }


        [HttpGet("GetBestStories/{enterNumber}")]
        public IActionResult GetBestStories(int enterNumber)
        {
            try
            {
                var bestStories = _cacheProvider.GetCachedResponse().Result;
                return Ok(story.GetBestStories(bestStories, enterNumber));
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    StatusCode = 500,
                    Content = "{ \n error : " + ex.Message + "}",
                    ContentType = "application/json"
                };
            }
        }
    }
}
