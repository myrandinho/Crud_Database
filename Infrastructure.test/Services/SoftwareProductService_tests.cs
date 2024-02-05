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

            
            _softwareProductService = new SoftwareProductService(new SoftwareProductRepository(_context2), _sizeService);
        }



        //Create
        [Fact]
        public void Create_Should_CreateSoftwareProductEntity_AndSaveToDatabase_ThenReturnsEntity()
        {
            //arrange
            var sizeEntity = new Size { Id = 1, Quantity = 12, Unit = "GB" };
            var sizeResult = _sizeService.CreateSize(sizeEntity.Quantity, sizeEntity.Unit);
            var softwareProductEntity = new SoftwareProduct { Title = "Adobe Photoshop"};

            //act
            var result = _softwareProductService.CreateSoftwareProduct(softwareProductEntity.Title, sizeEntity.Quantity, sizeEntity.Unit);


            //assert
            Assert.NotNull(result);
            Assert.Equal("Adobe Photoshop", result.Title);
        }
        
    }
}
