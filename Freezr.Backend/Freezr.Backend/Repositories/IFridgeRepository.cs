using Freezr.Entities;
using System.Collections.Generic;

namespace Freezr.Backend.Repositories
{
    public interface IFridgeRepository
    {
        IEnumerable<Fridge> GetFridges();
    }
}