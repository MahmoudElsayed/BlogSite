using Blog.Common;
using Blog.DAL;
using Blog.DTO;
using Blog.Tables;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Blog.BLL
{
   public class BlogBll
    {
        #region Fields
        private readonly IRepository<BlogGuide> _repoBlog;
        public const string _spBlogs = "[Guide].[spBlogs]";
        public BlogBll(IRepository<BlogGuide> repoBlog)
        {
            _repoBlog = repoBlog;
        }
        #endregion
        public BlogDTO Get(Guid id)
        {
            var tbl = _repoBlog.GetAllAsNoTracking().Where(p=>p.ID==id).FirstOrDefault();
            if (tbl == null)
            {
                return new BlogDTO();
            }
            var config = new MapperConfiguration(p => p.CreateMap<BlogGuide, BlogDTO>());
            var mapper = new Mapper(config);
            var BlogDTO = mapper.Map<BlogDTO>(tbl);
            return BlogDTO;
        }

        #region Save
        public ResultViewModel Save(BlogDTO mdl)
        {
            ResultViewModel resultViewModel = new ResultViewModel();
            resultViewModel.Status = false;
            resultViewModel.Message = AppConstants.Messages.SavedFailed;
            var PropertyRequierd = mdl.GetMessage();

            if (!string.IsNullOrWhiteSpace(PropertyRequierd))
            {
                resultViewModel.Message = PropertyRequierd;

                return resultViewModel;
            }
         

            var config = new MapperConfiguration(p => p.CreateMap<BlogDTO, BlogGuide>());
            var mapper = new Mapper(config);
            var Blog = mapper.Map<BlogGuide>(mdl);

            var tbl = _repoBlog.GetAllAsNoTracking().Where(p=>p.ID==mdl.ID).FirstOrDefault();
            if (tbl != null)
            {
                Blog.ID = tbl.ID;
                if (_repoBlog.GetAll().Where(p => p.ID!= Blog.ID&&p.Title.Trim() == mdl.Title.Trim()).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.BlogExists;

                    return resultViewModel;
                }
                Blog.ModifiedDate= AppDateTime.Now;
                if (_repoBlog.Update(Blog))
                {
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            else
            {
                if (_repoBlog.GetAll().Where(p=>p.Title.Trim()==mdl.Title.Trim()).FirstOrDefault()!=null)
                {
                    resultViewModel.Message = AppConstants.Messages.BlogExists; 

                    return resultViewModel;
                }
                if (_repoBlog.Insert(Blog))
                {
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            return resultViewModel;

        }
        public ResultViewModel Delete(Guid id)
        {
            ResultViewModel resultViewModel = new ResultViewModel();
            var tbl = _repoBlog.GetById(id);
            tbl.IsDeleted = true;
            tbl.DeletedDate = AppDateTime.Now;
            var IsSuceess = _repoBlog.Update(tbl);

            resultViewModel.Status = IsSuceess;
            resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess: AppConstants.Messages.DeletedFailed;


            return resultViewModel;
        }
        #endregion

        #region LoadData
        public DataTableResponse LoadData(DataTableRequest mdl)
        {
            var data = _repoBlog.ExecuteStoredProcedure<BlogDataTableDTO>
                (_spBlogs, mdl.ToSqlParameter(), CommandType.StoredProcedure);

            return new DataTableResponse() { AaData = data, ITotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
        }
       
        #endregion
    }
}
