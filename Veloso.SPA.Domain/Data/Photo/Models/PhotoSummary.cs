using System;
using System.Collections.Generic;
using Cofoundry.Domain;

namespace Veloso.SPA.Domain
{
    public class PhotoSummary
    {

        public int Id { get; set; }

        public DateTime DataCreated { get; set; }

        public string Description { get; set; }

        public ImageAssetRenderDetails Image { get; set; }

    }
}
