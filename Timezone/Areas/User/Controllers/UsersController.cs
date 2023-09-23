using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Timezone.Hubs;
using Timezone.ViewsModel;

namespace Timezone.Areas.User.Controllers
{
	[Area("User")]
	[Authorize(Roles = "User")]
	public class UsersController : Controller
	{
		private readonly UserManager<AppUser> userManager;
		private readonly IHubContext<ChatHub> hubContext;
		public UsersController(UserManager<AppUser> userManager, IHubContext<ChatHub> hubContext)
		{
			this.userManager = userManager;
			this.hubContext = hubContext;
		}

		#region Index
		public async Task<IActionResult> Index(string username)
		{
			AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
			IQueryable<AppUser> usersQuery = userManager.Users.Where(x => x.UserName != user.UserName);

			if (!string.IsNullOrEmpty(username))
			{
				usersQuery = usersQuery.Where(x => x.UserName.Contains(username));
			}

			List<UserVM> usersVM = await usersQuery.Select(dbUser => new UserVM
			{
				Name = dbUser.Name,
				Surname = dbUser.Surname,
				UserName = dbUser.UserName,
				Email = dbUser.Email,
			}).Take(8).ToListAsync();

			return View(usersVM);
		}
		#endregion

		#region Detail
		public async Task<IActionResult> Detail(string username)
		{
			AppUser dbuser = await userManager.FindByNameAsync(username);
			UserVM userVM = new UserVM
			{
				Name = dbuser.Name,
				Surname = dbuser.Surname,
				Email = dbuser.Email,
				UserName = dbuser.UserName,
				Image = dbuser.Image,
				PhoneNumber = dbuser.PhoneNumber,
				Bio = dbuser.Bio,
				IsSalesAccount = dbuser.IsSalesAccount,
				IsVerify = dbuser.IsVerify
			};

			return View(userVM);
		}
		#endregion

		#region Message
		public async Task<IActionResult> Message(string username,string content)
		{
			AppUser senderUser = await userManager.FindByNameAsync(User.Identity.Name);
			AppUser receiverUser = await userManager.FindByNameAsync(username);

			MessageVM messageVm = new MessageVM
			{
				SenderId = senderUser.Id.ToString(),
				ReceiverId = receiverUser.Id.ToString(),
				Content=content
			};

			
			
            await hubContext.Clients.User(messageVm.ReceiverId).SendAsync("ReceiveMessage", messageVm.SenderId, messageVm.Content);
            return View();
		}
		#endregion

		

	}
}
