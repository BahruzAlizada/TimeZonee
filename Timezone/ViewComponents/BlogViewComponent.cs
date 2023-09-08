using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly IBlogService blogService;
        public BlogViewComponent(IBlogService blogService)
        {
           this.blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            List<Blog> blogs = blogService.GetAll();
            var bloglimit = blogs.Where(x =>!x.IsDeactive).OrderByDescending(x => x.Id).Take(5).ToList();
            return View(bloglimit);
        }
    }
}
