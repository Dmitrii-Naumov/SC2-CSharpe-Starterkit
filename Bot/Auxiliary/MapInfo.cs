using SC2APIProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Auxiliary
{
	public class MapInfo
    {
        private const int SquaredDistanceExpandToResourceField = 260;
        public List<Vector3> ExpandLocations;

        public List<Vector3> GetExpandLocations()
        {
            if (ExpandLocations != null && ExpandLocations.Count != 0)
                return ExpandLocations;

            //   var geysers= GetUnits(Units.GasGeysers);
            //    var mineralPatches = GetUnits(Units.MineralFields);
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
            List<Vector3> expandLocations = new List<Vector3>();
            foreach (var group in groups)
            {
                Vector3 center = new Vector3();
                foreach (var location in group)
                {
                    center += location.Position;
                }
                center /= group.Count;
                expandLocations.Add(center);
            }
            ExpandLocations = expandLocations;
            return ExpandLocations;
        }
        private static bool IsInRangeOfResource(Vector3 resourceFieldPosition, Vector3 unitPostion)
        {
            return Math.Round(unitPostion.Z) == Math.Round(resourceFieldPosition.Z)
                                    && Vector3.DistanceSquared(unitPostion, resourceFieldPosition) < SquaredDistanceExpandToResourceField;
        }
    }
}
