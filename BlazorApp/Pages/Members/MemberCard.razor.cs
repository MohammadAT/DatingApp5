using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages.Members
{
    public partial class MemberCard
    {
        [Parameter]
        public Member Member { get; set; }
    }
}
