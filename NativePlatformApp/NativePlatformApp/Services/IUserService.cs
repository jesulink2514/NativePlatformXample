using System.Net.Http;
using System.Threading.Tasks;
using NativePlatformApp.Models;
using Refit;

namespace NativePlatformApp.Services
{
    public interface IUserService
    {
        [Get("/api/users?page={page}")]
        Task<Response> GetUsers(int page=1);

        [Put("/api/users/{id}")]
        Task<UserUpdatedResponse> UpdateUser(int id,[Body]UpdateUserRequest user);

        [Delete("/api/users/{id}")]
        Task<HttpResponseMessage> DeleteUser([AliasAs("id")]int userId);
    }
}
