using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using mgrapi.Dtos.Category;
using mgrapi.Interfaces;
using mgrapi.Models;

namespace mgrapi.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly RepositoryContext _context;
        public CategoriesService(IMapper mapper, RepositoryContext context)
        {
            _mapper = mapper;
            _context = context;
            // SeedCategories();
        }

            private void SeedCategories() {  

                // var category = new Category() 
                // {
                //     CategoryId = 0,
                //     Name = "Kategoria 1"
                // };

                // _context.Categories.Add(category);
                // _context.SaveChanges();


                List<Category> categories = new List<Category>();

                for(int i = 0; i < 100; i++) {
                    var newCategory = new Category() {
                        // CategoryId = i,
                        Name = "Kategoria " + (i + 1).ToString()
                    };
                    categories.Add(newCategory);
                }

                _context.Categories.AddRange(categories);
                _context.SaveChanges();
            }

        private readonly IMapper _mapper;


        public GetCategoryByIdDto Get(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

            var dto = _mapper.Map<GetCategoryByIdDto>(category);

            return dto;        
        }

        public GetAllCategoriesDto GetAll()
        {
            var allCategories = _context.Categories.ToList();

            var dto = new GetAllCategoriesDto
            {
                Categories = _mapper.Map<List<CategoryForGetAllCategoriesDto>>(allCategories)
            };

            return dto;    
            // throw new NotImplementedException();    
        }

        public bool Update(int id, UpdateCategoryDto category)
        {
            var categoryToUpdate = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

            if (categoryToUpdate == null)
                return false;

            categoryToUpdate.Name = category.Name;

            _context.Categories.Update(categoryToUpdate);
            _context.SaveChanges();
            return true;
        }

        public int Create(CreateCategoryDto category)
        {
            var id = _context.Categories.ToList().Count > 0
              ? _context.Categories.Max(p => p.CategoryId) + 1
              : 0;

            var categoryToAdd = _mapper.Map<Category>(category);

            _context.Categories.Add(categoryToAdd);
            _context.SaveChanges();

            return id;
        }

        public bool Delete(int id)
        {
            var categoryToDelete = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

            if (categoryToDelete == null)
                return false;

            var deletedCategory  = _context.Categories.Remove(categoryToDelete);

            bool isDeleted = false;
            if(deletedCategory != null)
            {
                isDeleted = true;
            }
        
            _context.SaveChanges();

            return isDeleted;
        }

    }
}