using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Timezone.ViewsModel;

namespace Timezone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;
        public RoleController(RoleManager<AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        #region Index
        public IActionResult Index()
        {
            List<AppRole> roles = roleManager.Roles.ToList();
            List<RoleListVM> roleList = new List<RoleListVM>();

            foreach (var item in roles)
            {
                RoleListVM listVM = new RoleListVM
                {
                    ID=item.Id,
                    Role = item.Name
                };
                roleList.Add(listVM);
            }
            return View(roleList);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(RoleListVM roleList)
        {
            #region Exist
            bool isExist = roleManager.Roles.ToList().Any(x => x.Name == roleList.Role);
            if (isExist)
            {
                ModelState.AddModelError("Role", "Bu rol hal-hazırda zatən var");
                return View();
            }
            #endregion

            AppRole role = new AppRole
            {
                Name = roleList.Role,
                NormalizedName = roleList.Role.ToUpper()
            };

            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            AppRole role = roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleListVM dbRoleList = new RoleListVM
            {
                ID = role.Id,
                Role = role.Name
            };

            return View(dbRoleList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int id,RoleListVM roleList)
        {
            #region Get
            AppRole role = roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleListVM dbRoleList = new RoleListVM
            {
                ID = role.Id,
                Role = role.Name
            };
            #endregion

            #region Exist
            bool isExist = roleManager.Roles.ToList().Any(x => x.Name == roleList.Role && x.Id!=id);
            if (isExist)
            {
                ModelState.AddModelError("Role", "Bu rol hal-hazırda zatən var");
                return View();
            }
            #endregion

            dbRoleList.ID = roleList.ID;
            dbRoleList.Role = roleList.Role;

            role.Id = roleList.ID;
            role.Name = roleList.Role;
            role.NormalizedName = roleList.Role.ToUpper();

            await roleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
