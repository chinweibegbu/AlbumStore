using AlbumStore.DTOs.InternalClasses;
using AlbumStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlbumStore.DTOs
{
    public class AlbumSearchDto
    {
        public string AlbumName { get; set; }
        
        public string[] Genres { get; set; }

        public AlbumArtistReadDto Artist { get; set; }
    }
}
