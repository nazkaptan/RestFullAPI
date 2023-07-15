using RestFullAPI.Models.Entities.Concrete;
using System.Collections.Generic;

namespace RestFullAPI.Infrastructure.Repositories.Interface
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategory();
        Category GetCategory(int id);
        Category GetCategory(string slug);
        bool CategoryExist(int id);
        bool CategoryExists(string categoryName);
        bool CreateCategory(Category categoryObj);
        bool DeleteCategory(int id);
        bool UpdateCategory(Category categoryObj);
        bool Save();
    }
}
