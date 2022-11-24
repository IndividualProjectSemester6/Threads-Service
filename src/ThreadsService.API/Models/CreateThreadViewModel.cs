namespace ThreadsService.API.Models
{
    public class CreateThreadViewModel
    {
        public string TopicName { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public CreateThreadViewModel(string topicName, string content, string author)
        {
            TopicName = topicName;
            Content = content;
            Author = author;
        }

        public CreateThreadViewModel()
        {
        }
    }
}
