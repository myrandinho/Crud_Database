

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.test.Repositories;

public class CategoryRepository_Tests
{
    private readonly CategoryRepository _categoryRepository;
    private readonly DataContext _context =
        new(new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .Options);

    public CategoryRepository_Tests()
    {
        _context = new DataContext(new DbContextOptionsBuilder<DataContext>()
           .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);

        _categoryRepository = new CategoryRepository(_context);
    }



    //create
    [Fact]
    public void Create_Should_Add_One_CategoryEntity_To_Database_And_Return_Updated_CategoryEntity()
    {
        //Arrange
       
        var categoryEntity = new CategoryEntity { CategoryName = "testing" };

        //Act
        var result = _categoryRepository.Create(categoryEntity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public void Create_ShouldNot_Add_One_CategoryEntity_To_Database_ThenReturnNull()
    {
        //Arrange
    
        var categoryEntity = new CategoryEntity {};

        //Act
        var result = _categoryRepository.Create(categoryEntity);

        //Assert
        Assert.Null(result);
        
    }

    //Get
    [Fact]
    public void Get_Should_GetOneCategoryEntityFromDatabase_ThenReturnCateGoryEntity()
    {
        //Arrange
        var entity = new CategoryEntity { CategoryName = "testing" };
        var categoryEntity = _categoryRepository.Create(entity);

        //Act
        var result = _categoryRepository.Get(x => x.Id == categoryEntity.Id);
        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Get_ShouldNot_GetOneCategoryEntityFromDatabase_ThenReturnNull()
    {
        //Arrange
        var entity = new CategoryEntity { CategoryName = "testing" };
        var categoryEntity = _categoryRepository.Create(entity);

        //Act
        var result = _categoryRepository.Get(x => x.Id == categoryEntity.Id + 1);
        //Assert
        Assert.Null(result);
        
    }

    [Fact]
    public void GetAll_Should_GetAllCategoryEntitiesFromDatabase_ThenReturnsListOfCategoryEntities()
    {
        //Arrange
        var entity = new CategoryEntity { CategoryName = "testing" };
        var categoryEntity = _categoryRepository.Create(entity);

        //Act
        var result = _categoryRepository.GetAll();
        //Assert
        Assert.NotNull(result);
        
    }

    [Fact]
    public void GetAll_ShouldNot_GetAllCategoryEntitiesFromDatabase_ThenReturnsNull()
    {
        //Arrange
        var entity = new CategoryEntity { CategoryName = "testing" };
       

        //Act
        var result = _categoryRepository.GetAll();
        //Assert
        Assert.Empty(result);

    }


    //Update

    [Fact]
    public void Update_Should_UpdateSelectedCategoryEntity_ThenReturnUpdatedEntity()
    {
        //Arrange
        var entity = new CategoryEntity { CategoryName = "testing" };
        var categoryEntity = _categoryRepository.Create(entity);
        categoryEntity.CategoryName = "testingNew";


        //Act
        var result = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal("testingNew", result.CategoryName);
    }

    [Fact]
    public void Update_ShouldNot_UpdateSelectedCategoryEntity_ThenReturnNull()
    {
        //Arrange
        var entity = new CategoryEntity {};
        var categoryEntity = _categoryRepository.Create(entity);
        


        //Act
        var result = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);

        //Assert
        Assert.Null(result);
        
    }

    [Fact]
    public void Delete_Should_DeleteSelectedCategoryEntity_ThenReturnTrue()
    {
        //Arrange
        var entity = new CategoryEntity { CategoryName = "testing" };
        var categoryEntity = _categoryRepository.Create(entity);



        //Act
        var result = _categoryRepository.Delete(x => x.Id == categoryEntity.Id);

        //Assert
        Assert.True(result);

    }


    [Fact]
    public void Delete_ShouldNot_DeleteSelectedCategoryEntity_ThenReturnFalse()
    {
        //Arrange
        var entity = new CategoryEntity { CategoryName = "testing" };
        var categoryEntity = _categoryRepository.Create(entity);

        //Act
        var result = _categoryRepository.Delete(x => x.Id == categoryEntity.Id + 1);

        //Assert
        Assert.False(result);

    }

}


