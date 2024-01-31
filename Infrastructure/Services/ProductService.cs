

using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly CategoryService _categoryService;

    public ProductService(ProductRepository productRepository, CategoryService categoryService)
    {
        _productRepository = productRepository;
        _categoryService = categoryService;
    }



    public ProductEntity CreateProduct(string title, decimal price, string categoryName)
    {
        try
        {
            var categoryEntity = _categoryService.CreateCategory(categoryName);

            var productEntity = new ProductEntity
            {
                Title = title,
                Price = price,
                CategoryId = categoryEntity.Id,
            };

            productEntity = _productRepository.Create(productEntity);
            if (productEntity != null)
            {
                return productEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public ProductEntity GetProductById(int id)
    {
        try
        {
            var productEntity = _productRepository.Get(x => x.Id == id);
            if (productEntity != null)
            {
                return productEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public IEnumerable<ProductEntity> GetProducts()
    {
        try
        {
            var products = _productRepository.GetAll();
            if (products != null)
            {
                return products;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public ProductEntity UpdateProduct(ProductEntity productEntity)
    {
        try
        {
            var updatedProductEntity = _productRepository.Update(x => x.Id == productEntity.Id, productEntity);
            if (updatedProductEntity != null)
            {
                return updatedProductEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public bool DeleteProduct(int id)
    {
        try
        {
            if (id != 0)
            {
                _productRepository.Delete(x => x.Id == id);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }

}
