using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlbumStore.Models
{
    public class AlbumGenre
    {
        [Key]
        public int AlbumGenreId { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public int MusicGenreId { get; set; }
        public MusicGenre MusicGenre { get; set; }

        public AlbumGenre(int albumId, int musicGenreId)
        {
            AlbumId = albumId;
            MusicGenreId = musicGenreId;
        }
    }
}
