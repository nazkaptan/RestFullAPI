using RestFullAPI.Models.Entities.Abstract;

namespace RestFullAPI.Models.Entities.Concrete
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
    }
}
