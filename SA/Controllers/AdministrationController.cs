using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SA.Models;

namespace SA.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AplicationUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
            UserManager<AplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    //dbo.AspNetRoles (USER I ADMIN PERMISIJE)
                    Name = model.RoleName
                };
                //role is represented by build in identity role class 
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("listRoles", "Administration");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }


            return View(model);
        }
        [HttpGet]
        public IActionResult listRoles()
        {
            //vraca listu rola
            var roles = roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            UserRoleVModel vmd = new UserRoleVModel(); //moje
            string Name2 = vmd.UserName;

            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            var model = new EditClassforUsers
            {
                Id = role.Id,
                RoleName = role.Name //dbo.aspnetroles
                
            };
            
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name)) //dbo.aspnetroles
                {
                    model.Users.Add(user.UserName); //aplication user.cs
                    
                }
            }
            TempData["st"] = Name2; //moje
            return View(model);
            
            
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditClassforUsers model)
        {
            var role = await roleManager.FindByIdAsync(model.Id); 

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {roleId} cannot be found";
                return View("NotFound");

            }
            var model = new List<UserRoleVModel>();
            
            foreach(var user in userManager.Users) //lista usera 
            {
                var userRoleVModel = new UserRoleVModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if(await userManager.IsInRoleAsync(user, role.Name))//vraca true ako je user member ove role
                {
                    userRoleVModel.IsSelected = true;
                }
                else
                {
                    userRoleVModel.IsSelected = false;
                }
                model.Add(userRoleVModel);
                
            }
            
            return View(model);
            
        }
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleVModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }
            for(int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId); //vraca usera 

                IdentityResult result = null;
                //da li je selektovan i da li je clan role
                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                //ako nije selektovan i vec je clan role remove from role
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                    
                    //ako je user selektovan i u roli ne radi nista
                    //ako nije selektovan i nije u roli ne radi nista
                }
                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }
            //ako je model prazan salji usera nazad u editrole
            return RedirectToAction("EditRole", new { Id = roleId });
        }
    }
}