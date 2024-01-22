using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MvcUIApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "user-role")]
    public class UserTagHelper:TagHelper
    {
        public string? UserName { get; set; }
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UserTagHelper(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            AppUser? user = await _userManager.FindByNameAsync(UserName);
            TagBuilder ul = new TagBuilder("ul");
            ul.Attributes.Add("class", "p-0");
            var roles = _roleManager.Roles.ToList().Select(x => x.Name);
            foreach (var role in roles)
            {
                TagBuilder li = new TagBuilder("li");
                li.AddCssClass("list-group-item text-center");
                TagBuilder span = new TagBuilder("span");
                span.AddCssClass($"badge text-bg-{(await _userManager.IsInRoleAsync(user, role) ? "success" : "danger")} w-50 rounded-pill");
                span.InnerHtml.AppendHtml($"{role}: {await _userManager.IsInRoleAsync(user, role)}");

                li.InnerHtml.AppendHtml(span);
                ul.InnerHtml.AppendHtml(li);
            }
            output.Content.AppendHtml(ul);
        }
    }
}