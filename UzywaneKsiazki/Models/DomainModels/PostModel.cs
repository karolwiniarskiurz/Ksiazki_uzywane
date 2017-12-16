namespace UzywaneKsiazki.Models.DomainModels
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PostModel
    {
        public Guid Id { get; set; }

        public string AuthorName { get; set; }

        public DateTime DateOfPosting { get; set; }

        public string Telephone { get; set; }

        // todo moze to bardziej rozbudowac ale nie wiem w sumie 
        public string Adress { get; set; }

        public string PhotosDb { get; set; }

        [NotMapped]
        public string[] Photos
        {
            get => this.PhotosDb.Split(';');

            set => this.PhotosDb = string.Join(';', value);
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string StateOfBook { get; set; }

        public string BookAuthor { get; set; }

        public string PublishDate { get; set; }

        public decimal? Price { get; set; }
    }
}