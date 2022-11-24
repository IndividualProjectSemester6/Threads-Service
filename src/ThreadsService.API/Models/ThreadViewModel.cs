namespace ThreadsService.API.Models
{
    public class ThreadViewModel
    {
        public Guid Id { get; set; }
        public string TopicName { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEdited { get; set; }

        public ThreadViewModel(Guid id, string topicName, string content, string author, DateTime createdAt, DateTime lastEdited)
        {
            Id = id;
            TopicName = topicName;
            Content = content;
            Author = author;
            CreatedAt = createdAt;
            LastEdited = lastEdited;
        }

        public ThreadViewModel()
        {
        }
    }
}
