using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cofoundry.Domain;
using Cofoundry.Domain.CQS;

namespace Veloso.SPA.Domain.Data.Tags.Queries
{
    public class GetAllTagsByIdRangeQueryHandler : IQueryHandler<GetAllTagsByIdRangeQuery,Tag>
        , IIgnorePermissionCheckHandler
    {
        private readonly IContentRepository _contentRepository;

        public GetAllTagsByIdRangeQueryHandler(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task<Tag> ExecuteAsync(GetAllTagsByIdRangeQuery query, IExecutionContext executionContext)
        {
            var tags = await _contentRepository
                .CustomEntities()
                .GetById(query.TagsIds)
                .AsRenderSummary()
                .Map(MapTag)
                .ExecuteAsync();

            return tags;
        }

        private Tag MapTag(CustomEntityRenderSummary customEntity)
        {
            var tag = new Tag();

            tag.Id= customEntity.CustomEntityId;
            tag.Name = customEntity.Title;

            return tag;
        }
    }
}
