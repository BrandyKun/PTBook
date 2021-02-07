using System.Threading.Tasks;
using Cofoundry.Domain.CQS;
using Cofoundry.Web;
using Microsoft.AspNetCore.Mvc;
using src.Veloso.SPA.Domain.Data;
using Veloso.SPA.Domain.Data.Photo.Queries;

namespace src.Veloso.SPA.API
{
    [Route("api/photos")]
    [AutoValidateAntiforgeryToken]

    public class PhotoController : ControllerBase
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IApiResponseHelper _apiResponseHelper;

        public PhotoController(IQueryExecutor queryExecutor, IApiResponseHelper apiResponseHelper)
        {
            _queryExecutor = queryExecutor;
            _apiResponseHelper = apiResponseHelper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllPhotosQuery();
            var results = await _queryExecutor.ExecuteAsync(query);

            return _apiResponseHelper.SimpleQueryResponse(this, results);
        }

        [HttpGet("{photoId:int}")]
        public async Task<IActionResult> Get(int photoId)
        {
            var query = new GetPhotoDetailsByIdQuery(photoId);
            var results = await _queryExecutor.ExecuteAsync(query);

            return _apiResponseHelper.SimpleQueryResponse(this, results);
        }
    }
}