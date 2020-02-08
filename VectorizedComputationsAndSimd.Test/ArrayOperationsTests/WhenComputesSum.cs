using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VectorizedComputationsAndSimd.Test.ArrayOperationsTests
{
    [TestClass]
    public class WhenComputesSum
    {
        private readonly List<(int[], int)> _arrays = new List<(int[], int)>
        {
            (new [] {63, -43, 123, 1567, 123, 565, 4307, -128, 0}, 6577),
            (new [] {98, 123, -9, -135, -1245, 75, 157, -68, -135, 545}, -594),
            (new [] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}, 325)
        };
        
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        public void UsingLinqSum_ShouldReturnSum(int index)
        {
            // Arrange
            var (matrix, expected) = _arrays[index];
            
            // Act
            var sum = ArrayOperations.LinqSum(matrix);

            // Assert
            Assert.AreEqual(expected, sum);
        }
        
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        public void UsingNaiveSum_ShouldReturnSum(int index)
        {
            // Arrange
            var (matrix, expected) = _arrays[index];
            
            // Act
            var sum = ArrayOperations.NaiveSum(matrix);

            // Assert
            Assert.AreEqual(expected, sum);
        }
        
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        public void UsingSimdSum_ShouldReturnSum(int index)
        {
            // Arrange
            var (matrix, expected) = _arrays[index];
            
            // Act
            var sum = ArrayOperations.SimdSum(matrix);

            // Assert
            Assert.AreEqual(expected, sum);
        }
    }
}