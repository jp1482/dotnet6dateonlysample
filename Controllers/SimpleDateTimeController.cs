using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Linq;

namespace SimpleWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SimpleDateTimeController : ControllerBase
{    
    // logger
    private readonly ILogger<SimpleDateTimeController> _logger;

    // Datastore for demo purpose only.
    private static  List<DateTime> _requestDates = null!;

    // Ctor
    public SimpleDateTimeController(ILogger<SimpleDateTimeController> logger)
    {
        _logger = logger;
        if(_requestDates == null)
        {
            _requestDates = new List<DateTime>();
        }
    }

    [HttpGet]
    public List<DateTime> Get()
    {   
        _logger.LogInformation("Get Called");     
        return _requestDates;
    }   

    [HttpPost]
    public void Save([FromBody]DateTime requestDate)
    {        
        _logger.LogInformation("Save Called");
        _requestDates.Add(requestDate);
    }
}
