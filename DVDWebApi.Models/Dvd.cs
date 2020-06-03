namespace DVDWebApi.Models
{
    public class Dvd
    {
        public int DvdId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public string Notes { get; set; }
        public string ImageFileName { get; set; }
    }
}
