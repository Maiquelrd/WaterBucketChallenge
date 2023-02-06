using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WaterBucketChallenge.Controllers;
using WaterBucketChallenge.Models;
using WaterBucketChallenge.Services;
using WaterBucketTesting.Services.Mocks;

namespace WaterBucketTesting.Controllers
{
    [TestClass]
    public class WaterBucketControllerTest
    {
        [TestMethod]
        public void ShowSteps_shouldCallShowStepsFromService()
        {
            int x = 3;
            int y = 5;
            int z = 4;
            string expected = WaterBucketServiceMock.ShowSteps;

            Mock<IWaterBucketService> serviceMock = new Mock<IWaterBucketService>();
            serviceMock.Setup(m => m.ShowSteps(x, y, z)).Returns(expected);
            WaterBucketController controller = new WaterBucketController(serviceMock.Object);

            string result = controller.ShowSteps(x, y, z);

            serviceMock.Verify(m => m.ShowSteps(x, y, z), Times.Exactly(1));
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void GetSteps_shouldCallGetStepsFromService()
        {
            int x = 3;
            int y = 5;
            int z = 4;
            List<Step> expected = WaterBucketServiceMock.GetSteps;

            Mock<IWaterBucketService> serviceMock = new Mock<IWaterBucketService>();
            serviceMock.Setup(m => m.GetSteps(x, y, z)).Returns(expected);
            WaterBucketController controller = new WaterBucketController(serviceMock.Object);

            List<Step> result = controller.GetSteps(x, y, z);

            serviceMock.Verify(m => m.GetSteps(x, y, z), Times.Exactly(1));
            Assert.AreEqual(result, expected);
        }
    }
}
