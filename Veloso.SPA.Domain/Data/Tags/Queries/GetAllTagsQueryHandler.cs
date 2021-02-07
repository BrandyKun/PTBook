using System.Collections.Generic;
using System.Threading.Tasks;
using Cofoundry.Domain;
using Cofoundry.Domain.CQS;


namespace Veloso.SPA.Domain.Data.Tags.Queries
{
    public class GetAllTagsQueryHandler : IQueryHandler<GetAllTagsQuery, ICollection<Tag>>
        , IIgnorePermissionCheckHandler
    {
        private readonly IContentRepository _contentRepository;

        public GetAllTagsQueryHandler(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task<ICollection<Tag>> ExecuteAsync(GetAllTagsQuery query, IExecutionContext executionContext)
        {
            var tags = await _contentRepository
                .CustomEntities()
                .GetByDefinition<TagCustomEntityDefinition>()
                .AsRenderSummary()
                .MapItem(MapTag)
                .ExecuteAsync();

            return tags;
        }

        private Tag MapTag(CustomEntityRenderSummary customEntity )
        {
            var tag= new Tag();

            tag.Id = customEntity.CustomEntityId;
            tag.Name = customEntity.Title;

            return tag;
        }
    }
}