using CoffeeShopBusinessLogic;
using CoffeeShopDataLayer;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopApi.Controllers;

[ApiController]
[Route("/")]
public class CoffeeShopsController : ControllerBase
{
    private readonly ICoffeeShopRepository _coffeeShopRepository;
    private readonly CoffeeShopDistanceLogic _coffeeShopDistanceLogic;

    public CoffeeShopsController(ICoffeeShopRepository coffeeShopRepository)
    {
        this._coffeeShopRepository = coffeeShopRepository;
        _coffeeShopDistanceLogic = new CoffeeShopDistanceLogic();
    }

    [HttpGet("/coffee-shops")]
    public IActionResult GetCoffeeShopsInOrder([FromQuery] double x, [FromQuery] double y)
    {
        return Ok(_coffeeShopDistanceLogic.ComputeClosestCoffeeShops(new UserLocation(x, y), _coffeeShopRepository.GetCoffeeShops().ToList()));
    }
}