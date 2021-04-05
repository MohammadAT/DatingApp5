using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface IMembersService
    {
        Task<IEnumerable<Member>> GetMemebers();
        Task<Member> GetMember(string Username);
        Task UpdateMember(Member member);
    }

    public class MembersService : IMembersService
    {
        List<Member> Members { get; }

        private readonly IHttpService _httpService;

        public MembersService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Member> GetMember(string Username)
        {
            return await _httpService.Get<Member>("users/" + Username);
        }

        public async Task<IEnumerable<Member>> GetMemebers()
        {
            var members = await _httpService.Get<IEnumerable<Member>>("users");
            return members;
        }

        public Task UpdateMember(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
