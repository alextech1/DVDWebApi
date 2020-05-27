namespace DVDWebApi.Models.Queries
{
    public class ListingSearchParameters
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int? ReleaseYear { get; set; }
        public string Rating { get; set; }
    }
}
