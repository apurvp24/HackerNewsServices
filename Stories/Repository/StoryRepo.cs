
using Newtonsoft.Json;
using Stories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Stories.Repository
{
    public class StoryRepo : IStory
    {
        #region PUBLIC METHODS
        public List<Story> GetBestStories(Dictionary<int, Story> bestStoriesCache, int enterNumber)
        {
            List<Story> stories = new List<Story>();            
            try
            {               
                stories = bestStoriesCache.Values.OrderByDescending(x => x.Score).Take(enterNumber).ToList();               
            }
            catch (Exception ex)
            {
                throw;
            }            
            return stories;
        }

        public List<Story> GetTopNBestStories(ref Dictionary<int, Story> bestStoriesCache)
        {
            List<Story> stories = new List<Story>();
            List<int> bestStoryIDs = new List<int>();
            HttpClient client = new HttpClient();
            try
            {
                if (bestStoriesCache == null)
                    bestStoriesCache = new Dictionary<int, Story>();

                if (bestStoriesCache.Count == 0)
                {
                    bestStoryIDs = GetBestStoriesIDs();
                    if (bestStoryIDs != null)
                    {
                        foreach (int id in bestStoryIDs)
                        {
                            Story s = GetStoryByID(id, client);
                            if (s != null)
                            {
                                bestStoriesCache.Add(id, s);
                            }
                        }
                    }
                }               
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                client.Dispose();
            }
            return stories;
        }
        #endregion

        #region PRIVATE METHODS
        private List<int> GetBestStoriesIDs()
        {
            List<int> stories = new List<int>();
            try
            {
                //Call Web API
                HttpClient client = new HttpClient();
                string bestStories = "https://hacker-news.firebaseio.com/v0/beststories.json";

                // List data response.
                HttpResponseMessage response = client.GetAsync(bestStories).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync();
                    if (data != null)
                    {
                        stories = JsonConvert.DeserializeObject<List<int>>(data.Result);

                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return stories;
        }
        private Story GetStoryByID(int StoryID, HttpClient client)
        {
            Story story = new Story();
            try
            {
                //Call Web API               
                string storyWithIDUrl = "https://hacker-news.firebaseio.com/v0/item/" + StoryID + ".json";

                // List data response.
                HttpResponseMessage response = client.GetAsync(storyWithIDUrl).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync();
                    if (data != null)
                    {
                        story = JsonConvert.DeserializeObject<Story>(data.Result);
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return story;
        }
        #endregion

    }
}
