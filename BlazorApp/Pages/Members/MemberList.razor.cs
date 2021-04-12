using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages.Members
{
    //[AllowAnonymous]
    [Authorize]
    public partial class MemberList
    {
        [Inject]
        private IMembersService MembersService { get; set; }

        public List<Member> membersList;
        private bool loading;

        protected override async Task OnInitializedAsync()
        {
            loading = true;
            var members = await MembersService.GetMemebers();

            membersList = members.ToList();
            loading = false;
        }

    }
}
