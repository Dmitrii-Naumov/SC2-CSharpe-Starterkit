using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Google.Protobuf.Collections;
using SC2APIProtocol;

namespace Bot
{
    [DebuggerDisplay("{Name} - ({Position.X},{Position.Y})")]
    public class Unit {
        private SC2APIProtocol.Unit Original;
        private UnitTypeData UnitTypeData;

        public string Name;
        public uint UnitType;
        public float Integrity;
        public Vector3 Position;
        public ulong Tag;
        public float BuildProgress;
        public UnitOrder Order;
        public RepeatedField<UnitOrder> Orders;
        public int Supply;
        public bool IsVisible;
        public int IdealWorkers;
        public int AssignedWorkers;
        public int Energy;
        public int MaxEnergy;
        public bool IsInjected;

        public Unit(SC2APIProtocol.Unit unit) {
            this.Original = unit;
            this.UnitTypeData = Controller.gameData.Units[(int) unit.UnitType];

            this.Name = UnitTypeData.Name;
            this.Tag = unit.Tag;
            this.UnitType = unit.UnitType;
            this.Position = new Vector3(unit.Pos.X, unit.Pos.Y, unit.Pos.Z);
            this.Integrity = (unit.Health + unit.Shield) / (unit.HealthMax + unit.ShieldMax);
            this.BuildProgress = unit.BuildProgress;
            this.IdealWorkers = unit.IdealHarvesters;
            this.AssignedWorkers = unit.AssignedHarvesters;
            
            this.Order = unit.Orders.Count > 0 ? unit.Orders[0] : new UnitOrder();
            this.Orders = unit.Orders;
            this.IsVisible = (unit.DisplayType == DisplayType.Visible);

            this.Supply = (int) UnitTypeData.FoodRequired;
            this.Energy = (int)unit.Energy;
            this.Energy = (int)unit.EnergyMax;
            this.IsInjected = unit.BuffIds.Contains(Buffs.QUEENSPAWNLARVATIMER);
        }
    }
}