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

        // GET api/albums/{album}

        // POST api/albums/
        [HttpPost]
        public ActionResult CreateAlbum(AlbumWriteDto albumWriteDto)
        {
            Album albumToCreate = _mapper.Map<Album>(albumWriteDto);

            if (albumToCreate == null)
            {
                throw new ArgumentNullException();
            }

            _repository.CreateAlbum(albumToCreate);
            _repository.SaveChanges();

            // return Ok();
            return CreatedAtRoute(nameof(GetAlbumById), new { Id = albumToCreate.AlbumId }, albumToCreate);
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

        // GET api/albums/search?...
        [HttpGet("search")]
        public ActionResult<List<AlbumReadDto>> Search([FromQuery] AlbumReadDto? albumReadDto)
        {
            List<Album> matches = new List<Album>();

            if ((albumReadDto.AlbumName != null) && (albumReadDto.Genre != null) && (albumReadDto.Artist != null))
            {
                matches = (List<Album>)_repository.Search(albumReadDto.AlbumName, albumReadDto.Genre, albumReadDto.Artist.StageName);
            } else if ((albumReadDto.AlbumName == null) && (albumReadDto.Genre != null) && (albumReadDto.Artist != null))
            {
                matches = (List<Album>)_repository.Search(null, albumReadDto.Genre, albumReadDto.Artist.StageName);
            } else if ((albumReadDto.AlbumName != null) && (albumReadDto.Genre == null) && (albumReadDto.Artist != null))
            {
                matches = (List<Album>)_repository.Search(albumReadDto.AlbumName, null, albumReadDto.Artist.StageName);
            } else if ((albumReadDto.AlbumName != null) && (albumReadDto.Genre != null) && (albumReadDto.Artist == null))
            {
                matches = (List<Album>)_repository.Search(albumReadDto.AlbumName, albumReadDto.Genre, null);
            } else if ((albumReadDto.AlbumName != null) && (albumReadDto.Genre == null) && (albumReadDto.Artist == null))
            {
                matches = (List<Album>)_repository.Search(albumReadDto.AlbumName, null, null);
            } else if ((albumReadDto.AlbumName == null) && (albumReadDto.Genre != null) && (albumReadDto.Artist == null))
            {
                matches = (List<Album>)_repository.Search(null, albumReadDto.Genre, null);
            } else if ((albumReadDto.AlbumName == null) && (albumReadDto.Genre == null) && (albumReadDto.Artist != null))
            {
                matches = (List<Album>)_repository.Search(null, null, albumReadDto.Artist.StageName);
            } else if((albumReadDto.AlbumName == null) && (albumReadDto.Genre == null) && (albumReadDto.Artist == null))
            {
                matches = (List<Album>)_repository.GetAllAlbums();
            }

            if (!matches.Any())
            {
                return NotFound();
            }

            List<AlbumReadDto> matchDTOs = _mapper.Map<List<AlbumReadDto>>(matches);

            return Ok(matchDTOs);
        }
    }
}
