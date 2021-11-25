using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.DTO
{
    public class TagDTO
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        public string TagName { get; set; }
       
    }
    public class TagDataTableDTO
    {
        public int TotalCount { get; set; } = 0;
        public Guid ID { get; set; }
       public string TagName { get; set; }
        public string AddedTime { get; set; }

    }
}
