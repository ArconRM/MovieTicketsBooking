using AutoMapper;
using Common.Protos;
using Microsoft.AspNetCore.Mvc;

namespace MovieTicketsService.Controllers;

public class TestController : Controller
{
    private readonly ILogger<TestController> _logger;

    private readonly IMapper _mapper;

    private readonly UserService.UserServiceClient _userServiceClient;

    public TestController(ILogger<TestController> logger, IMapper mapper, UserService.UserServiceClient client)
    {
        _logger = logger;
        _mapper = mapper;
        _userServiceClient = client;
    }

    [HttpGet("Test")]
    public async Task<ActionResult> Test(Guid id)
    {
        User user = await _userServiceClient.GetByIdAsync(new UuidQuery() { Uuid = id.ToString() });

        return Ok(user);
    }
}