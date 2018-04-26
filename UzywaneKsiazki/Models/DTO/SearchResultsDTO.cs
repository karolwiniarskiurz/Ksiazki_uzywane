using System.Collections.Generic;

namespace UzywaneKsiazki.Models.DTO
{
    public class SearchResultsDTO
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }
        public IEnumerable<PostModelDTO> Posts { get; set; }
    }
}