using System.Collections.Generic;

namespace UzywaneKsiazki.Models.DomainModels
{
    public class SearchResults
    {
        public int CurrentPage {  get; }
        public int TotalPages { get; }
        public int ItemsPerPage { get; }
        public IEnumerable<PostModel> Posts { get; }

        public SearchResults(int currentPage, int totalPages, int itemsPerPage, IEnumerable<PostModel> posts)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            ItemsPerPage = itemsPerPage;
            Posts = posts;
        }
    }
}