using System;
using System.ComponentModel.DataAnnotations;

namespace AlbumStore.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AlbumName { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        
        [MaxLength(50)]
        public string Genre { get; set; }
        
        [Required]
        public decimal Price { get; set; }
    }
}
