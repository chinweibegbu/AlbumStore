using AlbumStore.Data;
using AlbumStore.DTOs;
using AlbumStore.Models;
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
        private readonly IArtistRepository _repository;
        private readonly IMapper _mapper;

        // Set up repository using dependency injection
        public ArtistController(IArtistRepository iRepository, IMapper iMapper)
        {
            _repository = iRepository;
            _mapper = iMapper;
        }

        // GET api/artists/
        [HttpGet]
        public ActionResult<List<ArtistReadDto>> GetAllArtists()
        {
            List<Artist> artists = (List<Artist>)_repository.GetAllArtists();
            List<ArtistReadDto> artistReadDtos = _mapper.Map<List<ArtistReadDto>>(artists);
            return Ok(artistReadDtos);
        }

        // GET api/artists/solo
        [HttpGet("solo")]
        public ActionResult<List<SoloArtistReadDto>> GetAllSoloArtists()
        {
            List<SoloArtist> soloArtists = (List<SoloArtist>)_repository.GetAllSoloArtists();
            List<SoloArtistReadDto> soloArtistReadDtos = _mapper.Map<List<SoloArtistReadDto>>(soloArtists);
            return Ok(soloArtistReadDtos);
        }

        // GET api/artists/{id}
        [HttpGet("{id}", Name = "GetArtistById")]
        public ActionResult<ArtistReadDto> GetArtistById(int id)
        {
            Artist artist= _repository.GetArtistById(id);
            
            if (artist == null)
            {
                return NotFound();
            }

            ArtistReadDto artistReadDto = _mapper.Map<ArtistReadDto>(artist);

            return Ok(artistReadDto);
        }

        // GET api/artists/{artist}

        // POST api/artists/
        [HttpPost]
        public ActionResult CreateArtist(ArtistWriteDto artistWriteDto)
        {
            Artist artistToCreate = _mapper.Map<Artist>(artistWriteDto);

            if (artistToCreate == null)
            {
                throw new ArgumentNullException();
            }

            _repository.CreateArtist(artistToCreate);
            _repository.SaveChanges();

            // return Ok();
            return CreatedAtRoute(nameof(GetArtistById), new { Id = artistToCreate.ArtistId }, artistToCreate);
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

            _repository.CreateSoloArtist(soloArtistToCreate);
            _repository.SaveChanges();

            // return Ok();
            return CreatedAtRoute(nameof(GetArtistById), new { Id = soloArtistToCreate.ArtistId }, soloArtistToCreate);
        }

        // PATCH api/artists/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateArtist(int id, JsonPatchDocument<ArtistUpdateDto> patchDoc)
        {
            // Get artist to update
            Artist artistToUpdate = _repository.GetArtistById(id);

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

            _repository.UpdateArtist(artistToUpdate);
            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/artists/solo/{id}
        [HttpPatch("solo/{id}")]
        public ActionResult UpdateSoloArtist(int id, JsonPatchDocument<SoloArtistUpdateDto> patchDoc)
        {
            // Get artist to update
            Artist soloArtistToUpdate = _repository.GetArtistById(id);

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

            _repository.UpdateArtist(soloArtistToUpdate);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/artists/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteArtist(int id)
        {
            Artist artistToDelete = _repository.GetArtistById(id);

            if (artistToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteArtist(artistToDelete);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
