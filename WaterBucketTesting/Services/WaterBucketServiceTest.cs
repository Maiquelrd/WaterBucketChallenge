using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterBucketChallenge.Commons.Validators;
using WaterBucketChallenge.Models;
using WaterBucketChallenge.Services;
using WaterBucketTesting.Services.Mocks;

namespace WaterBucketTesting.Services
{
    [TestClass]
    public class WaterBucketServiceTest
    {
        [TestMethod]
        public void ShowSteps_shouldGetStepsAndShowTheDescriptions()
        {
            int x = 3;
            int y = 5;
            int z = 4;
            string expected = WaterBucketServiceMock.ShowSteps;
            Mock<IWaterBucketValditator> validatorMock = new Mock<IWaterBucketValditator>();
            Mock<WaterBucketService> serviceMock = new Mock<WaterBucketService>(validatorMock.Object);
            serviceMock.CallBase = true;
            serviceMock.Setup(m => m.GetSteps(x, y, z)).Returns(WaterBucketServiceMock.GetSteps);

            string result = serviceMock.Object.ShowSteps(x, y, z);

            serviceMock.Verify(m => m.GetSteps(x, y, z), Times.Exactly(1));
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void GetSteps_shouldValidAndGetSolution1()
        {
            int x = 3;
            int y = 5;
            int z = 4;
            List<Step> expected = WaterBucketServiceMock.GetSteps;

            Mock<IWaterBucketValditator> validatorMock = new Mock<IWaterBucketValditator>();
            validatorMock.Setup(m => m.Validate(x, y, z)).Returns(true);
            Mock<WaterBucketService> serviceMock = new Mock<WaterBucketService>(validatorMock.Object);
            serviceMock.CallBase = true;
            Bucket bucketX = new Bucket("X", 0, x);
            Bucket bucketY = new Bucket("Y", 0, y);
            serviceMock.Setup(m => m.Pour(It.Is<Bucket>(x => x.Name == "Y"), It.Is<Bucket>(x => x.Name == "X"), z)).Returns(WaterBucketServiceMock.GetSteps);
            serviceMock.Setup(m => m.Pour(It.Is<Bucket>(x => x.Name == "X"), It.Is<Bucket>(x => x.Name == "Y"), z)).Returns(WaterBucketServiceMock.GetSteps2);


            List<Step> result = serviceMock.Object.GetSteps(x, y, z);

            validatorMock.Verify(m => m.Validate(x, y, z), Times.Exactly(1));
            serviceMock.Verify(m => m.Pour(It.Is<Bucket>(x => x.Name == "Y"), It.Is<Bucket>(x => x.Name == "X"), z), Times.Exactly(1));
            serviceMock.Verify(m => m.Pour(It.Is<Bucket>(x => x.Name == "X"), It.Is<Bucket>(x => x.Name == "Y"), z), Times.Exactly(1));
            CollectionAssert.AreEqual(result, expected);
        }

        [TestMethod]
        public void GetSteps_shouldValidAndGetSolution2()
        {
            int x = 3;
            int y = 5;
            int z = 4;
            List<Step> expected = WaterBucketServiceMock.GetSteps;

            Mock<IWaterBucketValditator> validatorMock = new Mock<IWaterBucketValditator>();
            validatorMock.Setup(m => m.Validate(x, y, z)).Returns(true);
            Mock<WaterBucketService> serviceMock = new Mock<WaterBucketService>(validatorMock.Object);
            serviceMock.CallBase = true;
            Bucket bucketX = new Bucket("X", 0, x);
            Bucket bucketY = new Bucket("Y", 0, y);
            serviceMock.Setup(m => m.Pour(It.Is<Bucket>(x => x.Name == "Y"), It.Is<Bucket>(x => x.Name == "X"), z)).Returns(WaterBucketServiceMock.GetSteps2);
            serviceMock.Setup(m => m.Pour(It.Is<Bucket>(x => x.Name == "X"), It.Is<Bucket>(x => x.Name == "Y"), z)).Returns(WaterBucketServiceMock.GetSteps);


            List<Step> result = serviceMock.Object.GetSteps(x, y, z);

            validatorMock.Verify(m => m.Validate(x, y, z), Times.Exactly(1));
            serviceMock.Verify(m => m.Pour(It.Is<Bucket>(x => x.Name == "Y"), It.Is<Bucket>(x => x.Name == "X"), z), Times.Exactly(1));
            serviceMock.Verify(m => m.Pour(It.Is<Bucket>(x => x.Name == "X"), It.Is<Bucket>(x => x.Name == "Y"), z), Times.Exactly(1));
            CollectionAssert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Pour_shouldPourFromLessBucketToMost()
        {
            Bucket bucketX = new Bucket("X", 0, 3);
            Bucket bucketY = new Bucket("Y", 0, 5);
            int z = 4;
            List<Step> expected = WaterBucketServiceMock.GetSteps2;

            Mock<IWaterBucketValditator> validatorMock = new Mock<IWaterBucketValditator>();
            Mock<WaterBucketService> serviceMock = new Mock<WaterBucketService>(validatorMock.Object);
            serviceMock.CallBase = true;


            List<Step> result = serviceMock.Object.Pour(bucketX, bucketY, z);

            serviceMock.Verify(m => m.Fill(It.Is<Bucket>(x => x.Name == "X"), It.IsAny<List<Step>>()), Times.Exactly(3));
            serviceMock.Verify(m => m.Transfer(It.Is<Bucket>(x => x.Name == "X"), It.Is<Bucket>(x => x.Name == "Y"), It.IsAny<int>(), It.IsAny<List<Step>>()), Times.Exactly(4));
            serviceMock.Verify(m => m.Dump(It.Is<Bucket>(x => x.Name == "Y"), It.IsAny<List<Step>>()), Times.Exactly(1));
            Assert.AreEqual(result[2].Action, expected[2].Action);
        }

        [TestMethod]
        public void Pour_shouldPourFromMostBucketToLess()
        {
            Bucket bucketX = new Bucket("X", 0, 3);
            Bucket bucketY = new Bucket("Y", 0, 5);
            int z = 4;
            List<Step> expected = WaterBucketServiceMock.GetSteps;

            Mock<IWaterBucketValditator> validatorMock = new Mock<IWaterBucketValditator>();
            Mock<WaterBucketService> serviceMock = new Mock<WaterBucketService>(validatorMock.Object);
            serviceMock.CallBase = true;


            List<Step> result = serviceMock.Object.Pour(bucketY, bucketX, z);

            serviceMock.Verify(m => m.Fill(It.Is<Bucket>(x => x.Name == "Y"), It.IsAny<List<Step>>()), Times.Exactly(2));
            serviceMock.Verify(m => m.Transfer(It.Is<Bucket>(x => x.Name == "Y"), It.Is<Bucket>(x => x.Name == "X"), It.IsAny<int>(), It.IsAny<List<Step>>()), Times.Exactly(3));
            serviceMock.Verify(m => m.Dump(It.Is<Bucket>(x => x.Name == "X"), It.IsAny<List<Step>>()), Times.Exactly(1));
            Assert.AreEqual(result[2].Action, expected[2].Action);
        }
    }
}
