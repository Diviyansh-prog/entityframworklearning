namespace Entityframeworklearning.Data
{
    public class AddBook
    {
        
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int NumberOfPage { get; set; }
            public bool IsActive { get; set; }
            public DateTime CreatedTime { get; set; }
            public int LanguageId { get; set; }

        
    }
}
