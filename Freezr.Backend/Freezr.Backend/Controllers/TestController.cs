using System.Collections.Generic;
using System.Threading.Tasks;
using Freezr.Backend.Repositories;
using Freezr.Entities;
using Freezr.Messaging;
using Freezr.Messaging.Messages.Events;
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

        [HttpPost]
        public IActionResult AddNewFridge(string name)
        {
            var fridge = new Fridge { Name = name };

            var eventMessage = new FridgeAddedEvent { Fridge = fridge,  };
            MessageQueue.Publish(eventMessage);

            return Created($"api/fridges", fridge);
        }
    }
}
