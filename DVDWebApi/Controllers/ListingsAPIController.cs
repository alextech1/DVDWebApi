using DVDWebApi.Data.DataFactories;
using DVDWebApi.Models.Queries;
using System;
using System.Web.Http;

namespace DVDWebApi.UI.Controllers
{
    public class ListingsAPIController : ApiController
    {
        [Route("api/dvds/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search([FromUri]ListingSearchParameters parameters)
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
    }
}