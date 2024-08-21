using MongoDB.Bson;

namespace ResolutionAndCommentsService.models
{
    public class Comment
    {
        public ObjectId Id { get; set; }
        public int TicketId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
