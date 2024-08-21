namespace TicketService
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
            public DateTime? ResolveDate { get; set; }
        public string Status {  get; set; }

    }
}
