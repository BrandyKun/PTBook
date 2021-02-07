using System.ComponentModel.DataAnnotations;
using Cofoundry.Domain;
using System.Collections.Generic;


namespace Veloso.SPA.Domain
{
    public class TagDataModel: ICustomEntityDataModel 
    {
        [Display(Description = "A short description or tag-line to describe the tag")]
        public string Description { get; set; }

        [Display(Name = "Photos", Description = "Extra features or properties that help categorize this cat")]
        [CustomEntityCollection(PhotoCustomEntityDefinition.DefinitionCode)]
        public ICollection<int>? PhotoIds { get; set; }
    }
}