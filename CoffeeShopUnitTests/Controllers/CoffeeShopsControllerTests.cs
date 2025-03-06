using CoffeeShopApi.Controllers;
using CoffeeShopBusinessLogic;
using CoffeeShopDataLayer;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CoffeeShopUnitTests.Controllers
{
    public class CoffeeShopsControllerTests
    {
        private readonly Mock<ICoffeeShopRepository> _repositoryMock;
        private readonly Mock<ICoffeeShopDistanceLogic> _coffeeShopDistanceLogicMock;
        private readonly CoffeeShopsController _controller;

        public CoffeeShopsControllerTests()
        {
            _repositoryMock = new Mock<ICoffeeShopRepository>();
            _coffeeShopDistanceLogicMock = new Mock<ICoffeeShopDistanceLogic>();
            _controller = new CoffeeShopsController(_repositoryMock.Object, _coffeeShopDistanceLogicMock.Object);
        }

        [Fact]
        public void GetCoffeeShopsInOrder_ReturnsOrderedCoffeeShops()
        {
            var coffeeShops = new List<CoffeeShop>
            {
                new CoffeeShop(3.0, 3.0, "Test1 Coffee Shop"),
                new CoffeeShop(1.0, 1.0, "Test2 Coffee Shop")
            };
            _repositoryMock.Setup(r => r.GetCoffeeShops()).Returns(() => coffeeShops);
            const double x = 0;
            const double y = 0;
            var coffeeShopDtoList = new List<CoffeeShopDto>
            {
                new CoffeeShopDto("Test2 Coffee Shop", 1.0, 1.0, 1.2),
                new CoffeeShopDto("Test1 Coffee Shop", 3.0, 3.0, 5.3),
            };
            _coffeeShopDistanceLogicMock.Setup(logic => logic.ComputeClosestCoffeeShops(new UserLocation(x, y), coffeeShops))
                .Returns(coffeeShopDtoList);

            var result = _controller.GetCoffeeShopsInOrder(x, y) as OkObjectResult;
            var orderedShops = result?.Value as List<CoffeeShopDto>;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(orderedShops);
            Assert.Equal(2, orderedShops.Count);
            Assert.Equal("Test2 Coffee Shop", orderedShops[0].Name);
            Assert.Equal("Test1 Coffee Shop", orderedShops[1].Name);
        }
    }
}