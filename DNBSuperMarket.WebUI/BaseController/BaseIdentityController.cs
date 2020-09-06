﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNBSuperMarket.WebUI.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DNBSuperMarket.WebUI.BaseController
{
    public class BaseIdentityController : Controller
    {
        protected readonly UserManager<AppUser> _userManager;
        public BaseIdentityController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        protected async Task<AppUser> GetLoginUser()
        {
            return await _userManager.FindByNameAsync(User.Identity.Name);
        }

        protected void AddError(IEnumerable<IdentityError> errors)
        {
            foreach (var item in errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
    }
}
