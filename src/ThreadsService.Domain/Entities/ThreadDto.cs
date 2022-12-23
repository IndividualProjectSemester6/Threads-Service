namespace ThreadsService.Domain.Entities
{
    public class ThreadDto
    {
        public Guid Id { get; set; }
        public Guid ForumId { get; set; }
        public string TopicName { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEdited { get; set; }

        public ThreadDto(Guid id, Guid forumId, string topicName, string content, string author, DateTime createdAt, DateTime lastEdited)
        {
            Id = id;
            ForumId = forumId;
            TopicName = topicName;
            Content = content;
            Author = author;
            CreatedAt = createdAt;
            LastEdited = lastEdited;
        }

        public ThreadDto()
        {
        }
    }
}