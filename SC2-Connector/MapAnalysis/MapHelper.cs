using AStarPathFinder;
using SC2APIProtocol;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SC2_Connector
{
    public static class MapHelper
    {
        public static string GetMapName()
        {
            return Controller.GameInfo.MapName;
        }
        private const int SquaredDistanceExpandToResourceField = 260;
        private static List<BaseLocation> ExpandLocations;

        public static List<BaseLocation> GetExpandLocations()
        {
            if (ExpandLocations != null && ExpandLocations.Count != 0)
                return ExpandLocations;

            var allResources = Controller.GetUnits(Units.ResourceField, alliance: Alliance.Neutral);

            List<List<Unit>> groups = new List<List<Unit>>();
            foreach (var resourceField in allResources)
            {
                bool found = false;
                foreach (var group in groups)
                {
                    if (group.Count > 0 && IsInRangeOfResource(resourceField.Position, group[0].Position))
                    {
                        group.Add(resourceField);
                        found = true;
                        break;
                    }
                }
                if (!found)
                    groups.Add(new List<Unit>() { resourceField });
            }
            List<BaseLocation> expandLocations = new List<BaseLocation>();
            foreach (var group in groups)
            {
                Vector3 center = new Vector3();
                foreach (var location in group)
                {
                    center += location.Position;
                }
                center /= group.Count;
                expandLocations.Add(new BaseLocation(center, group));
            }
            ExpandLocations = expandLocations;
            return ExpandLocations;
        }

        private static bool IsInRangeOfResource(Vector3 resourceFieldPosition, Vector3 unitPostion)
        {
            return Math.Round(unitPostion.Z) == Math.Round(resourceFieldPosition.Z)
                                    && Vector3.DistanceSquared(unitPostion, resourceFieldPosition) < SquaredDistanceExpandToResourceField;
        }

        public static double GetPathDistance(Vector3 from, Vector3 to)
        {
            //Does not work for some reason
            //RequestQueryPathing queryPathing = new RequestQueryPathing();
            //queryPathing.StartPos = VectorToPoint(location);
            //queryPathing.EndPos = VectorToPoint(position);

            //Request requestQuery = new Request();
            //requestQuery.Query = new RequestQuery();
            //requestQuery.Query.Pathing.Add(queryPathing);

            //var result = Connection.SendQuery(requestQuery.Query);
            //if (result.Result.Pathing.Count > 0)
            //    return result.Result.Pathing[0].Distance;
          

            return AStarPathFinder.AStarPathFinder.GetBestPathLength(VectorToIntPoint(from), VectorToIntPoint(to), GetPathingGrid());
        }
        private static IntPoint2D VectorToIntPoint(Vector3 vector)
        {
            var point = new IntPoint2D();
            point.X = (int)vector.X;
            point.Y = (int)vector.Y;
            return point;
        }
        public static bool[,] GetPathingGrid()
        {
            ImageBoolGrid pathingGrid = new ImageBoolGrid(Controller.GameInfo.StartRaw.PathingGrid);
            return ConvertToBoolArray(pathingGrid);
        }
        public static bool[,] GetPlacementGrid()
        {
            ImageBoolGrid placementGrid = new ImageBoolGrid(Controller.GameInfo.StartRaw.PlacementGrid);
            return ConvertToBoolArray(placementGrid);
        }
        public static bool[,] GetCreepGrid()
		{
			ImageBoolGrid creepGrid = new ImageBoolGrid(Controller.Observation.Observation.RawData.MapState.Creep);
			return ConvertToBoolArray(creepGrid);
		}

        public static bool[,] GetPowerFieldGrid()
        {
            throw new NotImplementedException();
        }

        private static bool[,] ConvertToBoolArray(ImageBoolGrid imgeBoolGrid)
		{
			bool[,] result = new bool[imgeBoolGrid.Width(), imgeBoolGrid.Height()];
			for (int i = 0; i < imgeBoolGrid.Width(); i++)
				for (int j = 0; j < imgeBoolGrid.Height(); j++)
				{
					result[i, j] = imgeBoolGrid[i, j];
				}

			return result;
		}
        internal static bool[,] And(bool[,] a, bool[,] b)
        {
            bool[,] result = new bool[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    result[i, j] = a[i, j] && b[i, j];
            return result;
        }

	}
}
