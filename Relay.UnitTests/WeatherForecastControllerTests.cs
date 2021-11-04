using FakeItEasy;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Relay.Controllers;
using System.Collections;
using System.Linq;

namespace Relay.UnitTests
{
    public class WeatherForecastControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Get_ListOfWealtherForecast_ReturnIenumerable()
        {
            Assert.Pass();
        }
    }
}