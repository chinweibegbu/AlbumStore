using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlbumStore.Models
{
    public class AlbumGenre
    {
        [Key]
        public int AlbumGenreId { get; set; }
        
        [Required]
        public Genre Name { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public int GenreId { get; set; }
        public MusicGenre MusicGenre { get; set; }
    }
}
