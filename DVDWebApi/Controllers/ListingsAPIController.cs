using DVDWebApi.Data.DataFactories;
using DVDWebApi.Models;
using DVDWebApi.Models.Queries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;

namespace DVDWebApi.UI.Controllers
{
    public class ListingsAPIController : ApiController
    {
        [Route("api/dvds/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search([FromUri] ListingSearchParameters parameters)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                /*var parameters = new ListingSearchParameters()
                {
                    Title = title,
                    ReleaseYear = releaseYear,
                    Director = director,
                    Rating = rating
                };*/

                var result = repo.Search(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvd(int id)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            Dvd dvd = repo.GetById(id);

            if (dvd != null)
            {
                return Ok(dvd);
            }
            else
                return BadRequest($"Dvd Id: {id} not found.");

        }

        [Route("api/dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllDvds()
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                var dvds = repo.GetAll();

                return Ok(dvds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                var dvds = repo.GetAll().Where(x => x.Title.ToLower() == title).ToList();

                return Ok(dvds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByYear(string releaseYear)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                var dvds = repo.GetAll().Where(x => x.ReleaseYear.ToString() == releaseYear).ToList();

                return Ok(dvds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                var dvds = repo.GetAll().Where(x => x.Rating.ToLower() == rating).ToList();

                return Ok(dvds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddDvd(Dvd dvd)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                repo.Insert(dvd);

                return Ok(dvd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("api/dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult EditDvd(int id)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                Dvd dvd = repo.GetById(id);

                repo.Update(dvd);

                return Ok(dvd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteDvd(int id)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                repo.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}