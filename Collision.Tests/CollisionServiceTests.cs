using CollisionServices.Implementations;
using CollisionServices.Interfaces;
using CollisionServices.Models;
using NUnit.Framework;

namespace Collision.Tests
{
    [TestFixture]
    public class CollisionServiceTests
    {
        private ICubeCollisionService collisionService;

        [SetUp]
        public void SetUp()
        {
            collisionService = new CubeCollisionService();
        }

        [Test]
        public void CheckCollision_CubesDoNotCollide_ReturnsFalse()
        {
            // Arrange
            var cube1 = new Cube (10, 0, 0, 0);
            var cube2 = new Cube (10, 20, 20, 20);

            // Act
            bool result = collisionService.CheckCollision(cube1, cube2);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckCollision_CubesCollide_ReturnsTrue()
        {
            // Arrange
            var cube1 = new Cube (10, 0, 0, 0);
            var cube2 = new Cube (10, 5, 5, 5);

            // Act
            bool result = collisionService.CheckCollision(cube1, cube2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CalculateIntersectedVolume_CubesDoNotCollide_ReturnsZero()
        {
            // Arrange
            var cube1 = new Cube (10, 0, 0, 0);
            var cube2 = new Cube (10, 20, 20, 20);

            // Act
            double volume = collisionService.CalculateIntersectedVolume(cube1, cube2);

            // Assert
            Assert.AreEqual(0, volume);
        }

        [Test]
        public void CalculateIntersectedVolume_CubesCollide_ReturnsIntersectedVolume()
        {
            // Arrange
            var cube1 = new Cube (10, 0, 0, 0) ;
            var cube2 = new Cube (10, 5, 5, 5);

            // Act
            double volume = collisionService.CalculateIntersectedVolume(cube1, cube2);

            // Assert
            Assert.AreEqual(125, volume);
        }
    }
}