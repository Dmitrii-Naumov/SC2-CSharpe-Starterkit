using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarPathFinder
{
	public struct IntPoint2D
	{
		public int X;
		public int Y;
		public override int GetHashCode()
		{
			unchecked// Overflow is fine
			{
				//it should be enough considering the grid size is 0..255

				return X * 1699 + Y;
			}
		}
		public override bool Equals(object obj)
		{
			if (obj is IntPoint2D)
			{
				IntPoint2D secondPoint = (IntPoint2D)obj;

				return X == secondPoint.X && Y == secondPoint.Y;
			}
			return false;
		}
	}
}
