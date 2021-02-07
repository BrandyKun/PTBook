using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cofoundry.Domain;

namespace Veloso.SPA.Domain
{
    public class PhotoDataModel : ICustomEntityDataModel
    {
        public PhotoDataModel()
        {
            DataCreated = DateTime.UtcNow;
        }

        public int Id { get; set; }

        [MaxLength(500)]
        [Display(Description = "A short description of the photo.")]
        [MultiLineText]
        public string Description { get; set; }
        
        [Display(Name="Image", Description="Image you wan to share")]
        [Image]
        public int ImageId { get; set; }        

        [Display(Name ="Tags", Description="Tags to help for Collection")]
        [CustomEntityCollection(TagCustomEntityDefinition.DefinitionCode)]
        public ICollection<int> TagIds { get; set; }

        [Display(Name ="Date Added")]
        public DateTime DataCreated { get; set; }

    }
}