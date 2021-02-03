using System;
using AStarPathFinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AStarTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void CanCalculateStraightPath()
		{
			bool[,] map = new bool[3, 3];
			map[0, 0] = true;
			map[0, 1] = true;
			map[0, 2] = true;
			IntPoint2D from = new IntPoint2D() { X = 0, Y = 0 };
			IntPoint2D to = new IntPoint2D() { X = 0, Y = 2 };
			Assert.AreEqual(2, AStarPathFinder.AStarPathFinder.GetBestPathLength(from, to, map));
		}
		[TestMethod]
		public void CannotGoThroughWalls()
		{
			bool[,] map = new bool[3, 3];
			map[0, 0] = true;
			map[0, 1] = true;
			map[0, 2] = true;

			map[2, 0] = true;
			map[2, 1] = true;
			map[2, 2] = true;
			IntPoint2D from = new IntPoint2D() { X = 0, Y = 0 };
			IntPoint2D to = new IntPoint2D() { X = 2, Y = 2 };
			Assert.AreEqual(-1, AStarPathFinder.AStarPathFinder.GetBestPathLength(from, to, map));
		}
		[TestMethod]
		public void CanCalculateComplexPath()
		{
			bool[,] map = new bool[5, 5];
			map[0, 0] = true;
			map[0, 1] = true;
			map[0, 2] = true;
			map[0, 3] = true;


			map[1, 2] = true;

			map[2, 0] = true;
			map[2, 1] = true;
			map[2, 2] = true;
			map[2, 3] = true;

			map[3, 0] = true;
			map[3, 1] = true;
			map[3, 2] = true;
			map[3, 3] = true;
			IntPoint2D from = new IntPoint2D() { X = 0, Y = 0 };
			IntPoint2D to = new IntPoint2D() { X = 3, Y = 0 };
			//4 because we can move diagonally
			Assert.AreEqual(4, AStarPathFinder.AStarPathFinder.GetBestPathLength(from, to, map));
		}
	}
}
