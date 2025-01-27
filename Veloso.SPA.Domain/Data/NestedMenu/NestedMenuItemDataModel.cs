﻿using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Veloso.SPA.Domain
{
    public class NestedMenuItemDataModel : INestedDataModel
    {
        [MaxLength(30)]
        [Required]
        public string Title { get; set; }

        [Required]
        [Page]
        public int PageId { get; set; }

        [Display(Name = "Level 2 Items")]
        [NestedDataModelCollection]
        public ICollection<NestedMenuChildItemDataModel> ChildItems { get; set; }
    }
}
