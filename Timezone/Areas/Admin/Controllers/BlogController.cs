using BusinessLayer.Abstract;
using BusinessLayer.Helper;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Timezone.Models;

namespace Timezone.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BlogController : Controller
	{
		private readonly IBlogService blogService;
		private readonly IWebHostEnvironment env;
		public BlogController(IBlogService blogService,IWebHostEnvironment env)
		{
			this.blogService = blogService;
			this.env = env;
		}

		#region Index
		public IActionResult Index(int page=1)
		{ 
            decimal take = 7;
            ViewBag.PageCount = Math.Ceiling(blogService.GetAll().Where(x => !x.IsDeactive).Count() / take);
            ViewBag.CurrentPage = page;

            List<Blog> blogs = blogService.GetAll().OrderByDescending(x => x.Id).
                Skip((page - 1) * (int)take).Take((int)take).ToList();

            return View(blogs);
		}
		#endregion

		#region Create
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> Create(BlogModel model)
		{
			#region Existed
			bool isExisted = blogService.GetAll().Any(x=>x.Title== model.Title);
			if (isExisted)
			{
				ModelState.AddModelError("Title", "Bu bloq hal-hazırda mövcuddur");
				return View();
			}
			#endregion

			#region Image
			if (model.Photo == null)
			{
				ModelState.AddModelError("Photo", "Şəkil boş ola bilməz");
				return View();
			}
			if (!model.Photo.IsImage())
			{
				ModelState.AddModelError("Photo", "Sadəcə Şəkil tipli fayllar");
				return View();
			}
			if (model.Photo.IsOlder256Kb())
			{
                ModelState.AddModelError("Photo", "Maksimum 256 Kb");
                return View();
            }
			string folder = Path.Combine(env.WebRootPath, "assets", "img", "blog");
			model.Image = await model.Photo.SaveFileAsync(folder);
			#endregion

			Blog blog = new Blog
			{
				Id = model.Id,
				Title = model.Title,
				Description = model.Description,
				Image = model.Image,
				IsDeactive = false
			};

			blogService.Add(blog);
			return RedirectToAction("Index");
		}
		#endregion

		#region Update
		public IActionResult Update(int id)
		{
			Blog dbBlog = blogService.GetById(id);
			if (dbBlog is null) return NotFound();

			BlogModel dbModel = new BlogModel
			{
				Id = dbBlog.Id,
				Title = dbBlog.Title,
				Description = dbBlog.Description,
				Image = dbBlog.Image,
			};

			return View(dbModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> Update(int id,BlogModel model)
		{
            #region Get
            Blog dbBlog = blogService.GetById(id);
            if (dbBlog is null) return NotFound();

            BlogModel dbModel = new BlogModel
            {
                Id = dbBlog.Id,
                Title = dbBlog.Title,
                Description = dbBlog.Description,
                Image = dbBlog.Image,
            };
            #endregion

            #region Existed
            bool isExisted = blogService.GetAll().Any(x => x.Title == model.Title && x.Id != id);
            if (isExisted)
            {
                ModelState.AddModelError("Title", "Bu bloq hal-hazırda mövcuddur");
                return View();
            }
			#endregion

			#region Image
			if (model.Photo != null)
			{
                if (!model.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Sadəcə Şəkil tipli fayllar");
                    return View();
                }
                if (model.Photo.IsOlder256Kb())
                {
                    ModelState.AddModelError("Photo", "Maksimum 256 Kb");
                    return View();
                }
                string folder = Path.Combine(env.WebRootPath, "assets", "img", "blog");
                model.Image = await model.Photo.SaveFileAsync(folder);
				string path = Path.Combine(env.WebRootPath, folder, dbBlog.Image);
				if (System.IO.File.Exists(path))
					System.IO.File.Delete(path);
				dbModel.Image = model.Image;
            }
			if (model.Photo is null)
				model.Image = dbModel.Image;
			#endregion

			dbModel.Id = model.Id;
			dbModel.Title = model.Title;
			dbModel.Description = model.Description;
			

			Blog blog = new Blog
			{
				Id = model.Id,
				Title = model.Title,
				Description = model.Description,
				Image = model.Image,
				IsDeactive = false,
			};

			blogService.Update(blog);
			return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public IActionResult Activity(int id)
		{
			blogService.Activity(id);
			return RedirectToAction("Index");
		}
		#endregion
	}
}
