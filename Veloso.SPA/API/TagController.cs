using System.Threading.Tasks;
using Cofoundry.Domain.CQS;
using Cofoundry.Web;
using Microsoft.AspNetCore.Mvc;
using src.Veloso.SPA.Domain.Data;
using Veloso.SPA.Domain.Data.Tags.Queries;

namespace Veloso.SPA.API
{
    [Route("api/tags")]
    [AutoValidateAntiforgeryToken]
    public class TagController : ControllerBase
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IApiResponseHelper _apiResponseHelper;

        public TagController(IQueryExecutor queryExecutor, IApiResponseHelper apiResponseHelper)
        {
            _queryExecutor = queryExecutor;
            _apiResponseHelper = apiResponseHelper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllTagsQuery();
            var results = await _queryExecutor.ExecuteAsync(query);

            return _apiResponseHelper.SimpleQueryResponse(this, results);
        }

        [HttpGet("{photoId:int}")]
        public async Task<IActionResult> Get(int TagId)
        {
            var query = new GetAllTagsByIdRangeQuery(TagId);
            var results = await _queryExecutor.ExecuteAsync(query);

            return _apiResponseHelper.SimpleQueryResponse(this, results);
        }
    }
}
