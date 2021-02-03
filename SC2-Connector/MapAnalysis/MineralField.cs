using SC2APIProtocol;
using System.Numerics;

namespace SC2_Connector
{
    public class MineralField
    {
        public MineralField(Unit mineralField)
        {
            Position = mineralField.Position;
            Tag = mineralField.Tag;
        }
        public Vector3 Position { get; set; }
        public ulong Tag { get; set; }
    }
}
