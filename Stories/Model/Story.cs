using System.Collections.Generic;

namespace Stories
{
    public class Story
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Descendants { get; set; }
        public List<int> Kids { get; set; }
        public int Score { get; set; }
        public int UnixTime { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
    }
}
