using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Google.Protobuf.Collections;
using SC2APIProtocol;

// ReSharper disable MemberCanBePrivate.Global

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


        public double GetDistance(Unit otherUnit) {
            return Vector3.Distance(Position, otherUnit.Position);
        }

        public double GetDistance(Vector3 location) {
            return Vector3.Distance(Position, location);
        }
        
        public void Train(uint unitType, bool queue=false) {            
            if (!queue && Orders.Count > 0)
                return;            

            var abilityID = Abilities.GetID(unitType);            
            var action = Controller.CreateRawUnitCommand(abilityID);
            action.ActionRaw.UnitCommand.UnitTags.Add(Tag);
            Controller.AddAction(action);

            var targetName = Controller.GetUnitName(unitType);
            Logger.Info("Started training: {0}", targetName);
        }
        
        private void FocusCamera() {
            var action = new Action();
            action.ActionRaw = new ActionRaw();
            action.ActionRaw.CameraMove = new ActionRawCameraMove();
            action.ActionRaw.CameraMove.CenterWorldSpace = new Point();
            action.ActionRaw.CameraMove.CenterWorldSpace.X = Position.X;
            action.ActionRaw.CameraMove.CenterWorldSpace.Y = Position.Y;
            action.ActionRaw.CameraMove.CenterWorldSpace.Z = Position.Z;            
            Controller.AddAction(action);
        }
        
        
        public void Move(Vector3 target) {
            var action = Controller.CreateRawUnitCommand(Abilities.MOVE);
            action.ActionRaw.UnitCommand.TargetWorldSpacePos = new Point2D();
            action.ActionRaw.UnitCommand.TargetWorldSpacePos.X = target.X;
            action.ActionRaw.UnitCommand.TargetWorldSpacePos.Y = target.Y;
            action.ActionRaw.UnitCommand.UnitTags.Add(Tag);
            Controller.AddAction(action);
        }
        
        public void Smart(Unit unit) {
            var action = Controller.CreateRawUnitCommand(Abilities.SMART);
            action.ActionRaw.UnitCommand.TargetUnitTag = unit.Tag;
            action.ActionRaw.UnitCommand.UnitTags.Add(Tag);
            Controller.AddAction(action);
        }


        
    }
}