﻿using System;
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

			var pathLength = AStarPathFinder.AStarPathFinder.GetBestPathLength(from, to, map);
			Assert.IsTrue(pathLength>5 && pathLength<6);
		}
		[TestMethod]
		public void CalculatesPathEfficiently()
		{
			bool[,] map = new bool[5, 5];
			for (int i = 0; i < 5; i++)
				for (int j = 0; j < 5; j++)
					map[i, j] = true;

			IntPoint2D from = new IntPoint2D() { X = 0, Y = 0 };
			IntPoint2D to = new IntPoint2D() { X = 4, Y = 4 };

			int visitedNodesCount;
			var pathLength = AStarPathFinder.AStarPathFinder.GetBestPathLength(from, to, map, out visitedNodesCount);
			Assert.IsTrue(pathLength > 5 && pathLength < 6, "Wrong Path Calculated");
			Assert.IsTrue(visitedNodesCount >= 4 && visitedNodesCount <= 8, "Path Calculated Inefficiently");
		}
	}
}
