using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.BLL;
using Blog.DTO;
using Blog.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Web.Area.Guides.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogBll _blogBll;
        private readonly TagBll _tagBll;


        public BlogController(BlogBll  blogBll, TagBll tagBll)
        {
            _blogBll = blogBll;
            _tagBll = tagBll;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.Tags = new SelectList(_tagBll.GetSelect(),"ID","TagName");
            return View(new BlogDTO());
        }
        public IActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return Redirect(Url.GetAction("Index"));
            }
            var data = _blogBll.Get(id.Value);
            if (data==null)
            {
                return Redirect(Url.GetAction("Index"));

            }
            ViewBag.Tags = new SelectList(_tagBll.GetSelect(), "ID", "TagName",data.TagId);

            return View(data);
        }
        public IActionResult Save(BlogDTO mdl) => Ok(_blogBll.Save(mdl));
        public IActionResult Delete(Guid id) => Ok(_blogBll.Delete(id));


        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_blogBll.LoadData(mdl));

    }
}
