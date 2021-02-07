using System;
using Cofoundry.Domain.CQS;

namespace Veloso.SPA.Domain.Data.Photo.Queries
{
    public class GetPhotoDetailsByIdQuery : IQuery<PhotoDetails>
    {
        public GetPhotoDetailsByIdQuery()
        {
        }

        public GetPhotoDetailsByIdQuery(int id)
        {
            PhotoId = id;
        }

        public int PhotoId { get; set; }
    }
}
