using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachinMgmtSystem.Services
{
    /// <summary>
    /// Coffee Machine Service interface
    /// </summary>
    public interface ICoffeeMachineService
    {
        /// <summary>
        /// Brew Coffee
        /// </summary>
        /// <returns>string</returns>
        public string BrewCoffee();

        /// <summary>
        /// Is OutOf Coffee?
        /// </summary>
        /// <returns>bool</returns>
        public bool IsOutOfCoffee();

        /// <summary>
        /// Is Teapot Day?
        /// </summary>
        /// <returns>bool</returns>
        public bool IsTeapotDay(DateTime? date = null);
    }
}
