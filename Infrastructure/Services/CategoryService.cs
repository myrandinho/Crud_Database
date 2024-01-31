

using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class CategoryService
{
    private readonly CategoryRepository _categoryRepository;

    public CategoryService(CategoryRepository categorysRepository)
    {
        _categoryRepository = categorysRepository;
    }

    public CategoryEntity CreateCategory(string categoryName)
    {
        try
        {
            var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
            categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = categoryName });

            if (categoryEntity != null)
            {
                
                return categoryEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public CategoryEntity GetCategoryByCategoryName(string categoryName)
    {
        try
        {
            var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
            if (categoryEntity != null)
            {
                return categoryEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }


    public CategoryEntity GetCategoryById(int id)
    {
        try
        {
            var categoryEntity = _categoryRepository.Get(x => x.Id == id);
            if (categoryEntity != null)
            {
                return categoryEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public IEnumerable<CategoryEntity> GetCategories()
    {
        try
        {
            var categories = _categoryRepository.GetAll();
            if (categories != null)
            {
                return categories;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        try
        {
            var updatedCategoryEntity = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
            if (updatedCategoryEntity != null)
            {
                return updatedCategoryEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public bool DeleteCategory(int id)
    {
        try
        {
            if( id != 0)
            {
                _categoryRepository.Delete(x => x.Id == id);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}
