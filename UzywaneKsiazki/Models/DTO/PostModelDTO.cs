using System;

namespace UzywaneKsiazki.Models.DTO
{
    public class PostModelDTO
    {
        public Guid Id { get; set; }

        public string AuthorName { get; set; }

        public DateTime DateOfPosting { get; set; }

        public string Telephone { get; set; }

        public string Adress { get; set; }

        public string[] Photos { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string StateOfBook { get; set; }

        public string BookAuthor { get; set; }

        public string PublishDate { get; set; }

        public decimal? Price { get; set; }
    }
}
