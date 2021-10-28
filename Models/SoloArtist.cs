using System.ComponentModel.DataAnnotations;

namespace AlbumStore.Models
{
    public class SoloArtist : Artist
    {
        [MaxLength(50)]
        public string Instrument { get; set; }
    }
}
