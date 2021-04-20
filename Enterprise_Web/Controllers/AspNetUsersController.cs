using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Enterprise_Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Enterprise_Web.Controllers
{
    public class AspNetUsersController : Controller
    {
        private WebEnterpriseEntities db = new WebEnterpriseEntities();

        // GET: AspNetUsers
        public ActionResult Index()
        {
            var aspNetUsers = db.AspNetUsers.Include(a => a.Faculty);
            return View(aspNetUsers.ToList());
        }

        public ActionResult UsersWithRoles()
        {
            AppUsersDbContext context = new AppUsersDbContext();
            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new UserRoleViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });
            ViewBag.Roles = getallRoles();
            return View(usersWithRoles);
        }

        public SelectList getallRoles(string selectedRoleId = "1")
        {
            return new SelectList(db.AspNetRoles.ToList(), "Id", "Name", selectedRoleId);
        }

        public ActionResult UpdateRole(string UserId, string RoleId)
        {
            var userManager = new UserManager<IdentityUser, string>(new UserStore<IdentityUser>(new AppUsersDbContext()));
            var roleManager = new RoleManager<IdentityRole, string>(new RoleStore<IdentityRole>(new AppUsersDbContext()));
            var olduser = userManager.FindById(UserId);
            var oldrole = roleManager.FindById(olduser.Roles.FirstOrDefault().RoleId);
            var role = roleManager.FindById(RoleId);
            userManager.RemoveFromRole(UserId, oldrole.Name);
            var result = userManager.AddToRole(UserId, role.Name);
            return Json(result.Succeeded, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
