using mgrapi.Dtos.Category;

namespace mgrapi.Interfaces
{
    public interface ICategoriesService
    {
        GetAllCategoriesDto GetAll();

        GetCategoryByIdDto Get(int id);
        
        int Create(CreateCategoryDto user);

        bool Update(int id, UpdateCategoryDto pizza);

        bool Delete(int id);
    }
}