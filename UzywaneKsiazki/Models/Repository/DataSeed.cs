namespace UzywaneKsiazki.Models.Repository
{
    using System;
    using System.Linq;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using UzywaneKsiazki.Models.DomainModels;

    public class DataSeed
    {
        // populate localdb
        public static void Populate(IApplicationBuilder app)
        {
            // todo remove
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Posts.Any())
            {
                context.Posts.Add(
                    new PostModel
                    {
                        Adress = "ul.Torowa 21",
                        AuthorName = "Jan Kowalski",
                        BookAuthor = "Davies Norman",
                        DateOfPosting = DateTime.Now,
                        Description = "Najciekawsza podróż to podróż przez historię.",
                        Id = Guid.NewGuid(),
                        Photos =
                                new[]
                                    {
                                        "http://ecsmedia.pl/c/na-krance-swiata-podroz-historyka-przez-historie-w-iext50938458.jpg"
                                    },
                        Price = 25.12M,
                        PublishDate = "2017",
                        StateOfBook = "Nowa",
                        Telephone = "658752122",
                        Title = "Na krańce świata. Podróż historyka przez historię"
                    });
                context.SaveChanges();
            }
        }
    }
}