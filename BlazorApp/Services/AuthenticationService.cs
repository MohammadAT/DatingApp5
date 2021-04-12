using BlazorApp.Models;
using BlazorApp.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public interface IAuthenticationService
    {
        User User { get; }
        Task Initialize();
        Task Login(LoginViewModel model);
        Task Logout();
        Task Register(User user);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        public User User { get; private set; }

        public AuthenticationService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        )
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<User>("user");
        }

        public async Task Login(LoginViewModel model)
        {
            User = await _httpService.Post<User>("account/login", new { model.Username, model.Password });
            await _localStorageService.SetItem("user", User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem("user");
            _navigationManager.NavigateTo("login");
        }

        public Task Register(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}