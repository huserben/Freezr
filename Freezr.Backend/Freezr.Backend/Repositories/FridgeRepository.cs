using Freezr.Entities;
using Freezr.Model;
using System.Collections.Generic;

namespace Freezr.Backend.Repositories
{
    public class FridgeRepository : IFridgeRepository
    {
        private readonly FreezrContext freezrContext;

        public FridgeRepository(FreezrContext freezrContext)
        {
            this.freezrContext = freezrContext;
        }

        public IEnumerable<Fridge> GetFridges()
        {
            return freezrContext.Fridges;
        }
    }
}
