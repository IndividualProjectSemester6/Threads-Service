namespace ThreadsService.API.Models
{
    public class CreateThreadViewModel
    {
        public Guid ForumId { get; set; }
        public string TopicName { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public CreateThreadViewModel(Guid forumId, string topicName, string content, string author)
        {
            ForumId = forumId;
            TopicName = topicName;
            Content = content;
            Author = author;
        }

        public CreateThreadViewModel()
        {
        }
    }
}
