namespace EFCoreSample.Entitys
{
    public class Book
    {
        public long BookId { get; set; }
        public string? Title { get; set; }
        public DateTime PubTime { get; set; }
        public decimal Price { get; set; }
        public string? AuthorName { get; set; }

    }
}
