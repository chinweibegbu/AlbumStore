using System;
using System.ComponentModel.DataAnnotations;

namespace AlbumStore.Models
{
    public enum Genre
    {
        Default,                        // null
        Alternative,
        Anime,
        Blues,
        Children,
        Classical,
        Comedy,
        Dance,
        Electronic,
        Enka,                           
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

    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AlbumName { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        
        public Genre Genre { get; set; }
        
        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]      // For 2 decimal places
        [Range(0, 9999999999999999.99)]             // For maximum 18 places
        public decimal Price { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
