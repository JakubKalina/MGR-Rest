using System.Collections.Generic;

namespace mgrapi.Dtos.Category
{
    public class GetAllCategoriesDto
    {
        public ICollection<CategoryForGetAllCategoriesDto> Categories { get; set; }
    }

    public class CategoryForGetAllCategoriesDto 
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}