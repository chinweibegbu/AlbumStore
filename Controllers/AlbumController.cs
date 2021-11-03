using AlbumStore.Data;
using AlbumStore.DTOs;
using AlbumStore.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlbumStore.Controllers
{
    [ApiController]
    [Route("api/albums")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _repository;
        private readonly IMapper _mapper;

        // Set up repository using dependency injection
        public AlbumController(IAlbumRepository iRepository, IMapper iMapper)
        {
            _repository = iRepository;
            _mapper = iMapper;
        }

        // GET api/albums/
        [HttpGet]
        public ActionResult<List<AlbumReadDto>> GetAllAlbums()
        {
            List<Album> artists = (List<Album>)_repository.GetAllAlbums();
            List<AlbumReadDto> artistReadDtos = _mapper.Map<List<AlbumReadDto>>(artists);
            return Ok(artistReadDtos);
        }

        // GET api/albums/{id}
        [HttpGet("{id}", Name = "GetAlbumById")]
        public ActionResult<AlbumReadDto> GetAlbumById(int id)
        {
            Album album = _repository.GetAlbumById(id);

            if (album == null)
            {
                return NotFound();
            }

            AlbumReadDto albumReadDto = _mapper.Map<AlbumReadDto>(album);

            return Ok(albumReadDto);
        }

        // POST api/albums/
        [HttpPost]
        public ActionResult<AlbumReadDto> CreateAlbum(AlbumWriteDto albumWriteDto)
        {
            Album albumToCreate = _mapper.Map<Album>(albumWriteDto);

            if (albumToCreate == null)
            {
                throw new ArgumentNullException();
            }

            _repository.CreateAlbum(albumToCreate);
            _repository.SaveChanges();

            // Get album (+ artist) from DB
            Album createdAlbum = _repository.GetAlbumById(albumToCreate.AlbumId);
            AlbumReadDto createdAlbumReadDto = _mapper.Map<AlbumReadDto>(createdAlbum);

            return CreatedAtRoute(nameof(GetAlbumById), new { Id = albumToCreate.AlbumId }, createdAlbumReadDto);
        }

        // PATCH api/albums/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateAlbum(int id, JsonPatchDocument<AlbumUpdateDto> patchDoc)
        {
            // Get album to update
            Album albumToUpdate = _repository.GetAlbumById(id);

            if (albumToUpdate == null)
            {
                return NotFound();
            }

            // Create mapping
            AlbumUpdateDto albumUpdateDto = _mapper.Map<AlbumUpdateDto>(albumToUpdate);

            // Update album
            patchDoc.ApplyTo(albumUpdateDto, ModelState);

            // Check model validity
            if (!TryValidateModel(albumToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            // Update with mapper
            _mapper.Map(albumUpdateDto, albumToUpdate);

            _repository.UpdateAlbum(albumToUpdate);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/albums/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAlbum(int id)
        {
            Album albumToDelete = _repository.GetAlbumById(id);

            if (albumToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteAlbum(albumToDelete);
            _repository.SaveChanges();

            return NoContent();
        }

        /*
        // GET api/albums/search?...
        [HttpGet("search")]
        public ActionResult<List<AlbumReadDto>> Search([FromQuery] AlbumReadDto? albumReadDto, [FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            // Create matching results
            List<Album> matches = new List<Album>();
            List<Album> completeMatches = new List<Album>();

            #pragma warning disable IDE0059 // Unnecessary assignment of a value
            bool trial = Enum.TryParse(albumReadDto.Genre, out Genre genre);
            #pragma warning restore IDE0059 // Unnecessary assignment of a value

            // Filter out based on search fields (name, genre, artist)
            if ((albumReadDto.AlbumName != null) && (albumReadDto.Genre != null) && (albumReadDto.Artist != null))
            {
                matches = (List<Album>)_repository.Search(albumReadDto.AlbumName, genre, albumReadDto.Artist.StageName);
            } else if ((albumReadDto.AlbumName == null) && (albumReadDto.Genre != null) && (albumReadDto.Artist != null))
            {
                matches = (List<Album>)_repository.Search(null, genre, albumReadDto.Artist.StageName);
            } else if ((albumReadDto.AlbumName != null) && (albumReadDto.Genre == null) && (albumReadDto.Artist != null))
            {
                matches = (List<Album>)_repository.Search(albumReadDto.AlbumName, null, albumReadDto.Artist.StageName);
            } else if ((albumReadDto.AlbumName != null) && (albumReadDto.Genre != null) && (albumReadDto.Artist == null))
            {
                matches = (List<Album>)_repository.Search(albumReadDto.AlbumName, genre, null);
            } else if ((albumReadDto.AlbumName != null) && (albumReadDto.Genre == null) && (albumReadDto.Artist == null))
            {
                matches = (List<Album>)_repository.Search(albumReadDto.AlbumName, null, null);
            } else if ((albumReadDto.AlbumName == null) && (albumReadDto.Genre != null) && (albumReadDto.Artist == null))
            {
                matches = (List<Album>)_repository.Search(null, genre, null);
            } else if ((albumReadDto.AlbumName == null) && (albumReadDto.Genre == null) && (albumReadDto.Artist != null))
            {
                matches = (List<Album>)_repository.Search(null, null, albumReadDto.Artist.StageName);
            } else if((albumReadDto.AlbumName == null) && (albumReadDto.Genre == null) && (albumReadDto.Artist == null))
            {
                matches = (List<Album>)_repository.GetAllAlbums();
            }

            // If it is empty, return NotFound()
            if (!matches.Any())
            {
                return NotFound();
            } else // If it is not empty, filter by date
            {
                for(int i = 0; i < matches.Count; i++)
                {
                    Album album = matches.ElementAt<Album>(i);

                    if (fromDate != null && toDate != null)
                    {
                        if (album.ReleaseDate >= fromDate && album.ReleaseDate <= toDate)
                        {
                            completeMatches.Add(album);
                        }
                    } else if (fromDate == null && toDate != null)
                    {
                        if (album.ReleaseDate <= toDate)
                        {
                            completeMatches.Add(album);
                        }
                    } else if (fromDate != null && toDate == null)
                    {
                        if (album.ReleaseDate >= fromDate)
                        {
                            completeMatches.Add(album);
                        }
                    } else
                    {
                        completeMatches = matches;
                        break;
                    }
                }
            }

            List<AlbumReadDto> matchDTOs = _mapper.Map<List<AlbumReadDto>>(completeMatches);

            return Ok(matchDTOs);
        }
        */
    }
}
