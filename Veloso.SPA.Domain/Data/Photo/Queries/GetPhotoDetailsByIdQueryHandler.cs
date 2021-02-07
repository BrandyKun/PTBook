using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cofoundry.Core;
using Cofoundry.Domain;
using Cofoundry.Domain.CQS;
using src.Veloso.SPA.Domain.Data;
using Veloso.SPA.Domain.Data.Tags.Queries;

namespace Veloso.SPA.Domain.Data.Photo.Queries
{
    public class GetPhotoDetailsByIdQueryHandler : IQueryHandler<GetPhotoDetailsByIdQuery, PhotoDetails>
        , IIgnorePermissionCheckHandler
    {
        private readonly IContentRepository _contentRepository;

        public GetPhotoDetailsByIdQueryHandler(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task<PhotoDetails> ExecuteAsync(GetPhotoDetailsByIdQuery query, IExecutionContext executionContext)
        {
            var photo = await _contentRepository
                .CustomEntities()
                .GetById(query.PhotoId)
                .AsRenderSummary()
                .Map(MapPhotoAsync)
                .ExecuteAsync();

            return photo;
        }

        public async Task<PhotoDetails> MapPhotoAsync(CustomEntityRenderSummary customEntity)
        {
            var model = customEntity.Model as PhotoDataModel;
            var photo = new PhotoDetails();

            photo.Id = customEntity.CustomEntityId;
            photo.DateAdded = model.DataCreated;
            photo.Description = model.Description;
            photo.Tags = await GetTagsAsync(model.TagIds);
            photo.Image = await GetImageAsync(model.ImageId);

            return photo;
        }

        private async Task<ICollection<Tag>> GetTagsAsync(ICollection<int> tagsIds)
        {
            if (EnumerableHelper.IsNullOrEmpty(tagsIds)) return Array.Empty<Tag>();
            var query = new GetAllTagsQuery();

            var tags = await _contentRepository.ExecuteQueryAsync(query);

            return tags;
                
        }

        private Task<ImageAssetRenderDetails> GetImageAsync(int imageId)
        {
            //var imageId = customEntity
            //    .Select(i => (PhotoDataModel)i.Model)
            //    .Where(m => m.ImageId >= 0)
            //    .Select(m => m.ImageId)
            //    .Distinct();

            return _contentRepository
                .ImageAssets()
                .GetById(imageId)
                .AsRenderDetails()
                .ExecuteAsync();
        }
    }
}
