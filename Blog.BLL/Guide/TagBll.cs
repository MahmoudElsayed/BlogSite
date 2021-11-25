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
using Microsoft.EntityFrameworkCore;

namespace Blog.BLL
{
   public class TagBll
    {
        #region Fields
        private readonly IRepository<TagGuide> _repoTag;
        public const string _spTags = "[Guide].[spTags]";
        public TagBll(IRepository<TagGuide> repoTag)
        {
            _repoTag = repoTag;
        }
        #endregion
        public TagDTO Get(Guid id)
        {
            var tbl = _repoTag.GetAllAsNoTracking().Where(p=>p.ID==id).FirstOrDefault();
            if (tbl == null)
            {
                return new TagDTO();
            }
            var config = new MapperConfiguration(p => p.CreateMap<TagGuide, TagDTO>());
            var mapper = new Mapper(config);
            var TagDTO = mapper.Map<TagDTO>(tbl);
            return TagDTO;
        }

        #region Save
        public ResultViewModel Save(TagDTO mdl)
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
         

            var config = new MapperConfiguration(p => p.CreateMap<TagDTO, TagGuide>());
            var mapper = new Mapper(config);
            var Tag = mapper.Map<TagGuide>(mdl);

            var tbl = _repoTag.GetAllAsNoTracking().Where(p=>p.ID==mdl.ID).FirstOrDefault();
            if (tbl != null)
            {
                Tag.ID = tbl.ID;
                if (_repoTag.GetAll().Where(p => p.ID!= Tag.ID&&p.TagName.Trim() == mdl.TagName.Trim()).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.TagExists;

                    return resultViewModel;
                }
                Tag.ModifiedDate= AppDateTime.Now;
                if (_repoTag.Update(Tag))
                {
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            else
            {
                if (_repoTag.GetAll().Where(p=>p.TagName.Trim()==mdl.TagName.Trim()).FirstOrDefault()!=null)
                {
                    resultViewModel.Message = AppConstants.Messages.TagExists; 

                    return resultViewModel;
                }
                if (_repoTag.Insert(Tag))
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
            resultViewModel.Status = false;
            resultViewModel.Message = AppConstants.Messages.DeletedFailed;

            var tbl = _repoTag.GetAllAsNoTracking().Include(p=>p.BlogGuides).Where(p=>p.ID==id).FirstOrDefault();

            if (tbl != null)
            {


                if (tbl.BlogGuides.Any())
                {
                    resultViewModel.Status = false;
                    resultViewModel.Message = AppConstants.Messages.TagNotDeleted;


                    return resultViewModel;

                }
                tbl.IsDeleted = true;

                tbl.DeletedDate = AppDateTime.Now;

                var IsSuceess = _repoTag.Update(tbl);

                resultViewModel.Status = IsSuceess;
                resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess : AppConstants.Messages.DeletedFailed;
            }

            return resultViewModel;
        }
        #endregion

        #region LoadData

        public IEnumerable<TagDTO> GetSelect() => _repoTag.GetAllAsNoTracking().Where(p => !p.IsDeleted && p.IsActive).Select(p => new TagDTO
        {
            TagName = p.TagName,
            ID = p.ID
        });
        public DataTableResponse LoadData(DataTableRequest mdl)
        {
            var data = _repoTag.ExecuteStoredProcedure<TagDataTableDTO>
                (_spTags, mdl.ToSqlParameter(), CommandType.StoredProcedure);

            return new DataTableResponse() { AaData = data, ITotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
        }
       
        #endregion
    }
}
