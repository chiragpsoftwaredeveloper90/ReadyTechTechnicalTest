using CoffeeMachinMgmtSystem.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachinMgmtSystem.Services
{
    /// <summary>
    /// Coffee Machine Service Class
    /// </summary>
    public class CoffeeMachineService : ICoffeeMachineService
    {
        private readonly ICoffeeMachineRepository _coffeeMachineRepository;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Coffee Machine Service Constructor
        /// </summary>
        /// <param name="coffeeMachineRepository"></param>
        /// <param name="configuration"></param>
        public CoffeeMachineService(ICoffeeMachineRepository coffeeMachineRepository, IConfiguration configuration) {
            _coffeeMachineRepository = coffeeMachineRepository;
            _configuration = configuration;
        }

        /// <summary>
        /// Brew Coffee
        /// </summary>
        /// <returns>string</returns>
        public string BrewCoffee()
        {
            _coffeeMachineRepository.IncrementBrewCoffeeCount();
            return _configuration["coffeeReady"];
        }

        /// <summary>
        /// Is Out Of Coffee?
        /// </summary>
        /// <returns>bool</returns>
        public bool IsOutOfCoffee()
        {
            if (_coffeeMachineRepository.GetBrewCoffeeCount() % 5 == 0)
            {
                _coffeeMachineRepository.IncrementBrewCoffeeCount();
                return true;
            }

            return false;
            
        }

        /// <summary>
        /// Is Teapot Day?
        /// </summary>
        /// <returns>bool</returns>
        public bool IsTeapotDay(DateTime? date = null)
        {
            DateTime currentDate = date ?? DateTime.Now;
            return currentDate.Month == 4 && currentDate.Day == 1;
        }
    }
}
