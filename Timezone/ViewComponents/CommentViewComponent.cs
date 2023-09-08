using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Timezone.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly ICommentService commentService;
        public CommentViewComponent(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IViewComponentResult Invoke(int blogId)
        {
           using (var context = new Context())
            {
                var comments = context.Comments.Include(x => x.AppUser).Include(x => x.Blog).Where(x => x.BlogId == blogId).ToList();
                return View(comments);
            }
        }
    }
}
