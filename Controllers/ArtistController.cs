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
    [Route("api/artists")]
    public class ArtistController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IArtistService _service;

        // Set up repository using dependency injection
        public ArtistController(IMapper iMapper, IArtistService iService)
        {
            _mapper = iMapper;
            _service = iService;
        }

        // GET api/artists/
        [HttpGet]
        public ActionResult<List<ArtistReadDto>> GetAllArtists()
        {
            List<Artist> artists = (List<Artist>)_service.GetAllArtists();
            List<ArtistReadDto> artistReadDtos = _mapper.Map<List<ArtistReadDto>>(artists);
           
            return Ok(artistReadDtos);
        }

        // GET api/artists/solo
        [HttpGet("solo")]
        public ActionResult<List<SoloArtistReadDto>> GetAllSoloArtists()
        {
            List<SoloArtist> soloArtists = (List<SoloArtist>)_service.GetAllSoloArtists();
            List<SoloArtistReadDto> soloArtistReadDtos = _mapper.Map<List<SoloArtistReadDto>>(soloArtists);
            
            return Ok(soloArtistReadDtos);
        }

        // GET api/artists/{id}
        [HttpGet("{id}", Name = "GetArtistById")]
        public ActionResult<ArtistReadDto> GetArtistById(int id)
        {
            Artist artist= _service.GetArtistById(id);
            
            if (artist == null)
            {
                return NotFound();
            }

            ArtistReadDto artistReadDto = _mapper.Map<ArtistReadDto>(artist);

            return Ok(artistReadDto);
        }

        // POST api/artists/
        [HttpPost]
        public ActionResult CreateArtist(ArtistWriteDto artistWriteDto)
        {
            Artist artistToCreate = _mapper.Map<Artist>(artistWriteDto);

            if (artistToCreate == null)
            {
                throw new ArgumentNullException();
            }

            Artist createdArtist = _service.CreateArtist(artistToCreate);

            return CreatedAtRoute(nameof(GetArtistById), new { Id = artistToCreate.ArtistId }, createdArtist);
        }

        // POST api/artists/solo
        [HttpPost("solo")]
        public ActionResult CreateSoloArtist(SoloArtistWriteDto soloArtistWriteDto)
        {
            SoloArtist soloArtistToCreate = _mapper.Map<SoloArtist>(soloArtistWriteDto);

            if (soloArtistToCreate == null)
            {
                throw new ArgumentNullException();
            }

            SoloArtist createdSoloArtist = (SoloArtist)_service.CreateSoloArtist(soloArtistToCreate);

            return CreatedAtRoute(nameof(GetArtistById), new { Id = soloArtistToCreate.ArtistId }, createdSoloArtist);
        }

        // PATCH api/artists/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateArtist(int id, JsonPatchDocument<ArtistUpdateDto> patchDoc)
        {
            // Get artist to update
            Artist artistToUpdate = _service.GetArtistById(id);

            if (artistToUpdate == null)
            {
                return NotFound();
            }

            // Create mapping
            ArtistUpdateDto artistUpdateDto = _mapper.Map<ArtistUpdateDto>(artistToUpdate);

            // Update artist
            patchDoc.ApplyTo(artistUpdateDto, ModelState);

            // Check model validity
            if (!TryValidateModel(artistToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            // Update with mapper
            _mapper.Map(artistUpdateDto, artistToUpdate);

            _service.UpdateArtist(artistToUpdate);

            return NoContent();
        }

        // PATCH api/artists/solo/{id}
        [HttpPatch("solo/{id}")]
        public ActionResult UpdateSoloArtist(int id, JsonPatchDocument<SoloArtistUpdateDto> patchDoc)
        {
            // Get artist to update
            Artist soloArtistToUpdate = _service.GetArtistById(id);

            if (soloArtistToUpdate == null)
            {
                return NotFound();
            }

            // Create mapping
            SoloArtistUpdateDto soloArtistUpdateDto = _mapper.Map<SoloArtistUpdateDto>(soloArtistToUpdate);

            // Update artist
            patchDoc.ApplyTo(soloArtistUpdateDto, ModelState);

            // Check model validity
            if (!TryValidateModel(soloArtistToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            // Update with mapper
            _mapper.Map(soloArtistUpdateDto, soloArtistToUpdate);

            _service.UpdateArtist(soloArtistToUpdate);

            return NoContent();
        }

        // DELETE api/artists/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteArtist(int id)
        {
            Artist artistToDelete = _service.GetArtistById(id);

            if (artistToDelete == null)
            {
                return NotFound();
            }

            _service.DeleteArtist(artistToDelete);

            return NoContent();
        }
    }
}
