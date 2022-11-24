namespace ThreadsService.API.Models
{
    public class UpdateThreadViewModel
    {
        public string TopicName { get; set; }
        public string Content { get; set; }

        public UpdateThreadViewModel(string topicName, string content)
        {
            TopicName = topicName;
            Content = content;
        }
    }
}
