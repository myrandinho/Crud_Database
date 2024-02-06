using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.test.Services
{
    public class SoftwareProductService_tests
    {

        private readonly SoftwareProductService _softwareProductService;
        private readonly SizeService _sizeService;
        private readonly DataContext2 _context2;


        public SoftwareProductService_tests()
        {
            _context2 = new DataContext2(new DbContextOptionsBuilder<DataContext2>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .Options);

            var sizeRepository = new SizeRepository(_context2);
            _sizeService = new SizeService(sizeRepository);

            _softwareProductService = new SoftwareProductService(new SoftwareProductRepository(_context2), _sizeService);
        }



        //Create
        [Fact]
        public void Create_Should_CreateSoftwareProductEntity_AndSaveToDatabase_ThenReturnsEntity()
        {
            //arrange
            var sizeEntity = new Size { Quantity = 12, Unit = "GB" };

            var sizeResult = _sizeService.CreateSize(sizeEntity.Quantity, sizeEntity.Unit);
            

            //act
            
            var result = _softwareProductService.CreateSoftwareProduct("Adobe Photoshop", sizeEntity.Quantity, sizeEntity.Unit);


            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(1, sizeResult.Id);
        }

        [Fact]
        public void Create_ShouldNot_CreateSoftwareProductEntity_AndSaveToDatabase_ThenReturnsNull()
        {
            //arrange
            var sizeEntity = new Size {};

            var sizeResult = _sizeService.CreateSize(sizeEntity.Quantity, sizeEntity.Unit);


            //act

            var result = _softwareProductService.CreateSoftwareProduct("Adobe Photoshop", sizeEntity.Quantity, sizeEntity.Unit);


            //assert
            Assert.Null(result);
            
        }

        //Get

        [Fact]
        public void Get_Should_FindEntityWithSelctedId_ThenReturnsEntity()
        {
            //arrange
            var sizeEntity = new Size { Quantity = 12, Unit = "GB" };
            var sizeResult = _sizeService.CreateSize(sizeEntity.Quantity, sizeEntity.Unit);
            var spResult = _softwareProductService.CreateSoftwareProduct("Adobe Photoshop", sizeResult.Quantity, sizeResult.Unit);

            //act

            var result = _softwareProductService.GetSoftwareProductById(spResult.Id);


            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Get_ShouldNot_FindEntityWithSelctedId_ThenReturnsNull()
        {
            //arrange
            var sizeEntity = new Size { Quantity = 12, Unit = "GB" };
            var sizeResult = _sizeService.CreateSize(sizeEntity.Quantity, sizeEntity.Unit);
            var spResult = _softwareProductService.CreateSoftwareProduct("Adobe Photoshop", sizeResult.Quantity, sizeResult.Unit);

            //act

            var result = _softwareProductService.GetSoftwareProductById(spResult.Id + 1);


            //assert
            Assert.Null(result);
            
            
        }

        [Fact]
        public void GetAll_Should_GetAllSoftwareProductsFromDatabase_ThenReturnsThemAll()
        {
            //arrange
            var sizeEntity = new Size { Quantity = 12, Unit = "GB" };
            var sizeResult = _sizeService.CreateSize(sizeEntity.Quantity, sizeEntity.Unit);
            var spResult = _softwareProductService.CreateSoftwareProduct("Adobe Photoshop", sizeResult.Quantity, sizeResult.Unit);

            //act

            var result = _softwareProductService.GetSoftwareProducts();


            //assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            
        }

        [Fact]
        public void GetAll_ShouldNot_GetAllSoftwareProductsFromDatabase_ThenReturnsNull()
        {
            //arrange
            var sizeEntity = new Size { Quantity = 12, Unit = "GB" };
            var spEntity = new SoftwareProduct { Title = "Microsoft Powerpoint" };


            //act

            var result = _softwareProductService.GetSoftwareProducts();


            //assert
            Assert.Empty(result);

        }

        //Update
        [Fact]
        public void Update_Should_UpdateSelectedSoftwareProduct_ThenReturnSoftwareProduct()
        {
            //arrange
            var sizeEntity = new Size { Quantity = 12, Unit = "GB" };
            var sizeResult = _sizeService.CreateSize(sizeEntity.Quantity, sizeEntity.Unit);
            var softwareProduct = _softwareProductService.CreateSoftwareProduct("Adobe Photoshop", sizeResult.Quantity, sizeResult.Unit);
            softwareProduct.Title = "Microsoft Paint";

            //act
            var result = _softwareProductService.UpdateSoftwareProduct(softwareProduct);

            //Assert
            Assert.NotNull(softwareProduct);
            Assert.Equal("Microsoft Paint", result.Title);

        }
        [Fact]
        public void Update_ShouldNot_UpdateSelectedSoftwareProduct_ThenReturnsNull()
        {
            //arrange
            var sizeEntity = new Size { Quantity = 12, Unit = "GB" };
            
            var softwareProduct = new SoftwareProduct { Title = "Harpan" };

            //act
            var result = _softwareProductService.UpdateSoftwareProduct(softwareProduct);

            //Assert
            Assert.Null(result);
           

        }

        //Delete
        [Fact]
        public void Delete_Should_DeleteSelectedSoftwareProduct_ThenReturnTrue()
        {
            //arrange
            var sizeEntity = new Size { Quantity = 12, Unit = "GB" };
            var sizeResult = _sizeService.CreateSize(sizeEntity.Quantity, sizeEntity.Unit);
            var softwareProduct = _softwareProductService.CreateSoftwareProduct("Adobe Photoshop", sizeResult.Quantity, sizeResult.Unit);
            

            //act
            var result = _softwareProductService.DeleteSoftwareProduct(softwareProduct.Id);

            //Assert
            Assert.True(result);
            

        }

        [Fact]
        public void Delete_ShouldNot_DeleteSelectedSoftwareProduct_ThenReturnFalse()
        {
            //arrange
            var sizeEntity = new Size { Quantity = 12, Unit = "GB" };
            var softwareProduct = new SoftwareProduct { Title = "Pinball" };


            //act
            var result = _softwareProductService.DeleteSoftwareProduct(softwareProduct.Id);

            //Assert
            Assert.False(result);


        }
    }
}
