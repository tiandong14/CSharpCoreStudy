using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole IdentityRole = new IdentityRole(roleName: model.RoleName);
                //将角色保存到表里面去
                IdentityResult Result = await _roleManager.CreateAsync(IdentityRole);
                if (Result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                foreach (IdentityError error in Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteRole(int id)
        {
            //todo
            return View();
        }
        public async Task<IActionResult>  EditRole(string id) {
            var Role=await _roleManager.FindByIdAsync(id);
            if (Role == null) {
                ViewBag.ErrorMessage =$"角色id={id}的信息不存在，请重试。";
                return View("NotFound");
            }
            EditRoleViewModel
            return View();
        }

    }
}
