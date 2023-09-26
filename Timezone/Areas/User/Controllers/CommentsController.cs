using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles ="User,Admin")]
    public class CommentsController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ICommentService commentService;
        public CommentsController(UserManager<AppUser> userManager,ICommentService commentService)
        {
            this.userManager = userManager;
            this.commentService = commentService;
        }

        #region Index
        public async Task<IActionResult> Index(int page=1)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            
            List<Comment> comments = commentService.GetCommentsByUser(user.Name,page,10);

            int totalPages = (int)Math.Ceiling((double)commentService.TotalCountsByUser(user.Name) / 10);

            ViewBag.CurrentPage = page;
            ViewBag.PageCount = totalPages;

            return View(comments);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            var comment = commentService.GetById(id);
            commentService.Delete(comment);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
