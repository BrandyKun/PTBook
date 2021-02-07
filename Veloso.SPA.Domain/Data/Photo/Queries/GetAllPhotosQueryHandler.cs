using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cofoundry.Core;
using Cofoundry.Domain;
using Cofoundry.Domain.CQS;
using src.Veloso.SPA.Domain.Data;


namespace Veloso.SPA.Domain
{
    public class GetAllPhotosQueryHandler : IQueryHandler<GetAllPhotosQuery, ICollection<PhotoSummary>>
        , IIgnorePermissionCheckHandler
    {
        private readonly IContentRepository _contentRepository;

        public GetAllPhotosQueryHandler(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task<ICollection<PhotoSummary>> ExecuteAsync(GetAllPhotosQuery query, IExecutionContext executionContext)
        {
            var photoEntities = await _contentRepository
                .CustomEntities()
                .GetByDefinition<PhotoCustomEntityDefinition>()
                .AsRenderSummary()
                .ExecuteAsync();

            var image = await GetImageAsync(photoEntities);

            return MapPhoto(photoEntities, image);

        }

        private ICollection<PhotoSummary>  MapPhoto(ICollection<CustomEntityRenderSummary> customEntities, IDictionary<int, ImageAssetRenderDetails> image)
        {
            var photos = new List<PhotoSummary>(customEntities.Count());

            foreach (var customEntity in customEntities)
            {
                var model = customEntity.Model as PhotoDataModel;

                var photo = new PhotoSummary();

                photo.Id = customEntity.CustomEntityId;
                photo.DataCreated = customEntity.CreateDate;
                photo.Description = model.Description;
                photo.Image = image.GetOrDefault(model.ImageId);

                photos.Add(photo);
            }

            return photos;
        }

        private  Task<IDictionary<int, ImageAssetRenderDetails>> GetImageAsync(ICollection<CustomEntityRenderSummary> customEntity)
        {
            var imageId = customEntity
                .Select(i => (PhotoDataModel)i.Model)
                .Where(m => m.ImageId >= 0)
                .Select(m => m.ImageId)
                .Distinct();

           

            return _contentRepository
                .ImageAssets()
                .GetByIdRange(imageId)
                .AsRenderDetails()
                .ExecuteAsync();
        }

    }
}
