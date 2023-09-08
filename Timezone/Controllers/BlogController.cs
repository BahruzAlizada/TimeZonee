using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Timezone.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;
        private readonly ICommentService commentService;
        private readonly UserManager<AppUser> userManager;
        public BlogController(IBlogService blogService,UserManager<AppUser> userManager, ICommentService commentService)
        {
            this.blogService = blogService;
            this.userManager = userManager;
            this.commentService = commentService;

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
        public IActionResult Detail(int id)
        {
            Blog blog = blogService.GetById(id);
            if (blog == null) return BadRequest();

            return View(blog);
        }
        #endregion

        #region AddComment
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AddComment(string useremail,int blogId,string comment)
        {
            var user = await userManager.FindByEmailAsync(useremail);
            if(comment is null)
            {
                ModelState.AddModelError("comment", "Bu xana boş ola bilməz");
                return View();
            }

            Comment commentt = new Comment
            {
                FullName = user.Name + user.Surname,
                AppUserId = user.Id,
                BlogId = blogId,
                CommentMessage = comment,
                Email = useremail
            };

            commentService.Add(commentt);
            return Ok();
        }
        #endregion
    }
}
