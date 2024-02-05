

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.test.Services
{
    public class AdressService_Tests
    {
        private readonly AdressService _adressService;
        private readonly DataContext _context;



        public AdressService_Tests()
        {
            _context = new DataContext(new DbContextOptionsBuilder<DataContext>()
           .UseInMemoryDatabase($"{Guid.NewGuid()}")
           .Options);

            _adressService = new AdressService(new AdressRepository(_context));
        }

        //Create
        [Fact]
        public void CreateAdress_Should_CreateNewAdress_And_SaveToDatabase_ThenReturnsAdressEntity()
        {
            //Arrange
            
            var adressEntity = new AdressEntity { StreetName = "TestGatan 5", PostalCode = "12345", City = "Örebro" };

            //Act
            var result = _adressService.CreateAdress(adressEntity.StreetName, adressEntity.PostalCode, adressEntity.City);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("12345", result.PostalCode);
        }

        [Fact]
        public void CreateAdress_ShouldNot_CreateNewAdress_ThenReturnNull()
        {
            //Arrange

            var adressEntity = new AdressEntity {};

            //Act
            var result = _adressService.CreateAdress(adressEntity.StreetName, adressEntity.PostalCode, adressEntity.City);

            //Assert
            Assert.Null(result);
            
        }

        //Get
        [Fact]
        public void GetAdress_Should_GetsOneAdress_ThenReturnsAdressEntity()
        {
            //Arrange
         
            var entity = new AdressEntity { StreetName = "Testvägen", PostalCode = "12345", City = "Stockholm" };
            var adressEntity = _adressService.CreateAdress(entity.StreetName, entity.PostalCode, entity.City);

            //Act
            var result = _adressService.GetAdress(adressEntity.StreetName, adressEntity.PostalCode, adressEntity.City);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Testvägen", result.StreetName);

        }

        [Fact]
        public void GetAdress_ShouldNot_GetOneAdress_ThenReturnsNull()
        {
            //Arrange

            var entity = new AdressEntity { StreetName = "Testvägen", PostalCode = "12345", City = "Stockholm" };
            

            //Act
            var result = _adressService.GetAdress(entity.StreetName, entity.PostalCode, entity.City);

            //Assert
            Assert.Null(result);
            

        }

        [Fact]
        public void GetAdressById_Should_GetsAdressOfInsertedId_ThenReturnsAdressEntity()
        {
            //Arrange

            var entity = new AdressEntity { StreetName = "Testvägen", PostalCode = "12345", City = "Stockholm" };
            var adressEntity = _adressService.CreateAdress(entity.StreetName, entity.PostalCode, entity.City);

            //Act
            var result = _adressService.GetAdressById(adressEntity.Id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);


        }

        [Fact]
        public void GetAdressById_ShouldNot_GetsAdressOfInsertedId_ThenReturnsNull()
        {
            //Arrange

            var entity = new AdressEntity { StreetName = "Testvägen", PostalCode = "12345", City = "Stockholm" };
            var adressEntity = _adressService.CreateAdress(entity.StreetName, entity.PostalCode, entity.City);

            //Act
            var result = _adressService.GetAdressById(adressEntity.Id + 1);

            //Assert
            Assert.Null(result);
           


        }

        [Fact]
        public void GetAdresses_Should_GetsAdressOfInsertedId_ThenReturnsAdressEntity()
        {
            //Arrange

            var entity = new AdressEntity { StreetName = "Testvägen", PostalCode = "12345", City = "Stockholm" };
            var adressEntity = _adressService.CreateAdress(entity.StreetName, entity.PostalCode, entity.City);

            //Act
            var result = _adressService.GetAdressById(adressEntity.Id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);


        }

        [Fact]
        public void GetAdresses_ShouldNot_GetanyAdress_ThenReturnsNull()
        {
            //Arrange

            var entity = new AdressEntity { StreetName = "Testvägen", PostalCode = "12345", City = "Stockholm" };
            var adressEntity = _adressService.CreateAdress(entity.StreetName, entity.PostalCode, entity.City);

            //Act
            var result = _adressService.GetAdressById(adressEntity.Id + 1);

            //Assert
            Assert.Null(result);

        }

        //Update
        [Fact]
        public void UpdateAdress_Should_UpdateAdressEntity_ThenReturnsAdressEntity()
        {
            //Arrange

            var entity = new AdressEntity { StreetName = "Testvägen", PostalCode = "12345", City = "Stockholm" };
            var adressEntity = _adressService.CreateAdress(entity.StreetName, entity.PostalCode, entity.City);
            adressEntity.StreetName = "Kungsgatan 5";

            //Act

            var result = _adressService.UpdateAdress(adressEntity);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Kungsgatan 5", result.StreetName);
            

        }

        [Fact]
        public void UpdateAdress_ShouldNot_UpdateAdressEntity_ThenReturnsNull()
        {
            //Arrange

            var entity = new AdressEntity { StreetName = "Testvägen", PostalCode = "12345", City = "Stockholm" };


            //Act

            var result = _adressService.UpdateAdress(entity);

            //Assert
            Assert.Null(result);
            
        }

        //Delete
        [Fact]
        public void DeleteAdress_Should_DeleteAdressEntity_ThenReturnsTrue()
        {
            //Arrange

            var entity = new AdressEntity { StreetName = "Testvägen", PostalCode = "12345", City = "Stockholm" };
            var adressEntity = _adressService.CreateAdress(entity.StreetName, entity.PostalCode, entity.City);


            //Act

            var result = _adressService.DeleteAdress(adressEntity.Id);

            //Assert
            Assert.True(result);
            


        }

        [Fact]
        public void DeleteAdress_ShouldNot_DeleteAdressEntity_ThenReturnsFalse()
        {
            //Arrange

            var entity = new AdressEntity { StreetName = "Testvägen", PostalCode = "12345", City = "Stockholm" };
            


            //Act

            var result = _adressService.DeleteAdress(entity.Id);

            //Assert
            Assert.False(result);

        }
    }
}
