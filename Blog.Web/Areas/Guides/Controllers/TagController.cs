using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.BLL;
using Blog.DTO;
using Blog.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Area.Guides.Controllers
{
    public class TagController : Controller
    {
        private readonly TagBll _tagBll;

        public TagController(TagBll  tagBll)
        {
            _tagBll = tagBll;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View(new TagDTO());
        }
        public IActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return Redirect(Url.GetAction("Index"));
            }

            return View(_tagBll.Get(id.Value));
        }
        public IActionResult Save(TagDTO mdl) => Ok(_tagBll.Save(mdl));
        public IActionResult Delete(Guid id) => Ok(_tagBll.Delete(id));


        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_tagBll.LoadData(mdl));

    }
}
