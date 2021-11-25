using Blog.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Tables
{
    [Table(nameof(TagGuide) + "s", Schema = AppConstants.Areas.Guide)]

    
    public class TagGuide:BaseEntity
    {
        public string TagName { get; set; }
        public virtual ICollection<BlogGuide> BlogGuides { get; set; }
    }
}
