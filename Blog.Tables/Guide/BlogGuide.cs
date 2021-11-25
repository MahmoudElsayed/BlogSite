using Blog.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Tables
{
    [Table(nameof(BlogGuide) + "s", Schema = AppConstants.Areas.Guide)]

    public class BlogGuide:BaseEntity
    {
       
        [StringLength(500)]
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(TagGuide))]
        public Guid TagId { get; set; }
        public TagGuide Tag { get; set; }


    }
    
}
