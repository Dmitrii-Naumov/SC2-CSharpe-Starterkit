using System.Collections.Generic;
using System.Numerics;
using SC2APIProtocol;

namespace SC2_Connector
{
    public class BaseLocation
    {
        public BaseLocation(Vector3 position, List<Unit> resources)
        {
            Position = position;
            MineralFields = new List<MineralField>();
            foreach (var unit in resources)
            {
                if (Units.MineralFields.Contains(unit.UnitType))
                {
                    MineralFields.Add(new MineralField(unit));
                }
            }
        }
        public List<MineralField> MineralFields { get; internal set; }
        public List<Gas> Gasses { get; internal set; } 
        public Vector3 Position { get; set; }
    }
}
