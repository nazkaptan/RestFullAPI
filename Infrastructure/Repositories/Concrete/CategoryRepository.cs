using RestFullAPI.Infrastructure.Context;
using RestFullAPI.Infrastructure.Repositories.Interface;
using RestFullAPI.Models.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace RestFullAPI.Infrastructure.Repositories.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CategoryExist(int id) => _context.Categories.Any(x => x.Id.Equals(id));

        public bool CategoryExists(string categoryName) => _context.Categories.Any(x => x.Name.ToLower().Trim() == categoryName.ToLower().Trim());

        public bool CreateCategory(Category categoryObj)
        {
            _context.Categories.AddAsync(categoryObj);
            return Save();
        }

        public bool DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null) _context.Categories.Remove(category);
            return Save();
        }

        public ICollection<Category> GetCategory() => _context.Categories.OrderBy(x => x.Id).ToList();

        public Category GetCategory(int id) => _context.Categories.FirstOrDefault(x => x.Id == id);

        public Category GetCategory(string slug) => _context.Categories.FirstOrDefault(x => x.Slug.Equals(slug));

        public bool Save() => _context.SaveChanges() >= 0 ? true : false;

        public bool UpdateCategory(Category categoryObj)
        {
            categoryObj.UpdateDate = System.DateTime.Now;
            categoryObj.Status = Models.Entities.Abstract.Status.Modified;
            _context.Categories.Update(categoryObj);
            return Save();
        }
    }
}
