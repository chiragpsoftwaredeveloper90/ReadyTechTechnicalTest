using CoffeeMachinMgmtSystem.Repository;
using CoffeeMachinMgmtSystem.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachinMgmtSystem.Test
{
    /// <summary>
    /// Coffee Machine Service Test
    /// </summary>
    public class CoffeeMachineServiceTest
    {
        private readonly Mock<ICoffeeMachineRepository> _mockRepository;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly CoffeeMachineService _service;

        /// <summary>
        /// Coffee Machine Service Test
        /// </summary>
        public CoffeeMachineServiceTest()
        {
            _mockRepository = new Mock<ICoffeeMachineRepository>();
            _mockConfiguration = new Mock<IConfiguration>();
            _service = new CoffeeMachineService(_mockRepository.Object, _mockConfiguration.Object);
        }

        /// <summary>
        /// Brew Coffee Increments Brew Count
        /// </summary>
        [Fact]
        public void BrewCoffee_IncrementsBrewCount()
        {
            _mockRepository.Setup(r => r.GetBrewCoffeeCount()).Returns(1);
            _mockConfiguration.Setup(c => c["coffeeReady"]).Returns("Your piping hot coffee is ready");

            var result = _service.BrewCoffee();
            _mockRepository.Verify(r => r.IncrementBrewCoffeeCount(), Times.Once);
            Assert.Equal("Your piping hot coffee is ready", result);
        }

        /// <summary>
        /// Is OutOf Coffee Returns True On Fifth Brew
        /// </summary>
        [Fact]
        public void IsOutOfCoffee_ReturnsTrue_OnFifthBrew()
        {
            _mockRepository.Setup(r => r.GetBrewCoffeeCount()).Returns(5);
            var result = _service.IsOutOfCoffee();
            Assert.True(result);
            _mockRepository.Verify(r => r.IncrementBrewCoffeeCount(), Times.Once);  
        }


        /// <summary>
        /// Is OutOf Coffee Returns False On Non Fifth Brew
        /// </summary>
        [Fact]
        public void IsOutOfCoffee_ReturnsFalse_OnNonFifthBrew()
        {
            _mockRepository.Setup(r => r.GetBrewCoffeeCount()).Returns(3);
            var result = _service.IsOutOfCoffee();
            Assert.False(result);
            _mockRepository.Verify(r => r.IncrementBrewCoffeeCount(), Times.Never);  
        }

        /// <summary>
        /// Is Teapot Day Returns True On April First
        /// </summary>
        [Fact]
        public void IsTeapotDay_ReturnsTrue_OnAprilFirst()
        {
            var testDate = new DateTime(2024, 4, 1);
            var result = _service.IsTeapotDay(testDate);
            Assert.True(result);
        }

        /// <summary>
        /// Is TeapotDay Returns False On Other Days
        /// </summary>
        [Fact]
        public void IsTeapotDay_ReturnsFalse_OnOtherDays()
        {
            var testDate = new DateTime(2024, 4, 2);
            var result = _service.IsTeapotDay(testDate);
            Assert.False(result);
        }
    }
}
