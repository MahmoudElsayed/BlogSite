
using Blog.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Tables
{
    /// <summary>
    /// This The Base Entity Of Some Tables
    /// Contains ID as Guid
    /// Created Date DateTime
    /// IsActive bool => default true
    /// IsDeleted bool => defult false
    /// </summary>
    public class BaseEntity
    {
        public BaseEntity() => ID = Guid.NewGuid();

        /// <summary>
        /// ID Is The Id Of Table 
        /// uniqueidentifier
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// Creation Date Of The Item
        /// </summary>
        public DateTime CreatedDate { get; set; } = AppDateTime.Now;

    

        /// <summary>
        /// Modified Date Of The Item
        /// </summary>
        public DateTime? ModifiedDate { get; set; }


        public bool IsDeleted { get; set; } = false;

        public bool IsActive { get; set; } = true;

        /// <summary>
        /// The Date of Deleted This Item
        /// </summary>
        public DateTime? DeletedDate { get; set; }

 


    }
}
