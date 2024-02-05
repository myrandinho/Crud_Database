

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.test.Repositories;

public class BaseRepository_Tests
{

    private readonly DataContext _context =
       new(new DbContextOptionsBuilder<DataContext>()
           .UseInMemoryDatabase($"{Guid.NewGuid()}")
           .Options);



    //Create
    [Fact]
    public void Create_Should_CreateEntity_And_SaveToDatabase_ReturnEntityWithId1()
    {

        //Arrange
        var baseRepository = new BaseRepository<AdressEntity>(_context);
        var entity = new AdressEntity { StreetName = "Testgatan 12", PostalCode = "12345", City = "Örebro" };

        //Act
        var result = baseRepository.Create(entity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public void Create_Should_Not_CreateEntity_And_SaveToDatabase_ReturnNull()
    {

        //Arrange
        var baseRepository = new BaseRepository<AdressEntity>(_context);
        var entity = new AdressEntity {};

        //Act
        var result = baseRepository.Create(entity);

        //Assert
        Assert.Null(result);
        
    }

    //Get/View/Read
    [Fact]
    public void Get_Should_FindEntityInDataBase_Then_ReturnEntityWithId1AndEqualName()
    {
        //Arrange
        var baseRepository = new BaseRepository<ProductEntity>(_context);
        var entity = new ProductEntity { Title = "Samsung Galaxt S22", Price = 1200, CategoryId = 3};
        var productEntity = baseRepository.Create(entity);

        //Act
        var result = baseRepository.Get(x => x.Id == entity.Id);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Samsung Galaxt S22", result.Title);
    }

    [Fact]
    public void Get_ShouldNot_FindEntityInDataBase_Then_ReturnNull()
    {
        //Arrange
        var baseRepository = new BaseRepository<ProductEntity>(_context);
        var entity = new ProductEntity {};
        var productEntity = baseRepository.Create(entity);

        //Act
        var result = baseRepository.Get(x => x.Id == entity.Id);

        //Assert
        Assert.Null(result);
        
        
    }


    [Fact]
    public void GetAll_Should_GetContentFromDatabase_AndSaveToList_ThenReturnAllContent()
    {
        //Arrange
        var baseRepository = new BaseRepository<LeagueEntity>(_context);
        var entity = new LeagueEntity { LeagueName = "Allsvenskan", Nation = "Sverige" };
        var leagueEntity = baseRepository.Create(entity);


        //Act
        var result = baseRepository.GetAll();

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetAll_Should_NotFindAnyContentInDatabase_ThenReturnNull()
    {
        //Arrange
        var baseRepository = new BaseRepository<LeagueEntity>(_context);
        var entity = new LeagueEntity {};
        var leagueEntity = baseRepository.Create(entity);


        //Act
        var result = baseRepository.GetAll();

        //Assert
        Assert.Empty(result);
    }

    //Update

    [Fact]
    public void Update_Should_UpdateEntityInDatabase_ThenReturnUpdatedEntity_WithEqualName()
    {
        //Arrange
        var baseRepository = new BaseRepository<RoleEntity>(_context);
        var entity = new RoleEntity { RoleName = "CEO"};
        var roleEntity = baseRepository.Create(entity);
        roleEntity.RoleName = "HR";

        //Act
        var result = baseRepository.Update(x => x.Id == entity.Id, entity);

        //Assert
        Assert.NotNull(result);
        Assert.Equal("HR", result.RoleName);
    }

    [Fact]
    public void Update_ShouldNOT_UpdateEntityInDatabase_ThenReturnNull()
    {
        //Arrange
        var baseRepository = new BaseRepository<RoleEntity>(_context);
        var entity = new RoleEntity {};
        var roleEntity = baseRepository.Create(entity);

        //Act
        var result = baseRepository.Update(x => x.Id == entity.Id, entity);

        //Assert
        Assert.Null(result);
        
    }

    //Delete

    [Fact]
    public void Delete_ShouldDeleteEntityFromDatabase_ThenReturnTrue()
    {
        //Arrange
        var baseRepository = new BaseRepository<RoleEntity>(_context);
        var entity = new RoleEntity { RoleName = "Tester"};
        var roleEntity = baseRepository.Create(entity);

        //Act
        var result = baseRepository.Delete(x => x.Id == entity.Id);

        //Assert
        Assert.True(result);

    }

    [Fact]
    public void Delete_ShouldNot_DeleteEntityFromDatabase_ThenReturnFalse()
    {
        //Arrange
        var baseRepository = new BaseRepository<RoleEntity>(_context);
        var entity = new RoleEntity {};
        var roleEntity = baseRepository.Create(entity);

        //Act
        var result = baseRepository.Delete(x => x.Id == entity.Id);

        //Assert
        Assert.False(result);

    }

}
