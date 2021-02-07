using System.Collections.Generic;
using SC2APIProtocol;

namespace SC2_Connector
{
    public static class BuildingType
    {
        public static Point2D GetBuildingSize(uint buildingType)
        {
            switch (buildingType)
            {
                case 5: return new Point2D() { X = 2, Y = 2 };
                case 6: return new Point2D() { X = 2, Y = 2 };
                case 18: return new Point2D() { X = 5, Y = 5 };
                case 19: return new Point2D() { X = 2, Y = 2 };
                case 20: return new Point2D() { X = 3, Y = 3 };
                case 21: return new Point2D() { X = 3, Y = 3 };
                case 22: return new Point2D() { X = 3, Y = 3 };
                case 23: return new Point2D() { X = 2, Y = 2 };
                case 24: return new Point2D() { X = 3, Y = 3 };
                case 25: return new Point2D() { X = 2, Y = 2 };
                case 27: return new Point2D() { X = 3, Y = 3 };
                case 28: return new Point2D() { X = 3, Y = 3 };
                case 29: return new Point2D() { X = 3, Y = 3 };
                case 30: return new Point2D() { X = 3, Y = 3 };
                case 59: return new Point2D() { X = 5, Y = 5 };
                case 60: return new Point2D() { X = 2, Y = 2 };
                case 61: return new Point2D() { X = 3, Y = 3 };
                case 62: return new Point2D() { X = 3, Y = 3 };
                case 63: return new Point2D() { X = 3, Y = 3 };
                case 64: return new Point2D() { X = 3, Y = 3 };
                case 65: return new Point2D() { X = 3, Y = 3 };
                case 66: return new Point2D() { X = 2, Y = 2 };
                case 67: return new Point2D() { X = 3, Y = 3 };
                case 68: return new Point2D() { X = 3, Y = 3 };
                case 69: return new Point2D() { X = 2, Y = 2 };
                case 70: return new Point2D() { X = 3, Y = 3 };
                case 71: return new Point2D() { X = 3, Y = 3 };
                case 72: return new Point2D() { X = 3, Y = 3 };
                case 86: return new Point2D() { X = 5, Y = 5 };
                case 87: return new Point2D() { X = 1, Y = 1 };
                case 88: return new Point2D() { X = 3, Y = 3 };
                case 89: return new Point2D() { X = 3, Y = 3 };
                case 90: return new Point2D() { X = 3, Y = 3 };
                case 91: return new Point2D() { X = 3, Y = 3 };
                case 92: return new Point2D() { X = 3, Y = 3 };
                case 93: return new Point2D() { X = 3, Y = 3 };
                case 94: return new Point2D() { X = 3, Y = 3 };
                case 96: return new Point2D() { X = 3, Y = 3 };
                case 97: return new Point2D() { X = 3, Y = 3 };
                case 98: return new Point2D() { X = 2, Y = 2 };
                case 99: return new Point2D() { X = 2, Y = 2 };
                case 130: return new Point2D() { X = 5, Y = 5 };
                case 132: return new Point2D() { X = 5, Y = 5 };
                case 133: return new Point2D() { X = 3, Y = 3 };
                case 504: return new Point2D() { X = 3, Y = 3 };
                case 1910: return new Point2D() { X = 2, Y = 2 };
                case 639: return new Point2D() { X = 6, Y = 6 };
                case 376: return new Point2D() { X = 6, Y = 6 };
                case 377: return new Point2D() { X = 6, Y = 6 };
                default: throw new System.Exception("Unknown building type");
            }
        }
    }
}
