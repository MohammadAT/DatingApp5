using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages.Members
{
    public partial class MemberDetail
    {

        public Member member { get; set; }

        [Parameter]
        public string Username { get; set; }


        [Inject]
        private IMembersService MembersService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            if (Username == null)
            {
                Console.WriteLine("No User Name Passed");
            }

            await GetMember();
        }

        public async Task GetMember()
        {
            member = new Member();
            member = await MembersService.GetMember(Username);
        }
    }
}
