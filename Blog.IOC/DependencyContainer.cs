using Blog.BLL;
using Blog.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.IOC
{
   public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region DAL

            services.AddScoped(typeof(IUnitOfWork<BlogContext>), typeof(UnitOfWork<BlogContext>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion
            #region BLL
            services.AddScoped<TagBll>();

            services.AddScoped<BlogBll>();
            #endregion

        }
    }
}
