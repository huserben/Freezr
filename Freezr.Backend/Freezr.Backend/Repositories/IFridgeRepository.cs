using Freezr.Backend.Model;
using System.Collections.Generic;

namespace Freezr.Backend.Repositories
{
    public interface IFridgeRepository
    {
        IEnumerable<Fridge> GetFridges();
    }
}