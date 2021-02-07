using System;
using System.Collections.Generic;
using Cofoundry.Domain.CQS;

namespace Veloso.SPA.Domain.Data.Tags.Queries
{
    public class GetAllTagsByIdRangeQuery : IQuery<Tag>
    {
        public GetAllTagsByIdRangeQuery() 
        {
        }

        public GetAllTagsByIdRangeQuery(int ids)
        {
            TagsIds = ids;
        }

        public int TagsIds { get; set; }
    }
}
