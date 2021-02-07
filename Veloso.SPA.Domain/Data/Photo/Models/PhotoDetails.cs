using Cofoundry.Domain;
using System;
using System.Collections.Generic;



namespace Veloso.SPA.Domain
{
    public class PhotoDetails: ICustomEntityPageDisplayModel<PhotoDataModel>
    {
        
        public string PageTitle { get; set; }

        public string MetaDescription { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public ImageAssetRenderDetails Image { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}