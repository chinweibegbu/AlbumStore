using AlbumStore.Data;
using AlbumStore.DTOs;
using AlbumStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlbumStore.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _repository;
        public AlbumService(IAlbumRepository iRepository)
        {
            _repository = iRepository;
        }
        public IEnumerable<Album> GetAllAlbums()
        {
            return _repository.GetAllAlbums();
        }
        public Album GetAlbumById(int id)
        {
            return _repository.GetAlbumById(id);
        }

        public Album CreateAlbum(Album album, string[] genres)
        {
            _repository.CreateAlbum(album);
            _repository.SaveChanges();

            // Get album (+ artist) from DB
            int createdAlbumId = album.AlbumId;
            Album createdAlbum = _repository.GetAlbumById(createdAlbumId);

            // Set album genres
            if (genres.Length > 0)
            {
                _repository.SetGenres(createdAlbumId, genres);
                _repository.SaveChanges();
            }

            return createdAlbum;
        }

        public JsonPatchDocument<AlbumUpdateDto> UpdatePatchDoc(int id, JsonPatchDocument<AlbumUpdateDto> patchDoc)
        {
            // WITH GENRE CHANGE: Remove patchDoc with genre change(s)
            var operation = patchDoc.Operations.FirstOrDefault(op => op.path == "/genres");

            // Duplicate patchDoc
            JsonPatchDocument<AlbumUpdateDto> newPatchDoc = patchDoc;

            if (operation != null)
            {
                // Get new genres
                var newGenres = newPatchDoc.Operations.First(op => op.path == "/genres").value;

                // Remove replace genre operation from table
                newPatchDoc.Operations.Remove(operation);

                // Delete all album genres with that ID
                _repository.DeleteAlbumGenres(id);

                // Add all the new genres
                string[] newFormattedGenres = ((IEnumerable)newGenres).Cast<object>().Select(x => x.ToString()).ToArray();
                _repository.SetGenres(id, newFormattedGenres);
            }

            return newPatchDoc;
        }

        public void UpdateAlbum()
        {
            _repository.UpdateAlbum(null);
            _repository.SaveChanges();
        }

        public void DeleteAlbum(Album album)
        {
            _repository.DeleteAlbum(album);
            _repository.SaveChanges();

            _repository.DeleteAlbumGenres(album.AlbumId);
            _repository.SaveChanges();
        }

        public IEnumerable<Album> Search(AlbumSearchDto? albumSearchDto, DateTime? fromDate, DateTime? toDate)
        {
            // Create matching results
            List<Album> matches = new List<Album>();
            List<Album> completeMatches = new List<Album>();

            // Filter out based on search fields (name, genre, artist)
            if ((albumSearchDto.AlbumName != null) && (albumSearchDto.Genres != null) && (albumSearchDto.Artist != null))
            {
                matches = (List<Album>)_repository.Search(albumSearchDto.AlbumName, albumSearchDto.Genres, albumSearchDto.Artist.StageName);
            }
            else if ((albumSearchDto.AlbumName == null) && (albumSearchDto.Genres != null) && (albumSearchDto.Artist != null))
            {
                matches = (List<Album>)_repository.Search(null, albumSearchDto.Genres, albumSearchDto.Artist.StageName);
            }
            else if ((albumSearchDto.AlbumName != null) && (albumSearchDto.Genres == null) && (albumSearchDto.Artist != null))
            {
                matches = (List<Album>)_repository.Search(albumSearchDto.AlbumName, null, albumSearchDto.Artist.StageName);
            }
            else if ((albumSearchDto.AlbumName != null) && (albumSearchDto.Genres != null) && (albumSearchDto.Artist == null))
            {
                matches = (List<Album>)_repository.Search(albumSearchDto.AlbumName, albumSearchDto.Genres, null);
            }
            else if ((albumSearchDto.AlbumName != null) && (albumSearchDto.Genres == null) && (albumSearchDto.Artist == null))
            {
                matches = (List<Album>)_repository.Search(albumSearchDto.AlbumName, null, null);
            }
            else if ((albumSearchDto.AlbumName == null) && (albumSearchDto.Genres != null) && (albumSearchDto.Artist == null))
            {
                matches = (List<Album>)_repository.Search(null, albumSearchDto.Genres, null);
            }
            else if ((albumSearchDto.AlbumName == null) && (albumSearchDto.Genres == null) && (albumSearchDto.Artist != null))
            {
                matches = (List<Album>)_repository.Search(null, null, albumSearchDto.Artist.StageName);
            }
            else if ((albumSearchDto.AlbumName == null) && (albumSearchDto.Genres == null) && (albumSearchDto.Artist == null))
            {
                matches = (List<Album>)_repository.GetAllAlbums();
            }

            // If it is empty, return NotFound()
            if (!matches.Any())
            {
                throw new Exception();
            }
            else // If it is not empty, filter by date
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    Album album = matches.ElementAt(i);

                    if (fromDate != null && toDate != null)
                    {
                        if (album.ReleaseDate >= fromDate && album.ReleaseDate <= toDate)
                        {
                            completeMatches.Add(album);
                        }
                    }
                    else if (fromDate == null && toDate != null)
                    {
                        if (album.ReleaseDate <= toDate)
                        {
                            completeMatches.Add(album);
                        }
                    }
                    else if (fromDate != null && toDate == null)
                    {
                        if (album.ReleaseDate >= fromDate)
                        {
                            completeMatches.Add(album);
                        }
                    }
                    else
                    {
                        completeMatches = matches;
                        break;
                    }
                }
            }

            return completeMatches;
        }
    }
}
