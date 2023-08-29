using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;
        public BlogController(IBlogService blogService)
        {
            this.blogService=blogService;
        }

        #region Index
        public IActionResult Index(string search,int page=1)
        {   
            List<Blog> blogs = new List<Blog>();
            if (!string.IsNullOrEmpty(search))
            {
                var blg = from x in blogService.GetAll() select x;
                blogs = blogService.GetAll().Where(x=>x.Title.Contains(search)).ToList();
                return View(blogs);
            }

            decimal take = 3;
            ViewBag.PageCount = Math.Ceiling(blogService.GetAll().Where(x=>!x.IsDeactive).Count() / take);
            ViewBag.CurrentPage = page;

            blogs = blogService.GetAll().Where(x=>!x.IsDeactive).OrderByDescending(x=>x.Id).
                Skip((page-1)*(int)take).Take((int)take).ToList();

            return View(blogs);
        }
        #endregion

        #region BlogDetail
        public IActionResult BlogDetail(int id)
        {
            Blog blog = blogService.GetById(id);
            if (blog == null) return BadRequest();

            return View(blog);
        }
        #endregion
    }
}
