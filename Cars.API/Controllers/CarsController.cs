using Cars.Domain;
using Cars.Application.Cars;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Cars.API.Controllers;

public class CarsController : BaseApiController
{
    private readonly ISender _sender;

    public CarsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<List<Car>>> GetCars()
    {
        return await _sender.Send(new GetCarsList.Query());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Car>> GetCar(Guid id)
    {
        var car = await _sender.Send(new Details.Query { Id = id });

        if (car is null) return NotFound();

        return car;
    }
}