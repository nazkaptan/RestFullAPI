using RestFullAPI.Models.Entities.Concrete;

namespace RestFullAPI.Infrastructure.Repositories.Interface
{
    public interface IAuthRepository
    {
        AppUser Authentication(string userName, string password);
    }
}
