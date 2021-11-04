using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlbumStore.Models
{
    public class MusicGenre
        {
        [Key]
        public int MusicGenreId { get; set; }
        
        [Required]
        public string Name { get; set; }

        public List<AlbumGenre> AlbumGenres { get; set; }
    }
}
