using ArtistsApplicationDemo.Dtos;
using ArtistsApplicationDemo.Models;
using ArtistsApplicationDemo.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArtistsApplicationDemo.Controllers.Api
{
    public class AlbumsController : ApiController
    {
        private readonly AlbumRepository _albumRepository;
        public AlbumsController()
        {
            _albumRepository = new AlbumRepository();
        }

        public IHttpActionResult GetAlbums()
        {
            return Ok(_albumRepository.GetAll().Select(Mapper.Map<Album,AlbumDto>)) ;
        }

        public IHttpActionResult GetAlbum(int id)
        {
            var album = _albumRepository.GetById(id);

            if (album == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Album,AlbumDto>(album));
        }


        [HttpPost]
        public IHttpActionResult CreateAlbum(AlbumDto albumDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var album = Mapper.Map<AlbumDto, Album>(albumDto);

            _albumRepository.Create(album);
            albumDto.ID = album.ID;  //for the hidden input
            return Created(new Uri(Request.RequestUri + "/" + album.ID),albumDto);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlbumDto albumDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var albumInDb = _albumRepository.GetById(id);

            if (albumInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(albumDto, albumInDb);
            _albumRepository.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpDelete]
        public IHttpActionResult DeleteAlbum(int id)
        {
            var albumInDb = _albumRepository.GetById(id);
            if (albumInDb == null)
                return NotFound();

            _albumRepository.Delete(id);

            return Ok(albumInDb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _albumRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
