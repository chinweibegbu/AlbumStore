using System;

namespace AlbumStore.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
