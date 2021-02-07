using System.Collections.Generic;
using Cofoundry.Domain.CQS;
using Veloso.SPA.Domain;

namespace src.Veloso.SPA.Domain.Data
{
    public class GetAllPhotosQuery : IQuery<ICollection<PhotoSummary>>
    {

    }
}