using Blog.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DAL
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        #region Overrides

       

        #endregion
        #region Entities

      

        #region Guide
        public DbSet<BlogGuide> BlogGuides { get; set; }
        public DbSet<TagGuide> Tags { get; set; }

        #endregion



        #endregion


    }

}
