using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Linq;

namespace SimpleWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SimpleDateOnlyWorkaroundController : ControllerBase
{    
    // logger
    private readonly ILogger<SimpleDateOnlyWorkaroundController> _logger;

    // Datastore for demo purpose only.
    private static  List<DateOnly> _requestDates = null!;

    // Ctor
    public SimpleDateOnlyWorkaroundController(ILogger<SimpleDateOnlyWorkaroundController> logger)
    {
        _logger = logger;
        if(_requestDates == null)
        {
            _requestDates = new List<DateOnly>();
        }
    }

    [HttpGet]
    public List<DateOnly> Get()
    {   
        _logger.LogInformation("Get Called");     
        return _requestDates;
    }   

    [HttpPost]
    public void Save([FromBody]DateTime requestDate)
    {        
        _logger.LogInformation("Save Called");
        _requestDates.Add(DateOnly.FromDateTime(requestDate));
    }
}
