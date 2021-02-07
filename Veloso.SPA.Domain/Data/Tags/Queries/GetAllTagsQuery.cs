using System.Collections.Generic;
using Cofoundry.Domain.CQS;

namespace Veloso.SPA.Domain.Data.Tags.Queries
{
    public class GetAllTagsQuery : IQuery<ICollection<Tag>>
    {
        public int Id { get; set; }

    }
}