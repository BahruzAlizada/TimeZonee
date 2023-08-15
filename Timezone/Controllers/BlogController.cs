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
        public IActionResult Index()
        {
            List<Blog> blogs = blogService.GetAll();
            var bloglimit = blogs.Where(x => !x.IsDeactive).OrderByDescending(x => x.Id).ToList();
            return View(bloglimit);
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
