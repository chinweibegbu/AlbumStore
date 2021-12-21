using AlbumStore.DTOs;
using AlbumStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;

namespace AlbumStore.Services
{
    public interface IAlbumService
    {
        public IEnumerable<Album> GetAllAlbums();
        public Album GetAlbumById(int id);
        public Album CreateAlbum(Album album, string[] genres);
        public JsonPatchDocument<AlbumUpdateDto> UpdatePatchDoc(int id, JsonPatchDocument<AlbumUpdateDto> patchDoc);
        public void UpdateAlbum(Album album);
        public void DeleteAlbum(Album album);
        public IEnumerable<Album> Search(AlbumSearchDto? albumSearchDto, DateTime? fromDate, DateTime? toDate);
    }
}
