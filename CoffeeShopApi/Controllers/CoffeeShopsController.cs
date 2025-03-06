using CoffeeShopBusinessLogic;
using CoffeeShopDataLayer;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopApi.Controllers;

[ApiController]
[Route("/")]
public class CoffeeShopsController : ControllerBase
{
    private readonly ICoffeeShopRepository _coffeeShopRepository;
    private readonly ICoffeeShopDistanceLogic _coffeeShopDistanceLogic;

    public CoffeeShopsController(ICoffeeShopRepository coffeeShopRepository, ICoffeeShopDistanceLogic coffeeShopDistanceLogic)
    {
        this._coffeeShopRepository = coffeeShopRepository;
        this._coffeeShopDistanceLogic = coffeeShopDistanceLogic;
    }

    [HttpGet("/coffee-shops")]
    public IActionResult GetCoffeeShopsInOrder([FromQuery] double x, [FromQuery] double y)
    {
        var orderedShops = _coffeeShopDistanceLogic.ComputeClosestCoffeeShops(new UserLocation(x, y),
            _coffeeShopRepository.GetCoffeeShops().ToList());
        return Ok(orderedShops);
    }
}