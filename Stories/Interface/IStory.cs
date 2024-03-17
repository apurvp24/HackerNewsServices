using System.Collections.Generic;

namespace Stories.Interface
{
    public interface IStory
    {
        /// <summary>
        /// This API will return top n best stories from bestsotries API.
        /// </summary>
        /// <param name="bestStoriesCache">
        /// This is a dict with <id,story> details. Its added in cache after first call.
        /// </param>
        /// <param name="n">
        /// This is a number to be accepted from user.
        /// </param>
        /// <returns></returns>                       
        List<Story> GetBestStories(Dictionary<int, Story> bestStoriesCache,int enterNumber);        
    }
}
