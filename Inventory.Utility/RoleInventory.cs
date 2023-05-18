using Inventory.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Utility
{
    public class RoleInventory : IRoleInventory
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;
        public RoleInventory(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task AddRoleAsync(string AppUserId)
        {
            var user = await _userManager.FindByIdAsync(AppUserId);
            var roles = _roleManager.Roles;
            List<string> stringRoles = new List<string>();
            if (user != null) 
            {
                foreach (var item in roles)
                {
                    stringRoles.Add(item.Name);
                }
                await _userManager.AddToRolesAsync(user, stringRoles);
            }
        }

        public async Task CreateNewRoleAsync()
        {
            Type t = typeof(TopMenus);
            foreach (Type classObj in t.GetNestedTypes())
            {
                foreach (var objFeild in classObj.GetFields())
                {
                    if (objFeild.Name.Contains("RoleName"))
                    {
                        var roleName = (string) objFeild.GetValue(objFeild);
                        if (!await _roleManager.RoleExistsAsync(objFeild.Name))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(objFeild.Name));
                        }
                    }
                }
            }
        }
    }
}
