using AlbumStore.DTOs;
using AlbumStore.Models;
using AlbumStore.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AlbumStore.Controllers
{
    [ApiController]
    [Route("api/albums")]
    public class AlbumController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAlbumService _service;

        // Set up repository using dependency injection
        public AlbumController(IMapper iMapper, IAlbumService iService)
        {
            _mapper = iMapper;
            _service = iService;
        }

        // GET api/albums/
        [HttpGet]
        public ActionResult<List<AlbumReadDto>> GetAllAlbums()
        {
            List<Album> albums = (List<Album>)_service.GetAllAlbums();
            List<AlbumReadDto> albumReadDtos = _mapper.Map<List<AlbumReadDto>>(albums);
            
            return Ok(albumReadDtos);
        }

        // GET api/albums/{id}
        [HttpGet("{id}", Name = "GetAlbumById")]
        public ActionResult<AlbumReadDto> GetAlbumById(int id)
        {
            Album album = _service.GetAlbumById(id);

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

            Album createdAlbum = _service.CreateAlbum(albumToCreate, albumWriteDto.Genres);

            AlbumReadDto createdAlbumReadDto = _mapper.Map<AlbumReadDto>(createdAlbum);

            return CreatedAtRoute(nameof(GetAlbumById), new { Id = albumToCreate.AlbumId }, createdAlbumReadDto);
        }

        // PATCH api/albums/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateAlbum(int id, JsonPatchDocument<AlbumUpdateDto> patchDoc)
        {
            // Get album to update
            Album albumToUpdate = _service.GetAlbumById(id);

            if (albumToUpdate == null)
            {
                return NotFound();
            }

            // Create mapping
            AlbumUpdateDto albumUpdateDto = _mapper.Map<AlbumUpdateDto>(albumToUpdate);

            // Get updated patchDoc
            JsonPatchDocument<AlbumUpdateDto> updatePatchDoc = _service.UpdatePatchDoc(id, patchDoc);

            // Update (the filtered) album
            updatePatchDoc.ApplyTo(albumUpdateDto, ModelState);

            // Check model validity
            if (!TryValidateModel(albumToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            // Update with mapper
            _mapper.Map(albumUpdateDto, albumToUpdate);

            _service.UpdateAlbum(albumToUpdate);

            return NoContent();
        }

        // DELETE api/albums/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAlbum(int id)
        {
            Album albumToDelete = _service.GetAlbumById(id);

            if (albumToDelete == null)
            {
                return NotFound();
            }

            _service.DeleteAlbum(albumToDelete);

            return NoContent();
        }

        // GET api/albums/search?...
        [HttpGet("search")]
        public ActionResult<List<AlbumReadDto>> Search([FromQuery] AlbumSearchDto? albumSearchDto, [FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            try
            {
                List<Album> completeMatches = (List<Album>)_service.Search(albumSearchDto, fromDate, toDate);
                List<AlbumReadDto> matchDTOs = _mapper.Map<List<AlbumReadDto>>(completeMatches);

                return Ok(matchDTOs);
            }
            catch(Exception)
            {
                return NotFound();
            }
        }
    }
}
