using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlbumStore.Models
{
    public enum Genre
    {
        Default,                        // null
        Alternative,                    // 1
        Anime,                          // 2
        Blues,                          // 3
        Children,                       // 4
        Classical,                      // 5
        Comedy,                         // 6
        Dance,                          // 7
        Electronic,                     // 8
        Enka,                           // 9
        Folk,                           // 10
        Gospel,                         // 11
        [Display(Name = "Hip-Hop/Rap")]
        HipHop,                         // 12
        Holiday,                        // 13
        Instrumental,                   // 14
        Jazz,                           // 15
        [Display(Name = "J-Pop")]
        JPop,                           // 16
        [Display(Name = "K-Pop")]
        KPop,                           // 17
        Latin,                          // 18
        Metal,                          // 19
        Opera,                          // 20
        Pop,                            // 21
        [Display(Name = "R&B/Soul")]
        Soul,                           // 22
        Reggae,                         // 23
        Rock,                           // 24
        Soundtrack,                     // 25
        Vocal                           // 26
    }

    public class MusicGenre
    {
        [Key]
        public int GenreId { get; set; }
        
        [Required]
        public Genre Name { get; set; }

        public List<AlbumGenre> AlbumGenres { get; set; }
    }
}
