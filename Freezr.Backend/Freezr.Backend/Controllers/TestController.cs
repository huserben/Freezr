using System;
using System.Collections.Generic;
using System.Linq;
using Freezr.Backend.Model;
using Freezr.Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Freezr.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> logger;
        private readonly IFridgeRepository fridgeRepository;

        public TestController(ILogger<TestController> logger, IFridgeRepository fridgeRepository)
        {
            this.logger = logger;
            this.fridgeRepository = fridgeRepository;
        }

        [HttpGet]
        public IEnumerable<Fridge> Get()
        {
            return fridgeRepository.GetFridges();
        }
    }
}
