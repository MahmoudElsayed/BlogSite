using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.DTO
{
    public class BlogDTO
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        [StringLength(500)]
        [Required]
        public string Title { get; set; }
        [Required]

        public string Description { get; set; }
        public Guid TagId { get; set; }

    }
    public class BlogDataTableDTO
    {
        public int TotalCount { get; set; } = 0;
        public Guid ID { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string TagName { get; set; }
        public string AddedTime { get; set; }

    }
}
