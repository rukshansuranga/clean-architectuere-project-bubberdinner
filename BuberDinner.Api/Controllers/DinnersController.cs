using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

public class DinnersController : ApiController
{
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}